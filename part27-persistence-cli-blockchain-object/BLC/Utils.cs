﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLC
{
    sealed class Utils
    {
        /// <summary>
        /// 获取当前路径
        /// </summary>
        public static readonly string CurrentPath = Environment.CurrentDirectory + "\\";

        /// <summary>
        /// 数据库名字
        /// </summary>
        public const string DbName = "blockchain";

        /// <summary>
        /// 数据库存储当前区块hash值的key名字
        /// </summary>
        public const string CurrentKeyName = "currentKey";

        /// <summary>
        /// 数据库是否存在
        /// </summary>
        /// <returns></returns>
        public static bool DbExists
        {
            get
            {
                return Directory.Exists(CurrentPath + DbName);
            }
        }


        /// <summary>
        /// 将 int64 转换成字节数组。
        /// 与Golang中的转换反了，所有反转了一下。
        /// </summary>
        /// <param name="num">int64</param>
        /// <returns></returns>
        public static byte[] IntToHex(long num)
        {
            return BitConverter.GetBytes(num).Reverse().ToArray();
        }

        /// <summary>
        /// 获取一个byte[]的SHA256的值
        /// </summary>
        /// <param name="bytValue"></param>
        /// <returns></returns>
        public static byte[] Sum256(byte[] bytValue)
        {
            try
            {
                SHA256 sha256 = new SHA256CryptoServiceProvider();
                return sha256.ComputeHash(bytValue);
            }
            catch (Exception ex)
            {
                throw new Exception("计算hash256错误:" + ex.Message);
            }
        }

        /// <summary>
        /// SHA256生成的32位byte[]转换成字符串
        /// </summary>
        /// <param name="byteArr"></param>
        /// <returns></returns>
        public static string SHA256byteArr2String(byte[] byteArr)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < byteArr.Length; i++)
            {
                sb.Append(byteArr[i].ToString("x2"));
            }
            return sb.ToString();

        }

        /// <summary>  
        /// 获取时间戳  10位
        /// </summary>  
        /// <returns></returns>  
        public static long GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            //return Convert.ToInt64(ts.TotalSeconds * 1000);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        /// <summary>
        /// 将时间戳转换为日期类型，并格式化
        /// </summary>
        /// <param name="unixDate"></param>
        /// <returns></returns>
        public static DateTime Timestamp2DateTime(long unixDate)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return start.AddMilliseconds(unixDate * 1000).ToLocalTime();
        }


        public static string Timestamp2String(long unixData)
        {
            return Timestamp2DateTime(unixData).ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 获取数组的打印结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string PrintArray<T>(T[] array)
        {
            if (null == array)
                return "null";
            var result = "[";
            foreach (var item in array)
            {
                result += item + " ";
            }
            result = result.TrimEnd(' ');
            result += "]";
            return result;
        }

        /// <summary>
        /// 连接byte[]
        /// </summary>
        /// <param name="arrs"></param>
        /// <returns></returns>
        public static byte[] JoinByteArray(params byte[][] arrs)
        {
            if (null == arrs || arrs.Length == 0)
                return null;
            var len = 0;
            for (int i = 0; i < arrs.Length; i++)
            {
                len += arrs[i].Length;
            }
            var result = arrs[0].AsEnumerable();
            for (int i = 1; i < arrs.Length; i++)
            {
                result = result.Concat(arrs[i]);
            }
            return result.ToArray();
        }

        
    }
}
