using LevelDB;
using part15_persistence_creategenesisblock.BLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part15_persistence_creategenesisblock
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.先运行此行，创建区块链，并记录下区块的hash值。
            //2.再注释此行，把测试代码取消注释，再次运行。
            //3.查看存储的hash和创建的hash值，是一样的。
            var blockchain = new Blockchain();

            //测试代码
            //var db = DB.Open(Utils.CurrentPath + Utils.DbName, new Options { CreateIfMissing = true });
            //var hash = Utils.SHA256byteArr2String(db.Get(ReadOptions.Default, Utils.CurrentKeyName).ToArray());
            //Console.WriteLine(hash);
            Console.ReadLine();
        }
    }
}
