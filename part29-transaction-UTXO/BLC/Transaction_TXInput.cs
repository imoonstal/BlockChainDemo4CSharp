using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLC
{
    [Serializable]
    class TXInput
    {
        // 1. 交易的Hash
        public byte[] TxHash { get; set; }
        // 2. 存储TXOutput在Vout里面的索引
        public int Vout { get; set; }
        // 3. 用户名
        public string ScriptSig { get; set; }// 花费的是谁的钱
    }
}
