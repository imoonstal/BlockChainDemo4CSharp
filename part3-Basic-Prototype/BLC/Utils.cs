using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace part3_Basic_Prototype.BLC
{
    class Utils
    {
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
        /// 获取数组的打印结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string PrintArray<T>(T[] array)
        {
            var result = "[";
            foreach (var item in array)
            {
                result += item + " ";
            }
            result = result.TrimEnd(' ');
            result += "]";
            return result;
        }
    }
}
