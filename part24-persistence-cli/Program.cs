using BLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part24_persistence_cli
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
                var cli = new CLI { BC = blockchain };
                cli.Run(args);
            }
            finally
            {
                blockchain.Db.Dispose();
            }
            //Console.ReadLine();


            //测试：
            //1.运行 bc addblock -data 
            //2.运行 bc printchain
        }
    }
}
