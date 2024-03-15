// Build the kernel with OpenAI GPT-3.5 Turbo chat completion service
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

using Semantic_Kernel;

var builder = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion("", "", "");
builder.Plugins.AddFromType<LightPlugin>();
var kernel = builder.Build();

// Create an empty chat history
var history = new ChatHistory();

// Retrieve the chat completion service
var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

// Start conversation loop
Console.Write("User > ");
while (true)
{
    // Read user input
    string? userInput = Console.ReadLine();
    if (userInput == null)
    {
        break; // Exit loop on null input
    }

    // Add user message to history
    history.AddUserMessage(userInput);

    // Enable auto function call for SimplifiedSettings
    var openAiPromptExecutionSettings = new OpenAIPromptExecutionSettings
    {
        ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
    };

    // Get AI response
    var result = await chatCompletionService.GetChatMessageContentAsync(
        history,
        executionSettings: openAiPromptExecutionSettings,
        kernel: kernel);

    // Print AI response
    Console.WriteLine("Assistant > " + result);

    // Add AI response to history
    history.AddMessage(result.Role, result.Content ?? string.Empty);

    // Prompt for next user input
    Console.Write("User > ");
}

Console.WriteLine("Goodbye!");
