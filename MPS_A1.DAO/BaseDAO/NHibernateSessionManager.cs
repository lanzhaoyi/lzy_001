using MPS_A1.Utilities;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace MPS_A1.DAC
{
    public sealed class NHibernateSessionManager
    {

        private ISessionFactory sessionFactory;
        private const string SESSION_KEY = "CONTEXT_SESSION";

        private NHibernateSessionManager()
        {
            InitSessionFactory();
        }

        private static NHibernateSessionManager objNHibernateSessionManager = null;
        public static NHibernateSessionManager Instance()
        {
            if (objNHibernateSessionManager == null)
            {
                objNHibernateSessionManager = new NHibernateSessionManager();
            }
            return objNHibernateSessionManager;
        }

        private void InitSessionFactory()
        {
            Configuration config = new Configuration();
            config.Configure();
            config = LoadConfigurationInfo(config);
            sessionFactory = config.BuildSessionFactory();
        }

        public void RegisterInterceptor(IInterceptor interceptor)
        {
            ISession session = ContextSession;
            if (session != null && session.IsOpen)
            {
                MpsLog.Error("拦截器已经注册，不能重复注册");
            }
            GetSession(interceptor);
        }

        public ISession GetSession()
        {
            return GetSession(null);
        }

        private ISession GetSession(IInterceptor interceptor)
        {
            ISession session = ContextSession;
            if (session == null)
            {
                if (interceptor != null)
                {
                    session = sessionFactory.OpenSession(interceptor);
                }
                else
                {
                    session = sessionFactory.OpenSession();
                }
                ContextSession = session;
            }
            if (session == null)
            {
                MpsLog.Error("session was null");
            }
            return session;
        }

        private void CloseSession()
        {
            ISession session = ContextSession;
            if (session != null && session.IsOpen)
            {
                session.Flush();
                session.Close();
            }
            ContextSession = null;
        }


        private ISession ContextSession
        {
            get
            {
                return (ISession)CallContext.GetData(SESSION_KEY);
            }
            set
            {
                CallContext.SetData(SESSION_KEY, value);
            }
        }

        /// <summary>
        /// 加载hibernate配置信息
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public Configuration LoadConfigurationInfo(Configuration configuration)
        {
            try
            {
                if (configuration == null)
                    return null;
                // 数据库连接字符串
                //configuration.Properties["connection.connection_string"] = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}{1};Jet OLEDB:;", GlobalInfo.g_RootPath, GlobalInfo.g_DbName);//Database Password={2} , "lijun_lucky@163.com"
                configuration.Properties["connection.connection_string"] = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}{1};", GlobalInfo.g_RootPath, GlobalInfo.g_DbName);//Jet OLEDB:Database Password={2}; , "lijun_lucky@163.com"


                return configuration;
            }
            catch (Exception ex)
            {
                MpsLog.ErrorFormat("加载hibernate配置信息异常,错误信息:{0},堆栈信息:{1}", ex.Message, ex.StackTrace);
            }
            return null;
        }


    }
}
