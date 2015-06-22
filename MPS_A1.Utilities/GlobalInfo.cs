using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace MPS_A1.Utilities
{
    /// <summary>
    /// 全局变量定义
    /// </summary>
    public class GlobalInfo
    {
        /// <summary>
        /// bin根目录
        /// </summary>
        public static string g_RootPath = string.Empty;
        /// <summary>
        /// 数据库文件名key
        /// </summary>
        public static string g_DbName = "DBMPS.accdb";
        /// <summary>
        /// 数据库全路径
        /// </summary>
        public static string g_DbFullPath = "";
        /// <summary>
        /// 全局串口对象
        /// </summary>
        public static SerialPort g_SerialPort = new SerialPort();

        /// <summary>
        /// 当前仪器操作的类型
        /// </summary>
        public static eMachineOperateType g_MachineOperateType = eMachineOperateType.Ready;
    }
}
