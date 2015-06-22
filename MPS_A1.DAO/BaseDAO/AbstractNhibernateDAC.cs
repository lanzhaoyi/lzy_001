
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPS_A1.DAC
{
    public abstract class AbstractNhibernateDAC<T>
    {
        public void ClearNHibernate()
        {
            NHibernateSession.Clear();
            NHibernateSession.Flush();   
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Save(T entity)
        {
            NHibernateSession.Save(entity);
            NHibernateSession.Flush();           
            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T SaveAndRefresh(T entity)
        {
            NHibernateSession.Save(entity);
            NHibernateSession.Flush();
            NHibernateSession.Refresh(entity);
            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T SaveOrUpdate(T entity)
        {
            NHibernateSession.SaveOrUpdate(entity);
            NHibernateSession.Flush();
            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Update(T entity)
        {
            NHibernateSession.Update(entity);
            NHibernateSession.Flush();
            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            NHibernateSession.Delete(entity);
            NHibernateSession.Flush();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DeleteByID(int ID)
        {
            T objT = this.GetObjectByID(ID, false);
            if (objT == null)
                return false;
            this.Delete(objT);
            return true;
        }

        /// <summary>
        /// 通过ID得到对象
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public T GetObjectByID(int ID)
        {
            T entity = (T)NHibernateSession.Load(typeof(T), ID);
            return entity;
        }

        

        /// <summary>
        /// 通过ID得到对象
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="shouldLock"></param>
        /// <returns></returns>
        public T GetObjectByID(int ID, bool shouldLock)
        {
            T entity;
            if (shouldLock)
            {
                entity = (T)NHibernateSession.Load(typeof(T), ID, NHibernate.LockMode.Upgrade);
            }
            else
            {
                entity = (T)NHibernateSession.Load(typeof(T), ID);
            }
            return entity;
        }

        /// <summary>
        /// 得到所有数据
        /// </summary>
        /// <returns></returns>
        public IList<T> GetAllObjectList()
        {
            return GetObjectListByCriterion();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="criterias"></param>
        /// <returns></returns>
        public IList<T> GetObjectListByCriterion(params ICriterion[] criterias)
        {
            ICriteria objCriteria = NHibernateSession.CreateCriteria(typeof(T));
            if (criterias != null)
            {
                foreach (ICriterion c in criterias)
                {
                    if (c != null)
                    {
                        objCriteria.Add(c);
                    }
                }
            }
            return objCriteria.List<T>() as List<T>;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheable"></param>
        /// <param name="criterias"></param>
        /// <returns></returns>
        public IList<T> GetObjectListByCriterion(bool cacheable, params ICriterion[] criterias)
        {
            ICriteria objCriteria = NHibernateSession.CreateCriteria(typeof(T));
            if (criterias != null)
            {
                foreach (ICriterion c in criterias)
                {
                    if (c != null)
                    {
                        objCriteria.Add(c);
                    }
                }
            }
            return objCriteria.SetCacheable(cacheable).List<T>() as List<T>;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public ISession NHibernateSession
        {
            get
            {
                ISession objSession = NHibernateSessionManager.Instance().GetSession();
                return objSession;
            }
        }
    }
}
