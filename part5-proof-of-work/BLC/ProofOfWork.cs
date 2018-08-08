using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part5_proof_of_work.BLC
{
    class ProofOfWork
    {
        public Block Block { get; set; }

        public (byte[] hash, long nonce) Run()
        {
            return (null, 0);
        }



        // 创建新的工作量证明对象
        public static ProofOfWork NewProofOfWork(Block block)
        {
            return new ProofOfWork { Block = block };
        }
    }
}
