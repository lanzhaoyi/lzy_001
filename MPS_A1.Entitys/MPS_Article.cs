using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MPS_A1.Entitys
{
    /// <summary>
    /// 检测物质表
    /// </summary>
    [Serializable]
    public class MPS_Article
    {
        /// <summary>
        /// 检测物质表ID
        /// </summary>
        public virtual int ArticleID { get; set; }
        /// <summary>
        /// 检测物质名称
        /// </summary>
        public virtual string ArticleName { get; set; }
    }
}
