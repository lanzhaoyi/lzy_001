using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPS_A1.Utilities;

namespace MPS_A1.SerialPortProcessor
{
    /// <summary>
    /// 队列对象
    /// </summary>
    public class QueueDataObj
    {
        /// <summary>
        /// 命令类型
        /// </summary>
        public eSendCmdType sendCmdType { get; set; }

        /// <summary>
        /// 命令
        /// </summary>
        public string cmd { get; set; }
    }
}
