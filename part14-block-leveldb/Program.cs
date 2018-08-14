using LevelDB;
using part14_block_leveldb.BLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part14_block_leveldb
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个区块
            var block = new Block("Genesis Block data");
            Console.WriteLine("原区块数据："+block);
            //如果数据库不存在就创建库，有就返回当前库
            var db = DB.Open(Utils.CurrentPath + "blocks", new Options { CreateIfMissing = true });
            //把区块序列化后存入数据库
            db.Put(WriteOptions.Default, "l", block.SerializeBlock());
            //获取数据
            var value = db.Get(ReadOptions.Default, "l");
            //反序列化区块
            var b = Block.DeserializeBlock(value.ToArray());
            //打印区块数据
            Console.WriteLine("从数据库取出来后反序列化的区块数据："+b);

            Console.ReadLine();
        }
    }
}
