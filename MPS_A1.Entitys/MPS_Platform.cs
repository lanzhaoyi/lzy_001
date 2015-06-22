using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MPS_A1.Entitys
{
    /// <summary>
    /// 平台表
    /// </summary>
    [Serializable]
    public class MPS_Platform
    {
        /// <summary>
        /// 平台表ID
        /// </summary>
        public  virtual int PlatformID { get; set; }
        /// <summary>
        /// 平台名称
        /// </summary>
        public  virtual string PlatformName { get; set; }
    }
}
