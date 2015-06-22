using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPS_A1.SerialPortProcessor
{
    /// <summary>
    /// 串口命令获取
    /// </summary>
    public class CmdFunc
    {
        /// <summary>
        /// 设置加速距离（设置加速距离为1周或200步）
        /// </summary>
        /// <param name="length">步数</param>
        /// <returns></returns>
        public static string SetQuickenPosition(long length)
        {
            string cmd = string.Empty;
            cmd = string.Format("0A({0})", length.ToString().PadLeft(8, '0'));
            return cmd;
        }

        /// <summary>
        /// 移动固定距离
        /// </summary>
        /// <param name="direction">方向</param>
        /// <param name="length">距离</param>
        /// <returns></returns>
        public static string MoveFixedPosition(int direction,long length)
        {
            string cmd = string.Empty;
            cmd = string.Format("0P({0},{1})", direction, length.ToString().PadLeft(8,'0'));
            return cmd;
        }

        /// <summary>
        /// 查询状态
        /// </summary>
        /// <param name="statusCode">状态码</param>
        /// <returns></returns>
        public static string SearchStatus(int statusCode)
        {
            string cmd = string.Empty;
            cmd = string.Format("0C({0})", statusCode);
            return cmd;
        }
    }
}
