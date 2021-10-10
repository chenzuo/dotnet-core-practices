## Polymorphic Serialization in System.Text.Json使用System.Text.Json中的多态序列化问题处理)
### （Problem）背景
Sometimes when you're serializing a C# class to JSON, you want to include polymorphic properties in the JSON output. If you're using System.Text.Json (version 4.0.1.0 or lower) to do the serialization, this won't happen automatically. Consider the following code below for an example.
```csharp
public class Chart
{
    public ChartOptions Options { get; set; }
}

public abstract class ChartOptions
{
    public bool ShowLegend { get; set; }
}

public class LineChartOptions : ChartOptions
{
    public IEnumerable<Color> DefaultLineColors { get; set; }
}
```  
In the above code, we have a class that describes a Chart and that chart has a property with some Options. The property's type is ChartOptions, which is a base class that is common to all the different types of charts. There's a LineChartOptions class that inherits from ChartOptions and includes an additional property called DefaultLineColors that defines some colors for the lines of the line chart.
```csharp
Chart chart = new Chart
{
    Options = new LineChartOptions
    {
        DefaultLineColors = new [] { Color.Red, Color.Purple, Color.Blue }
    }
};
string json = JsonSerializer.Serialize(chart);
```  
The value of json will be {"Options":{"ShowLegend":false}}. Note that it's missing the DefaultLineColors property. Why is that happening? It's because the behavior of JsonSerializer is to only serialize members of the types that are defined in the object hierarchy at compile time. In other words, the serializer looks at the Chart class and sees that the type of the Options property is ChartOptions, so it looks at the ChartOptions class's members and only sees ShowLegend, so that's the only thing that it serializes, even though the instance of the object inside of the Options property might be a subclass of ChartOptions that includes additional properties.  
### Solution(解决方案)
So how do we get it to serialize all of the properties, including those defined in subtypes? Unfortunately, there's not a great answer to that question at the time of this writing. There are active discussions and complaints about this missing functionality on GitHub. The best solution I've found thus far (aside from switching back to Newtonsoft.Json for serialization) is to use a customer JsonConverter<T>. An example of one such converter is below. Please note that deserialization has not been implemented.  
```csharp
public class PolymorphicJsonConverter<T> : JsonConverter<T>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeof(T).IsAssignableFrom(typeToConvert);
    }

    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteStartObject();
        foreach (var property in value.GetType().GetProperties())
        {
            if (!property.CanRead)
                continue;
            var propertyValue = property.GetValue(value);
            writer.WritePropertyName(property.Name);
            JsonSerializer.Serialize(writer, propertyValue, options);
        }
        writer.WriteEndObject();
    }
}
```  
Here's how to apply it.  
```c#
Chart chart = new Chart
{
    Options = new LineChartOptions
    {
        DefaultLineColors = new[] { Color.Red, Color.Purple, Color.Blue }
    }
};
var options = new JsonSerializerOptions();
options.Converters.Add(new PolymorphicJsonConverter<ChartOptions>());
string json = JsonSerializer.Serialize(chart, options);
return JsonSerializer.Serialize(this, s_serializerOptions);
```  
The PolymorphicJsonConverter<T> is a generic type and an instance of that converter must be added to the JsonSerializerOptions for every root type in your inheritance hierarchy. For example, if you want to support polymorphic serialization for class Baz that inherits from class Bar that inherits from class Foo, then you'd need to add an instance of PolymoprhicJsonConverter<Foo> to your serializer options.

Here's the correct JSON that was generated from the example above that uses PolymorphicJsonConverter<T>.  
```json
{
    "Options":{
        "DefaultLineColors":[
            {
                "R":255,
                "G":0,
                "B":0,
                "A":255,
                "IsKnownColor":true,
                "IsEmpty":false,
                "IsNamedColor":true,
                "IsSystemColor":false,
                "Name":"Red"
            },
            {
                "R":128,
                "G":0,
                "B":128,
                "A":255,
                "IsKnownColor":true,
                "IsEmpty":false,
                "IsNamedColor":true,
                "IsSystemColor":false,
                "Name":"Purple"
            },
            {
                "R":0,
                "G":0,
                "B":255,
                "A":255,
                "IsKnownColor":true,
                "IsEmpty":false,
                "IsNamedColor":true,
                "IsSystemColor":false,
                "Name":"Blue"
            }
        ],
        "ShowLegend":false
    }
}
```
原文地址：https://getyourbitstogether.com/polymorphic-serialization-in-system-text-json/