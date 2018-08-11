using part9_Serialize_DeserializeBlock.BLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part9_Serialize_DeserializeBlock
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个区块
            var block = new Block("Test", 1, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            Console.WriteLine(block.Nonce);
            Console.WriteLine(Utils.SHA256byteArr2String(block.Hash));

            var bytes = block.SerializeBlock();
            Console.WriteLine(Utils.SHA256byteArr2String(bytes));

            block = Block.DeserializeBlock(bytes);
            Console.WriteLine(block.Nonce);
            Console.WriteLine(Utils.SHA256byteArr2String(block.Hash));


            Console.ReadLine();
        }
    }
}
