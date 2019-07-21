容器化技术最直接方式是用docker来实现，它可以让你以“开箱即用的方式”进行快速的编译，测试和部署应用程序，这样就可以让你的应用程序在任何有容器化的地方进行运行。  

在本教程中，我们展示如何在CentOS7安装Docker CE和使用最基础的容器操作命令。  
 
### 前提条件  
在开始这个教材前，必须提前准备好以下几个先决条件： 
+ CentOS7+ 服务器一台  
+ 使用权限必须是root管理员权限，你果你还不知道如何对一个用户创建non-root权限，你可以查看这个[连接](https://linuxize.com/post/create-a-sudo-user-on-centos/)

### 在CentOS上安装Docker
虽然docker软件包在官方CentosOS储存库中可用，但它不一定是最新的版本，所以推荐的方法是从Docker的存储库安装Docker,如果你系统中已经安装了，那么可以先执行以下命令先移除： 
```sh

```
下面是在CentOS7服务器里安装Docker的步骤：
#### 01.更新系统安装必要的依赖库
```sh
sudo yum update
sudo yum install yum-utils device-mapper-persistent-data lvm2
```
#### 02.在CentOS中安装Docker稳定包
```sh
sudo yum-config-manager --add-repo https://download.docker.com/linux/centos/docker-ce.repo
```
#### 03.安装最新的Docker CE(Community Edition)
```sh
sudo yum install docker-ce
```
#### 04.开启Docker服务在系统启动时自动启动
```sh
sudo systemctl start docker
sudo systemctl enable docker
```
#### 05.验证Docker服务是否已在系统中可用
```sh
sudo systemctl status docker
```
如果服务可用，执行上面命令后可以看到以下结果：
```sh
● docker.service - Docker Application Container Engine
   Loaded: loaded (/usr/lib/systemd/system/docker.service; enabled; vendor preset: disabled)
   Active: active (running) since Sun 2019-07-21 02:32:13 CST; 9h ago
     Docs: https://docs.docker.com
 Main PID: 7093 (dockerd)
   CGroup: /system.slice/docker.service
```
#### 06.查看当前Docker的版本号
```sh
docker -v
```
```sh
Docker version 18.09.8, build 0dd43dd87f
```
### 在系统中使用无“sudo”方式来运行Docker命令
默认情况下，只有拥有管理员权限有用户才可以操作docker命令。如果你想使用一般管理员用户在没有“sudo”方式下运行docker命令，你需要在安装docker ce包的时候就要[添加操作用户到docker的管理组中](https://linuxize.com/post/how-to-add-user-to-group-in-linux/)，以下是操作命令：
```sh
sudo usermod -aG docker $USER
````
“$USER”是获取用户明的[环境变量](https://linuxize.com/post/how-to-set-and-list-environment-variables-in-linux/)  
要刷新权限，你使用的用户必须重新连接到系统才可以拥有上诉权限。
如果要验证docker是否真正的安装成功并且可以使用。如果要真正验证用户无“sudo”权限使用docker方式的话，可以使用以下命令从docker远程库中下载测试镜像包，运行一个容器实例，输出“Hello from Docker”消息，说明以上操作成功。  
```sh
docker container run hello-world
```
上面命令执行完后结果是：
```sh
[root@iZhd7ly2wzgtrzZ ~]# docker container run hello-world
Unable to find image 'hello-world:latest' locally
latest: Pulling from library/hello-world
Digest: sha256:6540fc08ee6e6b7b63468dc3317e3303aae178cb8a45ed3123180328bcc1d20f
Status: Downloaded newer image for hello-world:latest

Hello from Docker!
This message shows that your installation appears to be working correctly.

To generate this message, Docker took the following steps:
 1. The Docker client contacted the Docker daemon.
 2. The Docker daemon pulled the "hello-world" image from the Docker Hub.
    (amd64)
 3. The Docker daemon created a new container from that image which runs the
    executable that produces the output you are currently reading.
 4. The Docker daemon streamed that output to the Docker client, which sent it
    to your terminal.

To try something more ambitious, you can run an Ubuntu container with:
 $ docker run -it ubuntu bash

Share images, automate workflows, and more with a free Docker ID:
 https://hub.docker.com/

For more examples and ideas, visit:
 https://docs.docker.com/get-started/
```
### Docker命令行操作接口
恭喜你，到这儿说明你已经成功的把docer安装在CentOS7上了。那么下面介绍一下Docker CLI的一些基础使用。  
docker命令格式是：
```sh
docker [option] [subcommand] [arguments]
```
你可以使用不带任何参数的“docker”来显示所有可操作命令
```sh
docker
```
如果你需要各个子“[subcommand]”的用法，那么可以使用以下方式获取
```sh
docker [subcommand] --help
```

### Docker镜像
docker镜像是非常复杂的多层组成，这些都是我们通过配置[Dockerfile](https://linuxize.com/post/how-to-build-docker-images-with-dockerfile/)时进行编译打包生成的。一个镜像是一个不可变的二进数据包，这个包包括了一个应用程序中所有的项目依赖如：二进制文件、类库、和应用程序运行时所需要的一切依赖。换句话说，docker镜像包就是一个docker容器的应用的快照。
Docker Hub是提供给用户存放公有或者私有包的地方。
如果你要使用docker hub上的镜像包库，你可以使用“search”子命令来查询，如：以下命令是搜索CentOS镜像的命令
```sh
docker search centos
```
执行行输出结果是：
```sh
[root@iZhd7ly2wzgtrzZ ~]# docker search centos
NAME                               DESCRIPTION                                     STARS               OFFICIAL            AUTOMATED
centos                             The official build of CentOS.                   5459                [OK]                
ansible/centos7-ansible            Ansible on Centos7                              122                                     [OK]
jdeathe/centos-ssh                 CentOS-6 6.10 x86_64 / CentOS-7 7.6.1810 x86…   110                                     [OK]
consol/centos-xfce-vnc             Centos container with "headless" VNC session…   93                                      [OK]
centos/mysql-57-centos7            MySQL 5.7 SQL database server                   59                                      
imagine10255/centos6-lnmp-php56    centos6-lnmp-php56                              57                                      [OK]
tutum/centos                       Simple CentOS docker image with SSH access      44                                      
centos/postgresql-96-centos7       PostgreSQL is an advanced Object-Relational …   38                                      
kinogmt/centos-ssh                 CentOS with SSH                                 28                                      [OK]
centos/php-56-centos7              Platform for building and running PHP 5.6 ap…   21                                      
pivotaldata/centos-gpdb-dev        CentOS image for GPDB development. Tag names…   10                                      
drecom/centos-ruby                 centos ruby                                     6                                       [OK]
mamohr/centos-java                 Oracle Java 8 Docker image based on Centos 7    3                                       [OK]
darksheer/centos                   Base Centos Image -- Updated hourly             3                                       [OK]
pivotaldata/centos                 Base centos, freshened up a little with a Do…   3                                       
miko2u/centos6                     CentOS6 日本語環境                                   2                                       [OK]
pivotaldata/centos-gcc-toolchain   CentOS with a toolchain, but unaffiliated wi…   2                                       
pivotaldata/centos-mingw           Using the mingw toolchain to cross-compile t…   2                                       
blacklabelops/centos               CentOS Base Image! Built and Updates Daily!     1                                       [OK]
indigo/centos-maven                Vanilla CentOS 7 with Oracle Java Developmen…   1                                       [OK]
mcnaughton/centos-base             centos base image                               1                                       [OK]
pivotaldata/centos6.8-dev          CentosOS 6.8 image for GPDB development         0                                       
pivotaldata/centos7-dev            CentosOS 7 image for GPDB development           0                                       
smartentry/centos                  centos with smartentry                          0                                       [OK]
fortinj66/centos7-s2i-nodejs       based off of ryanj/centos7-s2i-nodejs.  Bigg…   0                                       
[root@iZhd7ly2wzgtrzZ ~]# 

```
你可以看到搜索输出结果表格中有五列，分别是：NAME,DESCRIPTION, STARS, OFFICIAL 和 AUTOMATED.这些镜像都是Docker合作开发者们上面贡献的。
如果我们想下载一个CentOS7的镜像包，我们可以使用 "image pull"子命令来完成
```sh
docker image pull centos
```
结果是：
```sh
Using default tag: latest
latest: Pulling from library/centos
469cfcc7a4b3: Pull complete
Digest: sha256:989b936d56b1ace20ddf855a301741e52abca38286382cba7f44443210e96d16
Status: Downloaded newer image for centos:latest
```
本文发布由https://github.com/chenzuo/dotnet-core-practices原创，如需要转载请标明连接。
下载的速度是看你服务器与docker hub间的网络情况，有时候也许几秒，有时可能几分钟。如果你下载完成后，你可以使查看镜像
```sh
docker image ls
```
查看结果类似
```sh
REPOSITORY          TAG                 IMAGE ID            CREATED             SIZE
hello-world         latest              e38bc07ac18e        3 weeks ago         1.85kB
centos              latest              e934aafc2206        4 weeks ago         199MB
```
如果你想删除镜像包，那么可以使用“image rm [image_name]” 子命令来完成
```sh
docker image rm centos
```
执行结果类似
```sh
Untagged: centos:latest
Untagged: centos@sha256:989b936d56b1ace20ddf855a301741e52abca38286382cba7f44443210e96d16
Deleted: sha256:e934aafc22064b7322c0250f1e32e5ce93b2d19b356f4537f5864bd102e8531f
Deleted: sha256:43e653f84b79ba52711b0f726ff5a7fd1162ae9df4be76ca1de8370b8bbf9bb0
```

### 容器实例（Docker Containers）
一个镜像的实运行实例我们称为“container”,一个"container"可以看成是一个运行时的应用程序或者是一个系统进程或者一个后台服务。
这样说可能不太合适，但是对于一个程序员来理解这个的话，docker镜像就一个类，而这个container就是这个类的一个创建出来的对像实例。
我们可以使用子docker container命令的子参数：start,stop,remove和manager来管理一个container的各种运行状态。
以下命令是实例化一个centos镜像，如查你本地容器包中没有centos镜像的话，系统会主动下载到你的容器中。
```sh
docker container run centos
```
以上命令执行行，你会年到一闪而过，而没有一直运行在系统中，我们使用参数 “-t"来作为运行参数，这样你就可以让contaniner进一直在此session的命令行里运行了。

```sh
docker container run -it centos /bin/bash
```
如果你要列出容器中的镜像，可以使用以下命令
```sh
docker container ls
```
结果是：
```sh
CONTAINER ID        IMAGE               COMMAND             CREATED             STATUS              PORTS               NAMES
79ab8e16d567        centos              "/bin/bash"         22 minutes ago      Up 22 minutes                           ecstatic_ardinghelli
```
查看活动中的镜像可使用以下命令
```sh
docker container ls -a
```
结果类似
```sh
CONTAINER ID        IMAGE               COMMAND                  CREATED             STATUS                      PORTS               NAMES
79ab8e16d567        centos              "/bin/bash"              22 minutes ago      Up 22 minutes                                   ecstatic_ardinghelli
c55680af670c        centos              "/bin/bash"              30 minutes ago      Exited (0) 30 minutes ago                       modest_hawking
c6a147d1bc8a        hello-world         "/hello"                 20 hours ago        Exited (0) 20 hours ago                         sleepy_shannon

```

如果你要删除一个实例或者停止一个实例可以使用
```sh
docker container rm c55680af670c
```

您已经学习了如何在CentOS 7机器上安装Docker以及如何下载Docker镜像和管理Docker容器。 您可能还想了解[Docker Compose](https://linuxize.com/post/how-to-install-and-use-docker-compose-on-centos-7/)，它允许您定义和运行多容器Docker应用程序。

本教程几乎没有涉及Docker其它方面的内容。 在我们的下一篇文章我将介绍dotnet core应用程序在docker中发布与使用。 要了解有关Docker的更多信息，请查看官方Docker文档。

如果您有任何问题或意见，请在下面留言。