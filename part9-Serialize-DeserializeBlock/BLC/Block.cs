using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace part9_Serialize_DeserializeBlock.BLC
{
    /// <summary>
    /// 区块类
    /// </summary>
    [Serializable]//标记为可序列化
    class Block
    {
        #region 区块结构
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

        //1.生成一个新区块
        /// <summary>
        /// 生成一个新区块
        /// </summary>
        /// <param name="data">交易数据</param>
        /// <param name="height">区块的高度</param>
        /// <param name="prevBlockHash">上一个区块的hash</param>
        /// <returns></returns>
        public Block(string data, long height, byte[] prevBlockHash)
        {
            //创建区块
            Height = height;
            PrevBlockHash = prevBlockHash;
            Data = Encoding.Default.GetBytes(data);
            Timestamp = Utils.GetTimeStamp();
            Nonce = 0;
            // 调用工作量证明的方法并且返回有效的Hash和Nonce
            var pow = new ProofOfWork(this);
            var (hash, nonce) = pow.Run();

            this.Hash = hash;
            this.Nonce = nonce;
        }

        //2. 生成创世区块
        /// <summary>
        /// 生成创世区块
        /// </summary>
        /// <param name="data"></param>
        public Block(string data):this(data, 1, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 })
        {
        }


        /// <summary>
        /// 重写Block的ToString方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "{" + $"{this.Height} {Utils.PrintArray(this.PrevBlockHash)} {Utils.PrintArray(this.Data)} {this.Timestamp} {Utils.PrintArray(this.Hash)} {this.Nonce}" + "}";
        }

        /// <summary> 
        /// 将一个block对象序列化，返回一个byte[]         
        /// </summary> 
        /// <param name="obj">能序列化的对象</param>         
        /// <returns></returns> 
        public byte[] SerializeBlock()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                return ms.GetBuffer();
            }
        }

        /// <summary> 
        /// 将一个序列化后的byte[]数组还原为Bolck对象       
        /// </summary>
        /// <param name="Bytes"></param>         
        /// <returns></returns> 
        public static Block DeserializeBlock(byte[] Bytes)
        {
            using (MemoryStream ms = new MemoryStream(Bytes))
            {
                IFormatter formatter = new BinaryFormatter();
                return (Block)formatter.Deserialize(ms);
            }
        }

    }
}
