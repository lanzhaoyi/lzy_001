using MPS_A1.CommonUtility;
using MPS_A1.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace MPS_A1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //加载log4日志dll
            log4net.Config.XmlConfigurator.Configure();
            MpsLog.Log.Info("应用程序Mps开始启动...");
            MpsLog.Log.Info("应用程序Mps开始初始化...");

            // 得到启动根目录
            string strApplicationRootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            char[] cArrFile = "file:\\".ToCharArray();
            char[] cArrBin = "bin".ToCharArray();
            strApplicationRootPath = strApplicationRootPath.TrimStart(cArrFile);
            strApplicationRootPath = strApplicationRootPath.TrimEnd(cArrBin);
            strApplicationRootPath = strApplicationRootPath.Replace("\\", "/");
            GlobalInfo.g_RootPath = strApplicationRootPath;
            if (!GlobalInfo.g_RootPath.EndsWith("/"))
            {
                GlobalInfo.g_RootPath += "/";
            }
            MpsLog.Log.DebugFormat("bin更目录:{0}", GlobalInfo.g_RootPath);
            ConfigInfo.LoadConfigInfo();
            MpsLog.Log.Info("应用程序Mps初始化完成...");
            

            Application.Run(new TempUI.MianF());
        }
    }
}
