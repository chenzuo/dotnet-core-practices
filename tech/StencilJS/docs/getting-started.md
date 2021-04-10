#### 开始一个新项目
Stencil 依赖最新版本的NodeJs，开始之前，请确认你在开发机上已经安装或者更新Nodejs到最新版本。  
>mpm需要6以上的版本.
```shell
 npm init stencil
 ```
 使用Stencli能够创建独立组件或者独立应用。你使用init命令时会弹出选择对应的类型，初使化相关项目名称后，你就可以开始你的项目或应用了。
 执行init命令后，输出窗口内容如下，然后你就可以进行选择相应的内容：
 ```shell

? Pick a starter » - Use arrow-keys. Return to submit.

>  ionic-pwa     Everything you need to build fast, production ready PWAs
   app           Minimal starter for building a Stencil app or website   
   component     Collection of web components that can be used anywhere  
 ```
上面选择component，输入名称后显示以下内容，说明已经执行成功：
```shell
√ Pick a starter » component
√ Project name » stm

✔ All setup 🎉 in 305 ms

  > npm start
    Starts the development server.

  > npm run build
    Builds your components/app in production mode.

  > npm test
    Starts the test runner.


  We suggest that you begin by typing:

   > cd stm
   > npm install
   > npm start

  Further reading:

   - https://github.com/ionic-team/stencil-component-starter

  Happy coding! 🎈
```
#### 更新 Stencil
如果要更新stencli到最新版本，请执行以下命令
```shell
npm install @stencil/core@latest --save-exact
```