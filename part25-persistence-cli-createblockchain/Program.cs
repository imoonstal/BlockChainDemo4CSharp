using BLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part25_persistence_cli_createblockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            var cli = new CLI();
            cli.Run(args);
        }
    }
}
