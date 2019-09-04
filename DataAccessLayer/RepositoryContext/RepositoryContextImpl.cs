//using System;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Threading.Tasks;
//using DataAccessLayer.ContextBase;
//using Microsoft.EntityFrameworkCore;
//
//namespace DataAccessLayer.RepositoryContext
//{
//    public class RepositoryContextImpl<T> : ContextBaseImpl, IRepositoryContext<T> where T : class
//    {
//        public RepositoryContextImpl(DbContext databaseContext)
//            : base(databaseContext)
//        {
//
//        }
//
//        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
//        {
//            return base.GetAll(filter, orderBy, includeProperties);
//        }
//
//        public Task<IQueryable<T>> GetAllASync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
//        {
//            return base.GetAllASync(filter, orderBy, includeProperties);
//        }
//
//        public virtual T GetSingleById(int id)
//        {
//            return base.GetSingleById<T>(id);
//        }
//
//        public Task<T> GetSingleByIdASync(int id)
//        {
//            return base.GetSingleByIdASync<T>(id);
//        }
//
//        public Task<T> GetSingleASync(Expression<Func<T, bool>> predicate, string includeProperties = "")
//        {
//            return base.GetSingleASync(predicate, includeProperties);
//        }
//
//        public virtual T GetSingle(Expression<Func<T, bool>> predicate, string includeProperties = "")
//        {
//            return base.GetSingle(predicate, includeProperties);
//        }
//
//        public virtual void Add(T toAdd)
//        {
//            base.Add(toAdd);
//        }
//
//        public virtual void AddOrUpdate(T toAddOrUpdate)
//        {
//            base.AddOrUpdate(toAddOrUpdate);
//        }
//
//        public virtual void Update(T toUpdate)
//        {
//            base.Update(toUpdate);
//        }
//
//        public virtual void Delete(int id)
//        {
//            base.Delete<T>(id);
//        }
//
//        public virtual void Delete(T entity)
//        {
//            base.Delete<T>(entity);
//        }
//    }
//}