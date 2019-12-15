### centos cmd suit(set)  

#### 系统监控
+ free命令  
free 命令能够显示系统中物理上的空闲和已用内存，还有交换内存，同时，也能显示被内核使用的缓冲和缓存
>语法：```free [param]```
>+ param可以为：  
    -b：以Byte为单位显示内存使用情况；
    -k：以KB为单位显示内存使用情况；  
    -m：以MB为单位显示内存使用情况；  
    -o：不显示缓冲区调节列；  
    -s<间隔秒数>：持续观察内存使用状况；  
    -t：显示内存总和列；  
    -V：显示版本信息。  

Men：表示物理内存统计
>+ total：表示物理内存总数(total=used+free)  
        used：表示系统分配给缓存使用的数量(这里的缓存包括buffer和cache)  
        free：表示未分配的物理内存总数  
        shared：表示共享内存  
        buffers：系统分配但未被使用的buffers 数量。  
        cached：系统分配但未被使用的cache 数量。  
