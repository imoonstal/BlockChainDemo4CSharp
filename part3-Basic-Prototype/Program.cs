using part3_Basic_Prototype.BLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part3_Basic_Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var genesisBlockchain = Blockchain.CreateBlockchainWithGenesisBlock();

            Console.WriteLine(genesisBlockchain);

            //Console.WriteLine(genesisBlockchain.Blocks);

            Console.WriteLine(genesisBlockchain.Blocks[0]);




            Console.ReadLine();
        }
    }
}
