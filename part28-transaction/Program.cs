using BLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part28_transaction
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var cli = new CLI();
                cli.Run(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"运行异常:{ex.Message}");
            }
        }
    }
}
