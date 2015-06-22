using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPS_A1.Utilities
{
    /// <summary>
    /// 发送命令类型
    /// </summary>
    public enum eSendCmdType
    {
        /// <summary>
        /// 使能
        /// </summary>
        SetShiPower = 1,
        /// <summary>
        /// 
        /// </summary>
        SetElectricity = 2,
        /// <summary>
        /// 设置速度
        /// </summary>
        SetSpeed = 3
    }

    /// <summary>
    /// 串口返回数据状态
    /// </summary>
    public enum eSerialPortDataReviceStatus
    {
        /// <summary>
        /// 准备
        /// </summary>
        Ready = 0,
        /// <summary>
        /// 移动固定距离
        /// </summary>
        MoveFixedPosition = 1
    }


     /// <summary>
    /// 仪器操作类型
    /// </summary>
    public enum eMachineOperateType
    {
        /// <summary>
        /// 准备（初始）
        /// </summary>
        Ready=0,
        /// <summary>
        /// 移动固定距离
        /// </summary>
        MoveFixedPosition=1
    }
}
