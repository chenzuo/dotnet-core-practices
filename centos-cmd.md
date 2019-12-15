### centos cmd suit(set)  

#### 系统监控
+ free命令  
free 命令能够显示系统中物理上的空闲和已用内存，还有交换内存，同时，也能显示被内核使用的缓冲和缓存
>语法：```free [param]```
>param可以为：  
    -b：以Byte为单位显示内存使用情况；
    -k：以KB为单位显示内存使用情况；  
    -m：以MB为单位显示内存使用情况；  
    -o：不显示缓冲区调节列；  
    -s<间隔秒数>：持续观察内存使用状况；  
    -t：显示内存总和列；  
    -V：显示版本信息。  

+ ```free Men```：表示物理内存统计
>total：表示物理内存总数(total=used+free)  
        used：表示系统分配给缓存使用的数量(这里的缓存包括buffer和cache)  
        free：表示未分配的物理内存总数  
        shared：表示共享内存  
        buffers：系统分配但未被使用的buffers 数量。  
        cached：系统分配但未被使用的cache 数量。  
+ ulimit命令  
ulimit用于显示系统资源限制的信息
>语法：```ulimit [param]```
>param参数可以为   
-a 　显示目前资源限制的设定。 
-c <core文件上限> 　设定core文件的最大值，单位为区块。  
-d <数据节区大小> 　程序数据节区的最大值，单位为KB。  
-f <文件大小> 　shell所能建立的最大文件，单位为区块。  
-H 　设定资源的硬性限制，也就是管理员所设下的限制。  
-m <内存大小> 　指定可使用内存的上限，单位为KB。  
-n <文件数目> 　指定同一时间最多可开启的文件数。  
-p <缓冲区大小> 　指定管道缓冲区的大小，单位512字节。  
-s <堆叠大小> 　指定堆叠的上限，单位为KB。  
-S 　设定资源的弹性限制。  
-t <CPU时间> 　指定CPU使用时间的上限，单位为秒。  
-u <程序数目> 　用户最多可开启的程序数目。  
-v <虚拟内存大小> 　指定可使用的虚拟内存上限，单位为KB  
+ top命令 
top命令可以实时动态地查看系统的整体运行情况，是一个综合了多方信息监测系统性能和运行信息的实用工具  
>语法：```top [param]```  
>param为：  
    -b：以批处理模式操作；  
    -c：显示完整的治命令；  
    -d：屏幕刷新间隔时间；  
    -I：忽略失效过程；  
    -s：保密模式；  
    -S：累积模式；  
    -u [用户名]：指定用户名；  
    -p [进程号]：指定进程；  
    -n [次数]：循环显示的次数。  

+ df命令  
>df -h查看磁盘使用情况  
df -i 查看inode使用情况  

+ ps命令  
>ps命令用于查看进程统计信息
>常用参数：  
    a：显示当前终端下的所有进程信息，包括其他用户的进程。  
    u：使用以用户为主的格式输出进程信息。  
    x：显示当前用户在所有终端下的进程。  
    -e：显示系统内的所有进程信息。  
    -l：使用长（long）格式显示进程信息。  
    -f：使用完整的（full）格式显示进程信息。  

在使用中可以加上grep命令一起使用，也可以单独使用  
> ps命令单独使用的情况  
ps -elf tomcat  
#结合管道操作和grep命令进行过滤，用于查询某一个进程的信息  
ps -elf | grep tomcat  
  
#### 文件操作  
+ tail命令  
tail 命令可用于查看文件的内容，语法为  
>```tail [param] [filename]```  
>其中param可为：  
    -f ：循环读取  
    -q ：不显示处理信息  
    -v ：显示详细的处理信息    
    -c [数目]： 显示的字节数  
    -n [行数]： 显示文件的尾部 n 行内容  
    –pid=PID ：与-f合用,表示在进程ID,PID死掉之后结束  
    -q, --quiet, --silent ：从不输出给出文件名的首部  
    -s, --sleep-interval=S ：与-f合用,表示在每次反复的间隔休眠S秒  

+ ll -ah
ll -ah命令，可以用于查看文件情况  
>语法：```ll -ah```  
#### 网络通信  
+ netstat命令
netstat用于监控进出网络的包和网络接口统计的命令行工具  
>语法：```netstat [param]```  
>param参数可以为：  
    -h : 查看帮助   
    -r : 显示路由表  
    -i : 查看网络接口  
+ 重启网络  
重启网络，可以用命令：  
>语法：```service network restart ```  
#### 系统监控  
+ uname
>uname命令用于查看内核版本  
+ ip addr 
查看ip地址：可以用命令  
> 语法:```ip addr```  


####  linux常规操作命令集整理
+ 列出当前目录下所有文件与目录  
```sh
ls
```
+ 防火墙操作
```sh
启动： systemctl start firewalld
关闭： systemctl stop firewalld
查看状态： systemctl status firewalld
开机禁用  ： systemctl disable firewalld
开机启用  ： systemctl enable firewalld

启动一个服务：systemctl start firewalld.service
关闭一个服务：systemctl stop firewalld.service
重启一个服务：systemctl restart firewalld.service
显示一个服务的状态：systemctl status firewalld.service
在开机时启用一个服务：systemctl enable firewalld.service
在开机时禁用一个服务：systemctl disable firewalld.service
查看服务是否开机启动：systemctl is-enabled firewalld.service
查看已启动的服务列表：systemctl list-unit-files|grep enabled
查看启动失败的服务列表：systemctl --failed

查看版本： firewall-cmd --version
查看帮助： firewall-cmd --help
显示状态： firewall-cmd --state
查看所有打开的端口： firewall-cmd --zone=public --list-ports
更新防火墙规则： firewall-cmd --reload
查看区域信息:  firewall-cmd --get-active-zones
查看指定接口所属区域： firewall-cmd --get-zone-of-interface=eth0
拒绝所有包：firewall-cmd --panic-on
取消拒绝状态： firewall-cmd --panic-off
查看是否拒绝： firewall-cmd --query-panic

添加：firewall-cmd --zone=public --add-port=80/tcp --permanent （--permanent永久生效，没有此参数重启后失效）
重新载入
firewall-cmd --reload
查看：firewall-cmd --zone=public --query-port=80/tcp
删除：firewall-cmd --zone=public --remove-port=80/tcp --permanent

```

 