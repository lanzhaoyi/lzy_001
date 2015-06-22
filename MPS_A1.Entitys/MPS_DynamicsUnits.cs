using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MPS_A1.Entitys
{
    /// <summary>
    /// 力的单位表
    /// </summary>
    [Serializable]
    public class MPS_DynamicsUnits
    {
        /// <summary>
        /// 力单位ID
        /// </summary>
        public  virtual int DynamicsUnitsID { get; set; }
        /// <summary>
        /// 英文名称简写
        /// </summary>
        public  virtual string DynamicsUnits { get; set; }
        /// <summary>
        /// 中文名称
        /// </summary>
        public  virtual string DynamicsUnitsName { get; set; }
    }
}
