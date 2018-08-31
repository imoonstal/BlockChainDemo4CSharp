using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLC
{
    class CLI
    {
        public Blockchain BC { get; set; }

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
            }

            var print = CliParser.Parse("printchain");
            if (null != print) 
            {
                if (Convert.ToBoolean(print))
                    PrintBC();
            }

            var createbc = CliParser.Parse("createblockchain");
            if (null != createbc)
            {
                if (!string.IsNullOrWhiteSpace(createbc.ToString()))
                    CreateGenesisBlockchain(createbc.ToString());
            }
            else
            {
                Console.WriteLine("交易数据不能为空......");
            }
        }


        private void PrintBC()
        {
            BC.Printchain();
        }

        private void AddBlock(string data)
        {
            BC.AddBlockToBlockchain(data);
        }
        private void CreateGenesisBlockchain(string data)
        {
            new Blockchain(data);
        }
    }
}
