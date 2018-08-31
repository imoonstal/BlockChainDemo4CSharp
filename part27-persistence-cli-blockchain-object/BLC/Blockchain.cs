using LevelDB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BLC
{
    /// <summary>
    /// 区块链 类
    /// </summary>
    class Blockchain
    {
        /// <summary>
        /// 最新区块hash
        /// </summary>
        public byte[] Tip { get; set; }

        /// <summary>
        /// 存储区块链的数据库
        /// </summary>
        public DB Db { get; set; }

        /// <summary>
        /// 区块链构造函数
        /// </summary>
        public Blockchain()
        {
            DB db = null;
            try
            {
                db = DB.Open(Utils.CurrentPath + Utils.DbName, new Options { CreateIfMissing = true });
                var hash = db.Get(ReadOptions.Default, Utils.CurrentKeyName).ToArray();
                this.Tip = hash;
                this.Db = db;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"获取区块链对象失败:{ex.Message}");
            }
        }


        /// <summary>
        /// 创建创世区块
        /// </summary>
        /// <param name="data">区块数据</param>
        public static void CreateGenesisBlock(string data)
        {
            DB db = null;
            try
            {
                //如果数据库存在，就说明创世区块已存在.获取当前区块数据，并返回
                if (Utils.DbExists)
                {
                    Console.WriteLine("创世区块已经存在......");
                    Environment.Exit(0);
                }

                Console.WriteLine("正在创建创世区块.......");

                // 创建创世区块
                var genesisBlock = new Block(data);

                //如果数据库不存在就创建库，有就返回当前库
                db = DB.Open(Utils.CurrentPath + Utils.DbName, new Options { CreateIfMissing = true });
                db.Put(WriteOptions.Default, genesisBlock.Hash, genesisBlock.SerializeBlock());
                db.Put(WriteOptions.Default, Utils.CurrentKeyName, genesisBlock.Hash);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"创建区块链失败,{ex.Message}");
            }
            finally
            {
                if (null != db)
                    db.Dispose();
            }
        }

        

        /// <summary>
        /// 增加区块到区块链里面
        /// </summary>
        /// <param name="data"></param>
        public void AddBlockToBlockchain(string data)
        {
            try
            {
                //1. 获取表
                var db = this.Db;
                //2. 创建新区块

                // ⚠️，先获取最新区块
                var blockBytes = db.Get(ReadOptions.Default, this.Tip).ToArray();
                // 反序列化
                var block = Block.DeserializeBlock(blockBytes);
                //3. 将区块序列化并且存储到数据库中
                var newBlock = new Block(data, block.Height + 1, block.Hash);
                db.Put(WriteOptions.Default, newBlock.Hash, newBlock.SerializeBlock());
                //4. 更新数据库里面"l"对应的hash
                db.Put(WriteOptions.Default, Utils.CurrentKeyName, newBlock.Hash);
                //5. 更新blockchain的Tip
                this.Tip = newBlock.Hash;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AddBlockToBlockchain:添加区块失败,{ex.Message}");
            }
        }

        // 遍历输出所有区块的信息
        public void Printchain()
        {
            var iterator = new BlockchainIterator(this);
            while (true)
            {
                var block = iterator.Next();
                Console.WriteLine(block);
                //获取当前块的PreHash的bigint值
                var hashStr = Utils.SHA256byteArr2String(block.PrevBlockHash);
                var hashInt = BigInteger.Parse("0" + hashStr, NumberStyles.AllowHexSpecifier);
                if (hashInt == 0)
                    break;
            }
        }
    }
}
