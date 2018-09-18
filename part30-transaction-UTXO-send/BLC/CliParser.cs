using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLC
{
    /// <summary>
    /// 命令行参数解析类
    /// </summary>
    sealed class CliParser
    {
        public static void PrintUsage()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("\tcreateblockchain -address DATA -- 交易地址.");
            Console.WriteLine("\tsend -from FROM -to TO -amount AMOUNT -- 交易明细.");
            Console.WriteLine("\tprintchain -- 输出区块信息.");
        }

        public static void IsValidArgs(string[] args)
        {
            if (args.Length < 1)
            {
                PrintUsage();
                Environment.Exit(0);
            }
        }

        #region 命令解析方法
        /// <summary>
        /// send命令解析方法
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static Transaction[] Parse_addblock(string[] param)
        {
            try
            {
                if (param.Length == 7 &&
                     param[1]=="-from" &&
                     param[3]=="-to" &&
                     param[5]=="-amount" &&
                     !string.IsNullOrWhiteSpace(param[2])&&
                     !string.IsNullOrWhiteSpace(param[4]) &&
                     !string.IsNullOrWhiteSpace(param[6]))
                {
                    Console.WriteLine(param[2]);
                    Console.WriteLine(param[4]);
                    Console.WriteLine(param[6]);
                    return new Transaction[] { };
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// printchain命令解析方法
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static bool Parse_printchain(string[] param)
        {
            try
            {
                return param[0] == "printchain";
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// createblockchain命令解析方法
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string Parse_createblockchain(string[] param)
        {
            try
            {
                if (param.Length > 2)
                    if (param[1] == "-address")
                        return param[2];
                    else
                        return string.Empty;
                else
                    return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
        #endregion
    }
}
