using MPS_A1.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPS_A1.SerialPortProcessor
{
    /// <summary>
    /// 窗口命令队列
    /// </summary>
    public class SerialPortCmdQueueFunc
    {
        /// <summary>
        /// 初始化队列
        /// </summary>
        public static Queue CmdQueue = new Queue(100, 2);

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool CmdEnqueue(QueueDataObj obj)
        {
            try
            {
                if (obj == null)
                    return false;
                CmdQueue.Enqueue(obj);
                return true;
            }
            catch (Exception ex)
            {
                MpsLog.ErrorFormat("入队异常,错误信息:{0},堆栈信息:{1}", ex.Message, ex.StackTrace);
            }
            return false;
        }

        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        public static QueueDataObj CmdDequeue()
        {
            try
            {
                if (CmdQueue.Count <= 0)
                    return null;
                QueueDataObj obj = (QueueDataObj)CmdQueue.Dequeue();
                return obj;
            }
            catch (Exception ex)
            {
                MpsLog.ErrorFormat("出队异常,错误信息:{0},堆栈信息:{1}", ex.Message, ex.StackTrace);
            }
            return null;
        }
    }
}
