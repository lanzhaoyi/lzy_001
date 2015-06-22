using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MPS_A1.Entitys
{
    /// <summary>
    /// 距离单位表
    /// </summary>
    [Serializable]
    public class MPS_DistanceUnit
    {
        /// <summary>
        /// 距离单位ID
        /// </summary>
        public  virtual int DistanceUnitID { get; set; }
        /// <summary>
        /// 英文名称简写
        /// </summary>
        public  virtual string DistanceUnit { get; set; }
        /// <summary>
        /// 中文名称
        /// </summary>
        public  virtual string DistanceUnitName { get; set; }
    }
}
