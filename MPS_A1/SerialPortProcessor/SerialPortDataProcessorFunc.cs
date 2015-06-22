using MPS_A1.FormFunc;
using MPS_A1.Utilities;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace MPS_A1.SerialPortProcessor
{
    /// <summary>
    /// 串口回调委托声明
    /// </summary>
    /// <param name="datas"></param>
    /// <param name="result"></param>
    public delegate void DataReviceProcessor(string datas, bool result);

    /// <summary>
    /// 串口数据处理
    /// </summary>
    public class SerialPortDataProcessorFunc
    {
        #region ======串口回调声明======
        /// <summary>
        /// 移动固定距离回调
        /// </summary>
        public static DataReviceProcessor MoveFixedPositionDataReviceProcessor;

        #endregion

        #region ======队列数据对象声明======

        #endregion

        #region ======串口队列处理==========
        /// <summary>
        /// 取串口命令队列将命令发送给串口
        /// </summary>
        public void TestCmdQueueProcessor()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                // 取得队列中的命令
                QueueDataObj obj = SerialPortCmdQueueFunc.CmdDequeue();
                if (obj == null)
                    continue;
                bool result = SerialPortUtility.SendCommand(GlobalInfo.g_SerialPort, obj.cmd);
                if (!result)
                {
                    MpsLog.ErrorFormat("发送命令失败,命令:{0}", obj.cmd);
                    continue;
                }
            }
        }
        #endregion

        #region ====返回数据处理====
        /// <summary>
        /// 串口返回数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort objSerialPort = null;
            try
            {
                objSerialPort = (SerialPort)sender;
                int n = objSerialPort.BytesToRead;
                byte[] objByte = new byte[n];
                objSerialPort.Read(objByte, 0, n);
                string strAllData = System.Text.Encoding.Default.GetString(objByte);
                MpsLog.DebugFormat("串口返回数据串:{0}", strAllData);

                // 此部分要写代码将保证数据完整性

                // 这只是个例子
                PartitionDataReceivedProcessor(eSerialPortDataReviceStatus.MoveFixedPosition, strAllData);


            }
            catch (Exception ex)
            {
                MpsLog.ErrorFormat("串口返回数据异常，错误信息{0}，堆栈信息{1}", ex.Message, ex.StackTrace);
            }
        }

        /// <summary>
        /// 分拆返回数据处理
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="dataArray"></param>
        public static void PartitionDataReceivedProcessor(eSerialPortDataReviceStatus dataType, string datas)
        {
            switch (dataType)
            {
                case eSerialPortDataReviceStatus.MoveFixedPosition:
                    MoveFixedPositionProcessor(datas);
                    break;

            }
        }

        /// <summary>
        /// 移动固定距离
        /// </summary>
        /// <param name="dataArray"></param>
        private static void MoveFixedPositionProcessor(string datas)
        {
            if (GlobalInfo.g_MachineOperateType == eMachineOperateType.MoveFixedPosition)
            {
                MoveFixedPositionDataReviceProcessor(datas, true);
            }
            // 如果有多个地方使用同一个移动固定距离的命令，可以定义多个委托

        }
        #endregion
    }
}
