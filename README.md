# BlockChainDemo4CSharp
**C#实现的公链，仅供学习和交流。**
## 简介

#### 版本说明
  1. 代码是在学习的过程中为了更好的理解，从 孔壹学院 黎老师的GoLang版的代码翻译过来的。
  2. 原版GoLang的代码地址:https://github.com/liyuechun/blockchain_go_videos
  3. 教程可以上 孔壹学院 官网学习，http://www.kongyixueyuan.com/
#### 代码说明
  1. 代码结构尽量保持一致，但由于语言特点不一样，所以其中有些跟原版不太一样，可对照Go版来学习。
  2. 代码需要安装.net Framework4.7。
  3. 数据库部分，由于没找到.net操作boltdb的支持，就选了leveldb作为存储数据库。有熟悉.net操作boltdb的朋友，可以mail告知下，谢谢。
  4. leveldb是个key-value的嵌入式库，它没有boltdb中Bucket的概念，并且它创建的不是一个文件，而是一个文件夹。
  5. 整个go版源码，其实是一个逐渐增加和修改的渐进的学习的过程，所以有些部分变化很小。因此我合并了part，比如：part10-13的go版源码都是讲解基础的boltdb操作，就合并成一个project，很简单的一个小demo，演示一下创建库，put和get方法。
  6. LevelDB.Net.dll直接从NuGet上获取即可，工程文件把优先32位的钩钩去掉。
  7. leveldb详细信息请参考官网：http://leveldb.org 还有一篇blog：https://blog.csdn.net/linuxheik/article/details/52768223
