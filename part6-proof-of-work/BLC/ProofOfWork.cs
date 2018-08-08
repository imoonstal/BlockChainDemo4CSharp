using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace part6_proof_of_work.BLC
{
    class ProofOfWork
    {
        public Block Block { get; set; }
        public BigInteger Target { get; set; }


        //0000 0000 0000 0000 1001 0001 0000 .... 0001

        // 256位Hash里面前面至少要有16个零
        const int targetBit = 16;

        public (byte[] hash, long nonce) Run()
        {
            return (null, 0);
        }



        // 创建新的工作量证明对象
        public static ProofOfWork NewProofOfWork(Block block)
        {
            //1.big.Int对象 1
            // 2
            //0000 0001
            // 8 - 2 = 6
            // 0100 0000  64
            // 0010 0000
            // 0000 0000 0000 0001 0000 0000 0000 0000 0000 0000 .... 0000

            //1. 创建一个初始值为1的target
            var target = new BigInteger(1);
            //2. 左移256 - targetBit
            target = target << 256 - targetBit;

            return new ProofOfWork { Block = block, Target = target };
        }
    }
}
