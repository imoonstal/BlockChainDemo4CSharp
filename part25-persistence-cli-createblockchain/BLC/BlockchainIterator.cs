using LevelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLC
{
    class BlockchainIterator
    {
        public byte[] CurrentHash { get; set; }
        public DB Db { get; set; }

        public BlockchainIterator(Blockchain bc)
        {
            this.CurrentHash = bc.Tip;
            this.Db = bc.Db;
        }

        public Block Next()
        {
            Block block = null;
            //1.查询数据库，得到当前block的数据
            var currentBlockBytes = this.Db.Get(ReadOptions.Default, CurrentHash).ToArray();
            //2.反序列化得到block
            block = Block.DeserializeBlock(currentBlockBytes);
            //3.当前区块的PreHash赋值给CurrentHash
            this.CurrentHash = block.PrevBlockHash;
            return block;
        }
    }
}
