using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MPS_A1.Entitys
{
    /// <summary>
    /// 夹具表
    /// </summary>
    [Serializable]
    public class MPS_Fixture
    {
        /// <summary>
        /// 夹具表ID
        /// </summary>
        public  virtual int FixtureID { get; set; }
        /// <summary>
        /// 夹具名称
        /// </summary>
        public  virtual string FixtureName { get; set; }
    }
}
