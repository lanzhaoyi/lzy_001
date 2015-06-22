using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MPS_A1.Entitys
{
    /// <summary>
    /// 采集速率表
    /// </summary>
    [Serializable]
    public class MPS_CollectRate
    {
        /// <summary>
        /// 采集速率ID
        /// </summary>
        public virtual int CollectRateID { get; set; }

        /// <summary>
        /// 中文名称
        /// </summary>
        public virtual string CollectRate { get; set; }
    }
}
