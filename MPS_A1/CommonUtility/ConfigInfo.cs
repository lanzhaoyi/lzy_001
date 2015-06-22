using MPS_A1.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace MPS_A1.CommonUtility
{
    /// <summary>
    /// 配置信息
    /// </summary>
    public class ConfigInfo
    {
        /// <summary>
        /// 加载配置信息
        /// </summary>
        /// <returns></returns>
        public static bool LoadConfigInfo()
        {
            try
            {
                // 数据库名字
                GlobalInfo.g_DbName = ConfigurationManager.AppSettings["dbName"];
                // 数据库全路径
                GlobalInfo.g_DbFullPath = string.Format("{0}{1}", GlobalInfo.g_RootPath,GlobalInfo.g_DbName);
                return true;
            }
            catch (Exception ex)
            {
                MpsLog.ErrorFormat("加载初始配置信息异常，错误信息:{0},堆栈信息:{1}", ex.Message, ex.StackTrace);
            }
            return false;
        }
    }
}
