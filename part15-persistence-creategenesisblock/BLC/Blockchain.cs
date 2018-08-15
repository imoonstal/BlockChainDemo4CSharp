using LevelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part15_persistence_creategenesisblock.BLC
{
    /// <summary>
    /// 区块链 类
    /// </summary>
    class Blockchain
    {
        /// <summary>
        /// 区块链的区块列表
        /// </summary>
        //public List<Block> Blocks { get; set; }

        /// <summary>
        /// 最新区块hash
        /// </summary>
        public byte[] Tip { get; set; }

        /// <summary>
        /// 存储区块链的数据库
        /// </summary>
        public DB Db { get; set; }

        public Blockchain()
        {
            // 创建创世区块
            //var genesisBlock = Block.CreateGenesisBlock("Genesis Data.......");
            var genesisBlock = new Block("Genesis Data.......");

            //如果数据库不存在就创建库，有就返回当前库
            var db = DB.Open(Utils.CurrentPath + Utils.DbName, new Options { CreateIfMissing = true });
            db.Put(WriteOptions.Default, genesisBlock.Hash, genesisBlock.SerializeBlock());
            db.Put(WriteOptions.Default, Utils.CurrentKeyName, genesisBlock.Hash);

            this.Tip = genesisBlock.Hash;
            this.Db = db;

        }


        //重写ToString()方法，为了打印结果方便
        //public override string ToString()
        //{
            
        //}



        //1. 创建带有创世区块的区块链

        //public static Blockchain CreateBlockchainWithGenesisBlock()
        //{
        //    // 创建创世区块
        //    //var genesisBlock = Block.CreateGenesisBlock("Genesis Data.......");
        //    var genesisBlock =new Block("Genesis Data.......");

        //    //如果数据库不存在就创建库，有就返回当前库
        //    var db = DB.Open(Utils.CurrentPath + Utils.DbName, new Options { CreateIfMissing = true });
        //    db.Put(WriteOptions.Default, genesisBlock.Hash, genesisBlock.SerializeBlock());
        //    db.Put(WriteOptions.Default, Utils.CurrentKeyName, genesisBlock.Hash);

        //    // 返回区块链对象
        //    return new Blockchain { Tip = genesisBlock.Hash, Db = db };

        //}
    }
}
