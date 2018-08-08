using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part3_Basic_Prototype.BLC
{
    /// <summary>
    /// 区块链 类
    /// </summary>
    class Blockchain
    {
        /// <summary>
        /// 区块链的区块列表
        /// </summary>
        public List<Block> Blocks { get; set; }

        //重写ToString()方法，为了打印结果方便
        public override string ToString()
        {
            var result = string.Empty;
            if (this.Blocks.Count > 0)
            {
                Blocks.ForEach(b => result += $" {b}");
                return result;
            }
            return "This Block is null";
        }

        //1. 创建带有创世区块的区块链
        public static Blockchain CreateBlockchainWithGenesisBlock()
        {
            // 创建创世区块
            var genesisBlock = Block.CreateGenesisBlock("Genesis Data.......");
            // 返回区块链对象
            return new Blockchain { Blocks = new List<Block> { genesisBlock } };

        }
    }
}
