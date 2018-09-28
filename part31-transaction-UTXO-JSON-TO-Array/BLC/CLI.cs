using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLC
{
    class CLI
    {
        public void Run(string[] args)
        {
            CliParser.IsValidArgs(args);
            switch (args[0])
            {
                case "send":
                    var addblock = CliParser.Parse_addblock(args);
                    if (null!= addblock)
                    {
                        //AddBlock(addblock);

                    }
                    else
                    {
                        CliParser.PrintUsage();
                    }
                    break;
                case "printchain":
                    var print = CliParser.Parse_printchain(args);
                    if (Convert.ToBoolean(print))
                        PrintBC();
                    break;
                case "createblockchain":
                    var createbc = CliParser.Parse_createblockchain(args);
                    if (!string.IsNullOrWhiteSpace(createbc))
                        CreateGenesisBlockchain(createbc);
                    else
                        Console.WriteLine("地址不能为空...");
                    break;
                default:
                    CliParser.PrintUsage();
                    break;
            }

        }


        private void PrintBC()
        {
            if (!Utils.DbExists)
            {
                Console.WriteLine("数据不存在.......");
                Environment.Exit(0);
            }
            var bc = new Blockchain();
            try
            {
                bc.Printchain();
            }
            finally
            {
                if (null != bc.Db)
                    bc.Db.Dispose();
            }

        }

        private void AddBlock(Transaction[] data)
        {
            if (!Utils.DbExists)
            {
                Console.WriteLine("数据不存在.......");
                Environment.Exit(0);
            }
            var bc = new Blockchain();
            try
            {
                bc.AddBlockToBlockchain(data);
            }
            finally
            {
                if (null != bc.Db)
                    bc.Db.Dispose();
            }
        }
        private void CreateGenesisBlockchain(string address)
        {
            Blockchain.CreateGenesisBlock(address);
        }
    }
}
