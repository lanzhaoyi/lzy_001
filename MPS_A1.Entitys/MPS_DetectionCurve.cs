using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MPS_A1.Entitys
{
    [Serializable]
    public class MPS_DetectionCurve
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public virtual int ID { get; set; }
        /// <summary>
        /// 检测曲线名称
        /// </summary>
        public  virtual string DetectionName { get; set; }
        /// <summary>
        /// 检测物质名称
        /// </summary>
        public  virtual string DArticleName { get; set; }
        /// <summary>
        /// 探头名称
        /// </summary>
        public  virtual string DprobeName { get; set; }
        /// <summary>
        /// 平台名称
        /// </summary>
        public  virtual string DplatformName { get; set; }
        /// <summary>
        /// 夹具名称
        /// </summary>
        public  virtual string DFixtureName { get; set; }
        /// <summary>
        /// 采集速率
        /// </summary>
        public  virtual string DCollectRateName { get; set; }
        /// <summary>
        /// 测试模式
        /// </summary>
        public  virtual string DTestMName { get; set; }
        /// <summary>
        /// 接触前速度
        /// </summary>
        public  virtual string StartRate { get; set; }
        /// <summary>
        /// 接触后速度
        /// </summary>
        public  virtual string EndRate { get; set; }
        /// <summary>
        /// 开始记录力值
        /// </summary>
        public  virtual string DStartForceValue { get; set; }
        /// <summary>
        /// 力的单位
        /// </summary>
        public  virtual string DDynamicsUnitsName { get; set; }
        /// <summary>
        /// 距离单位
        /// </summary>
        public  virtual string DDistanceUnitName { get; set; }
        /// <summary>
        /// 传感器型号
        /// </summary>
        public  virtual string DSensorType { get; set; }
        /// <summary>
        /// 存放的文件名
        /// </summary>
        public  virtual string DFileName { get; set; }

    }
}
