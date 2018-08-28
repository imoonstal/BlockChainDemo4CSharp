using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part21_23_cil
{
    class Program
    {
        static void Main(string[] args)
        {
            //args = new string[] { "addblock", "-data", "ddd", "printchain", "aaaa" };
            CliParser.IsValidArgs(args);

            CliParser.Register("addblock");
            CliParser.Register("printchain");
            CliParser.InitCmd(args);

            if (!string.IsNullOrWhiteSpace(CliParser.Parse("addblock").ToString()))
                Console.WriteLine(CliParser.Parse("addblock"));
            if (!string.IsNullOrWhiteSpace(CliParser.Parse("printchain").ToString()))
                Console.WriteLine(CliParser.Parse("printchain"));

            //测试
            //编译完，在命令行运行
            //bc addblock -data  send100RMBtome
            //结果
            //send100RMBtome

        }
    }

}
