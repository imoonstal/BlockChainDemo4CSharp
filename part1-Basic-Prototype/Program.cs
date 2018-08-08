using part1_Basic_Prototype.BLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part1_Basic_Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var preBlockHash = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var block = Block.NewBlock("Genenis Block", 1, preBlockHash);

            Console.WriteLine(block);



            Console.ReadLine();
        }
    }
}
