using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part5_proof_of_work.BLC
{
    class Block
    {
        #region 属性
        //1. 区块高度
        public long Height { get; set; }
        //2. 上一个区块HASH
        public byte[] PrevBlockHash { get; set; }
        //3. 交易数据
        public byte[] Data { get; set; }
        //4. 时间戳
        public long Timestamp { get; set; }
        //5. Hash
        public byte[] Hash { get; set; }
        //6.Nonce
        public long Nonce { get; set; }
        #endregion

        /// <summary>
        /// 重写Block的ToString方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "{" + $"{this.Height} {Utils.PrintArray(this.PrevBlockHash)} {Utils.PrintArray(this.Data)} {this.Timestamp} {Utils.PrintArray(this.Hash)} {this.Nonce}" + "}";
        }



        //1.生成一个新区块
        /// <summary>
        /// 生成一个新区块
        /// </summary>
        /// <param name="data">交易数据</param>
        /// <param name="height">区块的高度</param>
        /// <param name="prevBlockHash">上一个区块的hash</param>
        /// <returns></returns>
        public static Block NewBlock(string data, long height, byte[] prevBlockHash)
        {
            //创建区块
            var d = Encoding.Default.GetBytes(data);
            var block = new Block { Height = height, PrevBlockHash = prevBlockHash, Data = d, Timestamp = Utils.GetTimeStamp(), Nonce = 0 };
            // 调用工作量证明的方法并且返回有效的Hash和Nonce
            var pow = ProofOfWork.NewProofOfWork(block);
            var (hash, nonce) = pow.Run();

            block.Hash = hash;
            block.Nonce = nonce;

            return block;
        }


        //2. 单独写一个方法，生成创世区块
        public static Block CreateGenesisBlock(string data)
        {
            return NewBlock(data, 1, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        }
    }
}
