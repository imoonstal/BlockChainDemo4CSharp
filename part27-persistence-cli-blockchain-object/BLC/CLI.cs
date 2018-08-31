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
            //1.先注册命令
            CliParser.Register("addblock");
            CliParser.Register("printchain");
            CliParser.Register("createblockchain");
            CliParser.InitCmd(args);

            //2.解析命令
            var addblock = CliParser.Parse("addblock");
            if (null != addblock)
            {
                if (!string.IsNullOrWhiteSpace(addblock.ToString()))
                    AddBlock(addblock.ToString());
                else
                    Console.WriteLine("区块数据不能为空...");
            }

            var print = CliParser.Parse("printchain");
            if (null != print)
            {
                if (Convert.ToBoolean(print))
                    PrintBC();
            }

            if (args[0] == "createblockchain")
            {
                var createbc = CliParser.Parse("createblockchain");
                if (null != createbc)
                {
                    if (!string.IsNullOrWhiteSpace(createbc.ToString()))
                        CreateGenesisBlockchain(createbc.ToString());
                    else
                        Console.WriteLine("区块数据不能为空...");
                }
                else
                {
                    //创建默认创世区块
                    CreateGenesisBlockchain("Genesis data...");
                }
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

        private void AddBlock(string data)
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
        private void CreateGenesisBlockchain(string data)
        {
            Blockchain.CreateGenesisBlock(data);
        }
    }
}
