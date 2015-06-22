using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MPS_A1.Entitys
{
    /// <summary>
    /// 传感器型号类
    /// </summary>
    [Serializable]
    public class MPS_SensorType
    {
        /// <summary>
        /// ID
        /// </summary>
        public  virtual int SensorTypeID { get; set; }
        /// <summary>
        /// 传感器型号名称
        /// </summary>
        public  virtual string SensorTypeName { get; set; }
    }
}
