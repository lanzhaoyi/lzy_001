using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace MPS_A1.Utilities
{
    /// <summary>
    /// 串口操作工具类
    /// </summary>
    public class SerialPortUtility
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="objSerialPort"></param>
        /// <returns></returns>
        public static bool Init(ref SerialPort objSerialPort, string portName, int baudRate, int dataBits)
        {
            try
            {
                MpsLog.DebugFormat("串口:{0}开始初始化", portName);
                if (objSerialPort == null)
                    objSerialPort = new SerialPort();
                if (string.IsNullOrEmpty(portName))
                    return false;
                if (baudRate <= 0)
                    return false;
                objSerialPort.PortName = portName;
                objSerialPort.BaudRate = baudRate;
                objSerialPort.StopBits = StopBits.One;//停止位
                objSerialPort.DataBits = dataBits;
                //objSerialPort.DtrEnable = true;
                MpsLog.DebugFormat("串口:{0}初始化完成", portName);
                return true;
            }
            catch (Exception ex)
            {
                MpsLog.ErrorFormat("初始化串口异常，错误信息:{0},堆栈信息:{1}", ex.Message, ex.StackTrace);
            }
            return false;
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="objSerialPort"></param>
        /// <returns></returns>
        public static bool Open(ref SerialPort objSerialPort)
        {
            try
            {
                if (objSerialPort == null)
                    return false;
                if (!objSerialPort.IsOpen)
                {
                    objSerialPort.Open();
                }
                MpsLog.DebugFormat("串口:{0}被打开", objSerialPort.PortName);
                return true;
            }
            catch (Exception ex)
            {
                MpsLog.ErrorFormat("打开串口异常，错误信息:{0},堆栈信息:{1}", ex.Message, ex.StackTrace);
            }
            return false;
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <param name="objSerialPort"></param>
        /// <returns></returns>
        public static bool Close(ref SerialPort objSerialPort)
        {
            try
            {
                if (objSerialPort == null)
                    return false;
                if (objSerialPort.IsOpen)
                {
                    objSerialPort.Close();
                }
                MpsLog.DebugFormat("串口:{0}被关闭", objSerialPort.PortName);
                return true;
            }
            catch (Exception ex)
            {
                MpsLog.ErrorFormat("关闭串口异常，错误信息:{0},堆栈信息:{1}", ex.Message, ex.StackTrace);
            }
            return false;
        }

        /// <summary>
        /// 向串口中发送命令
        /// </summary>
        /// <param name="serialPort">串口对象</param>
        /// <param name="SendData">指令集</param>
        /// <returns></returns>
        public static bool SendCommand(SerialPort objSerialPort, string SendData)
        {
            try
            {
                if (string.IsNullOrEmpty(SendData))
                    return false;
                if (objSerialPort == null)
                    return false;
                if (!objSerialPort.IsOpen)
                    return false;
                MpsLog.DebugFormat("向串口发送数据串:{0}", SendData);
                //将数据写入串口
                byte[] objByteArr = System.Text.Encoding.Default.GetBytes(SendData);
                objSerialPort.Write(objByteArr, 0, objByteArr.Length);
                return true;
            }
            catch (Exception ex)
            {
                MpsLog.ErrorFormat("向串口发送指令异常,错误信息:{0},堆栈信息:{1}", ex.Message, ex.StackTrace);
            }
            return false;
        }

        /// <summary>
        /// 向串口发送命令（16进制）
        /// </summary>
        /// <param name="objSerialPort"></param>
        /// <param name="SendData"></param>
        /// <returns></returns>
        public static bool Send16Command(ref SerialPort objSerialPort, string SendData)
        {
            try
            {
                if (string.IsNullOrEmpty(SendData))
                    return false;
                if (objSerialPort == null)
                    return false;
                if (!objSerialPort.IsOpen)
                    return false;
                MpsLog.DebugFormat("向串口发送数据串:{0}", SendData);
                //将数据写入串口
                byte[] objByteArr = Utilis.strToToHexByte(SendData);
                objSerialPort.Write(objByteArr, 0, objByteArr.Length);
                return true;
            }
            catch (Exception ex)
            {
                MpsLog.ErrorFormat("向串口发送指令异常,错误信息:{0},堆栈信息:{1}", ex.Message, ex.StackTrace);
            }
            return false;
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="objSerialPort"></param>
        /// <param name="SendData"></param>
        /// <returns></returns>
        public static bool Send16Command(SerialPort objSerialPort, byte[] SendData)
        {
            try
            {
                if (objSerialPort == null)
                    return false;
                if (SendData == null)
                    return false;
                if (!objSerialPort.IsOpen)
                    return false;
                MpsLog.DebugFormat("向串口发送数据串:{0}", Utilis.ByteArrayToHexString(SendData));
                // 丢弃缓存区的数据
                objSerialPort.DiscardInBuffer();
                objSerialPort.DiscardOutBuffer();
                // 将数据写入串口
                byte[] objByteArr = SendData;
                objSerialPort.Write(objByteArr, 0, objByteArr.Length);
                return true;
            }
            catch (Exception ex)
            {
                MpsLog.ErrorFormat("向串口发送指令异常,错误信息:{0},堆栈信息:{1}", ex.Message, ex.StackTrace);
            }
            return false;
        }
    }
}
