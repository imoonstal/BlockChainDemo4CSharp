using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace part15_persistence_creategenesisblock.BLC
{
    class ProofOfWork
    {
        public Block Block { get; set; }
        public BigInteger Target { get; set; }


        //0000 0000 0000 0000 1001 0001 0000 .... 0001

        // 256位Hash里面前面至少要有16个零
        const int targetBit = 8;

        //创建新的工作量证明对象
        public ProofOfWork(Block block)
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

            this.Block = block;
            this.Target = target;
        }

        // 数据拼接，返回字节数组
        private byte[] PrepareData(int nonce) {
            //var length = this.Block.PrevBlockHash.Length +
            //    this.Block.Data.Length +
            //    Utils.IntToHex(this.Block.Timestamp).Length +
            //    Utils.IntToHex(targetBit).Length +
            //    Utils.IntToHex(nonce).Length +
            //    Utils.IntToHex(this.Block.Height).Length;
            //var data = new byte[length];
            //data = this.Block.PrevBlockHash
            //    .Concat(this.Block.Data)
            //    .Concat(Utils.IntToHex(this.Block.Timestamp))
            //    .Concat(Utils.IntToHex(targetBit))
            //    .Concat(Utils.IntToHex(nonce))
            //    .Concat(Utils.IntToHex(this.Block.Height))
            //    .ToArray();
            var data = Utils.JoinByteArray(
                this.Block.PrevBlockHash,
                this.Block.Data,
                Utils.IntToHex(this.Block.Timestamp),
                Utils.IntToHex(targetBit),
                Utils.IntToHex(nonce),
                Utils.IntToHex(this.Block.Height));
            return data;
        }

        public bool IsValid()
        {

            //1.proofOfWork.Block.Hash
            //2.proofOfWork.Target


            // []byte 转 Int
            var hashStr = Utils.SHA256byteArr2String(this.Block.Hash);
            var hashInt = BigInteger.Parse("0" + hashStr, NumberStyles.AllowHexSpecifier);

            if (hashInt < this.Target)
            {
                return true;
            }
            return false;
        }

    public (byte[] hash, long nonce) Run()
        {
            //1. 将Block的属性拼接成字节数组
            //2. 生成hash
            //3. 判断hash有效性，如果满足条件，跳出循环
            var nonce = 0;

            BigInteger hashInt; // 存储我们新生成的hash
            byte[] hash;
            while (true)
            {
                //准备数据
                var dataBytes = PrepareData(nonce);
                // 生成hash
                hash = Utils.Sum256(dataBytes);
                //fmt.Printf("\r%x", hash)
                var hashStr = Utils.SHA256byteArr2String(hash);
                Console.Write(hashStr + "\r");
                // 将hash存储到hashInt
                hashInt = BigInteger.Parse("0" + hashStr, NumberStyles.AllowHexSpecifier);
                //hashInt = new BigInteger(hash);//TODO:这个为什么老是负的
                //判断hashInt是否小于Block里面的target
                if (hashInt < this.Target)
                {
                    Console.WriteLine(hashStr);
                    break;
                }
                nonce = nonce + 1;
            }
            return (hash, nonce);
        }



        // 创建新的工作量证明对象
        //public static ProofOfWork NewProofOfWork(Block block)
        //{
        //    //1.big.Int对象 1
        //    // 2
        //    //0000 0001
        //    // 8 - 2 = 6
        //    // 0100 0000  64
        //    // 0010 0000
        //    // 0000 0000 0000 0001 0000 0000 0000 0000 0000 0000 .... 0000

        //    //1. 创建一个初始值为1的target
        //    var target = new BigInteger(1);
        //    //2. 左移256 - targetBit
        //    target = target << 256 - targetBit;

        //    return new ProofOfWork { Block = block, Target = target };
        //}
    }
}
