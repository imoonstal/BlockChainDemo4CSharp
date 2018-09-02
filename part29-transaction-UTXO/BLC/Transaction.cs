using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BLC
{
    [Serializable]
    class Transaction
    {
        //1. 交易hash
        public byte[] TxHash { get; set; }

        //2. 输入
        public TXInput[] Vins { get; set; }

        //3. 输出
        public TXOutput[] Vouts { get; set; }

        //Transaction 创建分两种情况
        //1.创世区块创建时的Coinbase Transaction
        //2. 转账时产生的Transaction

        /// <summary>
        /// 创世区块创建时的Transaction，是个coinbase Transaction
        /// </summary>
        /// <param name="address"></param>
        public Transaction(string address)
        {
            var txInput = new TXInput { TxHash = new byte[] { }, Vout = -1, ScriptSig = "Genesis Data" };
            var txOutput = new TXOutput { Value = 10, ScriptPubKey = address };
            this.Vins = new TXInput[] { txInput };
            this.Vouts = new TXOutput[] { txOutput };
            this.TxHash = new byte[] { };
            this.HashTransaction();
        }

        /// <summary>
        /// 序列化Transaction，并且计算SHA256
        /// </summary>
        private void HashTransaction()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                this.TxHash = Utils.Sum256(ms.GetBuffer());
            }
        }
    }
}
