### Stencil:高性能的web组件web App编译器
Stencil是一个生成Web组件（更具体地说是自定义元素）并构建高性能Web应用程序的编译器。 Stencil将最流行的框架的最佳概念结合到一个简单的构建时工具中。  

Stenci具备以下功能：  
- Virtual DOM
-  异步渲染（类React Fiber功能）
- 响应式数据绑定
- TypeScript语言支持
- JSX支持
- 静态网站生成(SSG)

然后生成包含这些功能的基于标准的Web组件和Web应用程序.  
由于Stencil生成符合标准的Web组件，因此它们可以直接与其它流行的框架集成，因为生成的的一些框架与组件，因此无需其它框架的情况下就可以直接运行。 Stencil还启用了Web组件之上的许多关键功能，特别是预渲染和对象即属性（而不仅仅是字符串）。  
与直接使用自定义元素相比，Stencil提供了额外的API，这些API使编写快速组件的过程变得更加简单。虚拟DOM，JSX和异步呈现等API使快速，强大的组件易于创建，同时仍保持与Web组件的100％兼容性。  
开发人员的体验也得到了调整，并带有实时重载和嵌入到编译器中的小型开发服务器。　　
但是Stencil还可以用于构建高性能的Web应用程序，提供诸如静态网站生成和强大的缓存之类的高级功能。

### 为什么要使用Stencil？　　
Stencil是由Ionic Framework团队创建的，旨在帮助构建可在所有主要框架中使用的更快，功能更强大的组件。
尽管Ionic主要针对Cordova应用程序，但渐进式Web应用程序作为Web开发人员快速增长的目标的出现要求对Web应用程序开发性能采取不同的方法。借助Ionic对传统框架和捆绑技术的经典使用，该团队努力满足渐进式Web应用程序在各种平台和设备上在快速和慢速网络上均能良好运行的延迟和代码大小要求。  此外，框架碎片造成了Web开发互操作性的噩梦，其中为一个框架构建的组件无法与另一个框架一起使用。Web Components提供了针对这两个问题的解决方案，将更多的工作投入浏览器以提高性能，并针对所有框架都可以使用的基于标准的组件模型。但是，仅靠Web组件还不够。构建快速的Web应用程序需要创新，而这些创新以前被锁定在传统Web框架内。 Stencil的创建是为了将这些功能从传统框架中提取出来，并带入快速兴起的Web组件标准中。 

[getting started](./getting-started.md)