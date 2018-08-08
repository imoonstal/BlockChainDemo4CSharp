using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part1_Basic_Prototype.BLC
{
    class Block
    {
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

        /// <summary>
        /// 计算区块的hash
        /// </summary>
        public void SetHash()
        {
            //	1. Height []byte
            var heightBytes = Utils.IntToHex(this.Height);
            Console.WriteLine(Utils.PrintArray(heightBytes));
            //  2. 将时间戳转[]byte
            // 2 ~ 36
            // 1528097970
            var timeString = Convert.ToString(this.Timestamp, 2);
            Console.WriteLine(timeString);

            var timeBytes = Encoding.Default.GetBytes(timeString);
            Console.WriteLine(Utils.PrintArray(timeBytes));

            //  3. 拼接所有属性
            var length = heightBytes.Length + this.PrevBlockHash.Length + this.Data.Length + timeBytes.Length;
            var blockBytes = new byte[length];
            blockBytes = heightBytes.Concat(this.PrevBlockHash).Concat(this.Data).Concat(timeBytes).ToArray();
            // 4. 生成Hash
            this.Hash = Utils.Sum256(blockBytes);
        }

        /// <summary>
        /// 重写Block的ToString方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "{" + $"{this.Height} {Utils.PrintArray(this.PrevBlockHash)} {Utils.PrintArray(this.Data)} {this.Timestamp} {Utils.PrintArray(this.Hash)}" + "}";
        }


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
            var block = new Block { Height = height, PrevBlockHash = prevBlockHash, Data = d, Timestamp = Utils.GetTimeStamp()};
            //设置Hash
            block.SetHash();
            return block;
        }

        
    }
}
