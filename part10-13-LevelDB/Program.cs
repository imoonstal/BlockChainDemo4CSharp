using LevelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part10_13_LevelDB
{
    class Program
    {
        static readonly string path = Environment.CurrentDirectory + "\\";
        static void Main(string[] args)
        {
            var db = DB.Open(path + "mydb", new Options { CreateIfMissing = true });
            db.Put(WriteOptions.Default, "l", "send 100BTC to me");
            var value = db.Get(ReadOptions.Default, "l");
            Console.WriteLine(value);

            Console.ReadLine();
        }
    }
}
