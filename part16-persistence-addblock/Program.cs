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
            // 创世区块
            var blockchain = new Blockchain();

            //新区块
            blockchain.AddBlockToBlockchain("Send 100RMB To zhangqiang");
            blockchain.AddBlockToBlockchain("Send 200RMB To changjingkong");
            blockchain.AddBlockToBlockchain("Send 300RMB To juncheng");
            blockchain.AddBlockToBlockchain("Send 50RMB To haolin");

            //测试代码
            DB db = null;
            try
            {
                db = DB.Open(Utils.CurrentPath + Utils.DbName, new Options { CreateIfMissing = true });
                var hash = Utils.SHA256byteArr2String(db.Get(ReadOptions.Default, Utils.CurrentKeyName).ToArray());
                Console.WriteLine(hash);
                var blockBytes = db.Get(ReadOptions.Default, Utils.CurrentKeyName).ToArray();
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
