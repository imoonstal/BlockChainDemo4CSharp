using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLC
{
    [Serializable]
    class TXOutput
    {
        //支出的钱的数量
        public long Value { get; set; }
        //钱给了谁，如果钱给出去有找零，那么找零的钱就给自己
        public string ScriptPubKey { get; set; }
    }
}
