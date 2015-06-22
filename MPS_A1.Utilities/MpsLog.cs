using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPS_A1.Utilities
{
    public class MpsLog
    {
        /// <summary>
        /// logger is a log4net instance. It provides methods to add debug, info, warn, error or fatal massage to Logger.logger. 
        /// </summary>
        private static log4net.ILog m_logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// The static property supplying the method to write log directly
        /// </summary>
        public static log4net.ILog Log
        {
            get { return m_logger; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <remark>
        /// 
        /// </remark>
        public static void Debug(object message)
        {
            if (m_logger.IsDebugEnabled)
            {
                m_logger.Debug(message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <remark>
        /// 
        /// </remark>
        public static void DebugFormat(string format, params object[] args)
        {
            if (m_logger.IsDebugEnabled)
            {
                m_logger.DebugFormat(format, args);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <remark>
        /// 
        /// </remark>
        public static void Info(object message)
        {
            if (m_logger.IsInfoEnabled)
            {
                m_logger.Info(message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <remark>
        /// 
        /// </remark>
        public static void InfoFormat(string format, params object[] args)
        {
            if (m_logger.IsInfoEnabled)
            {
                m_logger.InfoFormat(format, args);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <remark>
        /// 
        /// </remark>
        public static void Warn(object message)
        {
            if (m_logger.IsWarnEnabled)
            {
                m_logger.Warn(message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <remark>
        /// 
        /// </remark>
        public static void WarnFormat(string format, params object[] args)
        {
            if (m_logger.IsWarnEnabled)
            {
                m_logger.WarnFormat(format, args);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <remark>
        /// 
        /// </remark>
        public static void Error(object message)
        {
            if (m_logger.IsErrorEnabled)
            {
                m_logger.Error(message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <remark>
        /// 
        /// </remark>
        public static void ErrorFormat(string format, params object[] args)
        {
            if (m_logger.IsErrorEnabled)
            {
                m_logger.ErrorFormat(format, args);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <remark>
        /// 
        /// </remark>
        public static void Fatal(object message)
        {
            if (m_logger.IsFatalEnabled)
            {
                m_logger.Fatal(message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <remark>
        /// 
        /// </remark>
        public static void FatalFormat(string format, params object[] args)
        {
            if (m_logger.IsFatalEnabled)
            {
                m_logger.FatalFormat(format, args);
            }
        }

        private static void ChangeLog4netLogFileName(log4net.ILog iLog, string fileName)
        {
            log4net.Core.LogImpl logImpl = iLog as log4net.Core.LogImpl;
            if (logImpl != null)
            {
                log4net.Appender.AppenderCollection ac = ((log4net.Repository.Hierarchy.Logger)logImpl.Logger).Appenders;
                for (int i = 0; i < ac.Count; i++)
                {    //这里我只对RollingFileAppender类型做修改
                    log4net.Appender.RollingFileAppender rfa = ac[i] as log4net.Appender.RollingFileAppender;
                    if (rfa != null)
                    {
                        rfa.File = fileName;
                        if (!System.IO.File.Exists(fileName))
                        {
                            System.IO.File.Create(fileName);
                        }
                        //更新Writer属性
                        rfa.Writer = new System.IO.StreamWriter(rfa.File, rfa.AppendToFile, rfa.Encoding);
                    }
                }
            }
        }
    }
}
