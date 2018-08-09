using part8_proof_of_work.BLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part8_proof_of_work
{
    class Program
    {
        static void Main(string[] args)
        {
            //// 创世区块
            //var blockchain = Blockchain.CreateBlockchainWithGenesisBlock();

            //// 新区块
            //blockchain.AddBlockToBlockchain("Send 100RMB To zhangqiang", blockchain.Blocks[blockchain.Blocks.Count - 1].Height + 1, blockchain.Blocks[blockchain.Blocks.Count - 1].Hash);
            //blockchain.AddBlockToBlockchain("Send 200RMB To changjingkong", blockchain.Blocks[blockchain.Blocks.Count - 1].Height + 1, blockchain.Blocks[blockchain.Blocks.Count - 1].Hash);
            //blockchain.AddBlockToBlockchain("Send 300RMB To juncheng", blockchain.Blocks[blockchain.Blocks.Count - 1].Height + 1, blockchain.Blocks[blockchain.Blocks.Count - 1].Hash);
            //blockchain.AddBlockToBlockchain("Send 50RMB To haolin", blockchain.Blocks[blockchain.Blocks.Count - 1].Height + 1, blockchain.Blocks[blockchain.Blocks.Count - 1].Hash);

            //Console.WriteLine(blockchain);

            ////fmt.Println(blockchain.Blocks)

            var block = new Block("Test", 1, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            Console.WriteLine(block.Nonce);
            Console.WriteLine(Utils.SHA256byteArr2String(block.Hash));

            var proofOfWork = new ProofOfWork(block);
            var b = proofOfWork.IsValid();
            Console.WriteLine(b);



            Console.ReadLine();
        }
    }
}
