using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPS_A1.Utilities
{
    public class Utilis
    {
        /// <summary>
        /// 字符串转16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        /// <summary>
        /// 字节数组转为十六进制字符串
        /// </summary>
        /// <param name="data">传入要转换的字节数组</param>
        /// <returns>返回转换后字符串的大写</returns>
        public static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ByteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                    returnStr += " ";
                }
            }
            return returnStr;
        }

        /// <summary>   
        /// 汉字转拼音缩写（首字母）   
        /// </summary>/// <param name="str">要转换的汉字字符串</param>   
        /// /// <returns>拼音缩写</returns>   
        public static string GetPYString(string str)
        {
            string tempStr = "";
            foreach (char c in str)
            {
                if ((int)c >= 33 && (int)c <= 126)
                {//字母和符号原样保留              
                    tempStr += c.ToString();
                }
                else
                {//累加拼音声母        
                    tempStr += GetPYChar(c.ToString());
                }
            }
            return tempStr;
        }

        /// <summary>
        /// 取单个字符的拼音声母
        /// </summary>
        /// <param name="c">要转换的单个汉字</param>
        /// <returns>拼音声母</returns>
        public static string GetPYChar(string c)
        {
            byte[] array = new byte[2];
            array = System.Text.Encoding.Default.GetBytes(c);
            int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));
            if (i < 0xB0A1) return "*";
            if (i < 0xB0C5) return "a";
            if (i < 0xB2C1) return "b";
            if (i < 0xB4EE) return "c";
            if (i < 0xB6EA) return "d";
            if (i < 0xB7A2) return "e";
            if (i < 0xB8C1) return "f";
            if (i < 0xB9FE) return "g";
            if (i < 0xBBF7) return "h";
            if (i < 0xBFA6) return "g";
            if (i < 0xC0AC) return "k";
            if (i < 0xC2E8) return "l";
            if (i < 0xC4C3) return "m";
            if (i < 0xC5B6) return "n";
            if (i < 0xC5BE) return "o";
            if (i < 0xC6DA) return "p";
            if (i < 0xC8BB) return "q";
            if (i < 0xC8F6) return "r";
            if (i < 0xCBFA) return "s";
            if (i < 0xCDDA) return "t";
            if (i < 0xCEF4) return "w";
            if (i < 0xD1B9) return "x";
            if (i < 0xD4D1) return "y";
            if (i < 0xD7FA) return "z";
            return "*";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringList"></param>
        /// <returns></returns>
        public static string ConvertListToString(List<string> stringList)
        {
            StringBuilder strB = new StringBuilder();
            if (stringList != null)
            {
                int index = 0;
                foreach (string str in stringList)
                {
                    if (index > 0)
                    {
                        strB.Append(",");
                    }
                    strB.Append(str);
                    index++;
                }
            }
            return strB.ToString();
        }

        /// <summary>
        /// 将float转十六进制byte
        /// </summary>
        /// <param name="floatValue"></param>
        /// <returns></returns>
        public static byte[] ConvertFloatTo16Bytes(float floatValue)
        {
            byte[] bytes = BitConverter.GetBytes(floatValue);
            return bytes;

        }

        /// <summary>
        /// 将float转16进制字符串
        /// </summary>
        /// <param name="floatValue"></param>
        /// <returns></returns>
        public static string ConvertFloatTo16String(float floatValue)
        {
            byte[] bytes = BitConverter.GetBytes(floatValue);
            return BitConverter.ToString(bytes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static float Convert16StringToFloat(string hex)
        {

            byte[] bs = new byte[hex.Length];
            for (int i = 0; i < bs.Length; i++)
                bs[i] = byte.Parse(hex[0] + hex[1].ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
            float f = BitConverter.ToSingle(bs, 0);

            return f;
            //MatchCollection matches = Regex.Matches(hex, @"[0-9A-Fa-f]{2}");
            //byte[] bytes = new byte[matches.Count];
            //for (int i = 0; i < bytes.Length; i++)
            //    bytes[i] = byte.Parse(matches[i].Value, NumberStyles.AllowHexSpecifier);
            //return BitConverter.ToSingle(bytes, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static decimal SumX(List<decimal> x)
        {
            decimal sum = 0;
            for (int i = 0; i < x.Count; i++)
            {
                sum += x[i];
            }
            return sum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static decimal SumXY(List<decimal> x, List<decimal> y)
        {
            decimal sum = 0;
            for (int i = 0; i < x.Count; i++)
            {
                sum += (x[i] * y[i]);
            }
            return sum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static decimal SumXPow(List<decimal> x)
        {
            decimal sum = 0;
            for (int i = 0; i < x.Count; i++)
            {
                sum += (x[i] * x[i]);
            }
            return sum;
        }
    }
}
