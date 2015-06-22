using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MPS_A1.CommonUtility
{
    public class MPS_API
    {
        /// <summary>
        /// 打开设备
        /// </summary>
        /// <param name="DeviceNumber">设备编号（0-9，默认0）</param>
        /// <returns></returns>
        [DllImport("MPS-080102.dll", EntryPoint = "MPS_OpenDevice", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MPS_OpenDevice(int DeviceNumber);

        /// <summary>
        /// 获取设备硬件信息的功能
        /// </summary>
        /// <param name="InfoString"></param>
        /// <param name="DeviceHandle"></param>
        /// <returns></returns>
        [DllImport("MPS-080102.dll", EntryPoint = "MPS_GetInformation", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public extern static int MPS_GetInformation(IntPtr InfoString, int DeviceHandle);

        /// <summary>
        /// 设定设备参数
        /// </summary>
        /// <param name="ADCSampleRate">信号采集采样率</param>
        /// <param name="DeviceHandle">设备句柄</param>
        /// <returns></returns>
        [DllImport("MPS-080102.dll", EntryPoint = "MPS_Configure", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public extern static Int32 MPS_Configure(Int32 ADCSampleRate, int DeviceHandle);


        [DllImport("MPS-080102.dll", EntryPoint = "MPS_Start", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public extern static Int32 MPS_Start(int DeviceHandle);

        [DllImport("MPS-080102.dll", EntryPoint = "MPS_DataIn", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public extern static Int32 MPS_DataIn(IntPtr DataBuffer, int SampleNumber, int DeviceHandle);

        [DllImport("MPS-080102.dll", EntryPoint = "MPS_Stop", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public extern static Int32 MPS_Stop(int DeviceHandle);

        [DllImport("MPS-080102.dll", EntryPoint = "MPS_CloseDevice", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public extern static Int32 MPS_CloseDevice(int DeviceHandle);

    }
}
