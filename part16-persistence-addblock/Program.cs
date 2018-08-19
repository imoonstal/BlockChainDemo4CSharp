using BLC;
using LevelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part16_persistence_addblock
{
    class Program
    {
        static void Main(string[] args)
        {
            Blockchain blockchain = null;
            try
            {

                // 创建一个带创世区块的区块链
                blockchain = new Blockchain();

                //添加新区块
                blockchain.AddBlockToBlockchain("Send 100RMB To zhangqiang");
                blockchain.AddBlockToBlockchain("Send 200RMB To changjingkong");
                blockchain.AddBlockToBlockchain("Send 300RMB To juncheng");
                blockchain.AddBlockToBlockchain("Send 50RMB To haolin");
            }
            finally
            {
                blockchain.Db.Dispose();
            }


            //测试代码
            //测试前请删除数据库文件
            DB db = null;
            try
            {
                db = DB.Open(Utils.CurrentPath + Utils.DbName, new Options { CreateIfMissing = true });
                var blockKey = db.Get(ReadOptions.Default, Utils.CurrentKeyName).ToArray();
                var blockBytes = db.Get(ReadOptions.Default, blockKey).ToArray();
                var block = Block.DeserializeBlock(blockBytes);
                Console.WriteLine(block);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                db.Dispose();
            }

            //blockchain.Printchain()

            Console.ReadLine();
        }
    }
}
