using BLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part19_20_persistence_Iterator_separate
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
                blockchain.Printchain();
            }
            finally
            {
                blockchain.Db.Dispose();
            }


            Console.ReadLine();
        }
    }
}
