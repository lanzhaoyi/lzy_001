using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MPS_A1.Entitys
{
    /// <summary>
    /// 探头表
    /// </summary>
    [Serializable]
    public class MPS_Probe
    {
        /// <summary>
        /// 探头表ID
        /// </summary>
        public  virtual int ProbeID { get; set; }
        /// <summary>
        /// 探头名称
        /// </summary>
        public  virtual string ProbeName { get; set; }
    }
}
