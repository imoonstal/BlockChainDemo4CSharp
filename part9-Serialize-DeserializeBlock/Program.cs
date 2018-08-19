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
            var block = new Block("这是一个创世区块", 1, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            Console.WriteLine(block);

            var bytes = block.SerializeBlock();
            Console.WriteLine(Utils.SHA256byteArr2String(bytes));


            block = Block.DeserializeBlock(bytes);
            Console.WriteLine(block);


            Console.ReadLine();
        }
    }
}
