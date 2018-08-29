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
            CliParser.InitCmd(args);

            //2.解析命令
            var data = CliParser.Parse("addblock");
            if (null != data)
            {
                if (!string.IsNullOrWhiteSpace(data.ToString()))
                    AddBlock(data.ToString());
            }

            var print = CliParser.Parse("printchain");
            if (null != print) 
            {
                if (Convert.ToBoolean(print))
                    PrintBC();
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
    }
}
