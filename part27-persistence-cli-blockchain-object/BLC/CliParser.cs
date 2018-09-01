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
            Console.WriteLine("\tcreateblockchain -data DATA -- 交易数据.");
            Console.WriteLine("\taddblock -data DATA -- 交易数据.");
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
        /// addblock命令解析方法
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string Parse_addblock(string[] param)
        {
            try
            {
                if (param.Length > 2)
                    if (param[1] == "-data")
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
                    if (param[1] == "-data")
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
