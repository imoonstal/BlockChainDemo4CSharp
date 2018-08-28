using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part21_23_cil
{
    /// <summary>
    /// 命令行参数解析类
    /// 没找到好用的CommandLine的解析工具，自己动手随便写一个简单的解析工具类。
    /// </summary>
    class CliParser
    {
        //命令列表
        static List<string> cmds = new List<string>();
        //参数列表
        static List<string> argList;
        //key是命令名称，value是包含命令本身的所有参数
        static Dictionary<string, List<string>> cmdObj = new Dictionary<string, List<string>>();

        static void PrintUsage()
        {
            Console.WriteLine("Usage:");
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

        /// <summary>
        /// 初始化命令
        /// </summary>
        /// <param name="args"></param>
        public static void InitCmd(string[] args)
        {
            argList = args.ToList();
            var list = new List<CmdIndex>();
            cmds.ForEach(cmd =>
            {
                var n = argList.IndexOf(cmd);
                if (n >= 0)
                    list.Add(new CmdIndex { Cmd = cmd, Index = n });
            });
            list.Sort();
            for (int i = 0; i < list.Count; i++)
            {
                List<string> subCmds;
                if (i != list.Count - 1)
                    subCmds = argList.Skip(list[i].Index).Take(list[i + 1].Index - list[i].Index).ToList();
                else
                    subCmds = argList.Skip(list[i].Index).Take(argList.Count - list[i].Index).ToList();
                cmdObj.Add(list[i].Cmd, subCmds);
            }
        }
        /// <summary>
        /// 注册需要的命令
        /// </summary>
        /// <param name="cmd"></param>
        public static void Register(string cmd)
        {
            if (!cmds.Contains(cmd))
                cmds.Add(cmd);
        }
        /// <summary>
        /// 反注册命令
        /// </summary>
        /// <param name="cmd"></param>
        public static void UnRegister(string cmd)
        {
            if (cmds.Contains(cmd))
                cmds.Remove(cmd);
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static object Parse(string cmd)
        {
            if (!cmdObj.ContainsKey(cmd))
                return "";
            switch (cmd)
            {
                case "addblock":
                    return Parse_addblock(cmdObj[cmd]);
                case "printchain":
                    return Parse_printchain(cmdObj[cmd]);
                default:
                    return "";
            }
        }

        #region 命令解析方法
        /// <summary>
        /// addblock命令解析方法
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        static object Parse_addblock(List<string> param)
        {
            if (param.Count > 2)
                return param[2];
            else
                return "";
        }

        /// <summary>
        /// printchain命令解析方法
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        static object Parse_printchain(List<string> param)
        {
            if (param.Count > 1)
                return param[1];
            else
                return "";
        }
        #endregion
    }

    class CmdIndex : IComparable
    {
        public string Cmd { get; set; }
        public int Index { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (obj is CmdIndex other)
                return Index.CompareTo(other.Index);
            else
                throw new ArgumentException("Object is not a CmdIndex");
        }
    }
}
