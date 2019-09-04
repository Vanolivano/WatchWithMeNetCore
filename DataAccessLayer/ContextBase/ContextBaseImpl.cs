//using System;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Threading.Tasks;
//using DataAccessLayer.UnitOfWork;
//using Microsoft.EntityFrameworkCore;
//
//namespace DataAccessLayer.ContextBase
//{
//    public class ContextBaseImpl
//    {
//          private readonly IUnitOfWork _unitOfWork;
//
//        public ContextBaseImpl(DbContext databaseContext)
//        {
//            _unitOfWork = new UnitOfWork.UnitOfWork(databaseContext);
//        }
//
//        public int Save()
//        {
//            return _unitOfWork.Save();
//        }
//
//        public Task<int> SaveASync()
//        {
//            return _unitOfWork.SaveASync();
//        }
//
//        public void Dispose()
//        {
//            _unitOfWork.Dispose();
//        }
//
//        public void Add<T>(T toAdd) where T : class
//        {
//            _unitOfWork.GetRepository<T>().Add(toAdd);
//        }
//
//        public void AddOrUpdate<T>(T toAddOrUpdate) where T : class
//        {
//            _unitOfWork.GetRepository<T>().AddOrUpdate(toAddOrUpdate);
//        }
//
//        public void Update<T>(T toUpdate) where T : class
//        {
//            _unitOfWork.GetRepository<T>().Update(toUpdate);
//        }
//
//        public void Delete<T>(T toDelete) where T : class
//        {
//            _unitOfWork.GetRepository<T>().Delete(toDelete);
//        }
//
//        public void Delete<T>(int id) where T : class
//        {
//            _unitOfWork.GetRepository<T>().Delete(id);
//        }
//
//        public T GetSingle<T>(Expression<Func<T, bool>> predicate, string includeProperties = "") where T : class
//        {
//            return _unitOfWork.GetRepository<T>().FindBy(predicate, includeProperties);
//        }
//
//        public Task<T> GetSingleASync<T>(Expression<Func<T, bool>> predicate, string includeProperties = "") where T : class
//        {
//            return _unitOfWork.GetRepository<T>().FindByASync(predicate, includeProperties);
//        }
//
//        public T GetSingleById<T>(int id) where T : class
//        {
//            return _unitOfWork.GetRepository<T>().FindSingle(id);
//        }
//
//        public Task<T> GetSingleByIdASync<T>(int id) where T : class
//        {
//            return _unitOfWork.GetRepository<T>().FindSingleASync(id);
//        }
//
//        public IQueryable<T> GetAll<T>(Expression<Func<T, bool>> filter = null,
//           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
//           string includeProperties = "") where T : class
//        {
//            return _unitOfWork.GetRepository<T>().GetAll(filter, orderBy, includeProperties);
//        }
//
//        public Task<IQueryable<T>> GetAllASync<T>(Expression<Func<T, bool>> filter = null,
//           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
//           string includeProperties = "") where T : class
//        {
//            return _unitOfWork.GetRepository<T>().GetAllASync(filter, orderBy, includeProperties);
//        }
//    }
//}