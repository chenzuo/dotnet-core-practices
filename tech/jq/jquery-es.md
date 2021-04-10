### 一、在web项目中使用jquery
在我们现在的项目中，使用都是React, Redux, Angular, Vue等非常流行的开源框架，但是jquery这样的年久的框架其实很多项目中也还在使用。在我们现在行项目中使用都是以es这样的标准进行项目开发，那么我们如何在现有项目中使用jquery呢？
#### 1、初使化项目
step1:初使化配置文件：
```ps
npm init
```
step2:安装jquery
```ps
npm install jquery --save
npm install @types/jquery --save
tsc --init
```
```javascript
$(document).ready(function () {
    alert('RUNOOB');
});
```

>参考地址：
>+ https://stackoverflow.com/questions/32050645/how-to-use-jquery-with-typescript