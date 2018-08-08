using part2_Basic_Prototype.BLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2_Basic_Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var genesisBlock = Block.CreateGenesisBlock("Genesis Block.....");
            Console.WriteLine(genesisBlock);


            Console.ReadLine();
        }
    }
}
