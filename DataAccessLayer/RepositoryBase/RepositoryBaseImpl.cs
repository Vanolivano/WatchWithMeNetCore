using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.RepositoryBase
{
    internal class RepositoryBaseImpl<T>: IRepositoryBase<T> where T : class
    {
        private readonly DbContext _dataBaseContext;
        
        public RepositoryBaseImpl(DbContext context)
        {
            _dataBaseContext = context;
        }
        
        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = GetQueryable(filter, includeProperties);

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }
        public Task<IQueryable<T>> GetAllASync(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = GetQueryable(filter, includeProperties);

            if (orderBy != null)
            {
                return new Task<IQueryable<T>>(() => orderBy(query));
            }

            return new Task<IQueryable<T>>(() => query);
        }
        public virtual T FindSingle(int id)
        {
            return _dataBaseContext.Set<T>().Find(id);
        }

        public virtual Task<T> FindSingleASync(int id)
        {
            return _dataBaseContext.Set<T>().FindAsync(id);
        }

        public virtual T FindBy(Expression<Func<T, bool>> predicate, string includeProperties = "")
        {
            IQueryable<T> query = _dataBaseContext.Set<T>();
            foreach (string includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query.Where(predicate).FirstOrDefault();
        }

        public virtual Task<T> FindByASync(Expression<Func<T, bool>> predicate, string includeProperties = "")
        {
            IQueryable<T> query = _dataBaseContext.Set<T>();
            foreach (string includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query.Where(predicate).FirstOrDefaultAsync();
        }

        public virtual void Add(T toAdd)
        {
            _dataBaseContext.Set<T>().Add(toAdd);
        }

        public async void AddAsync(T toAdd)
        {
            await _dataBaseContext.Set<T>().AddAsync(toAdd);
        }

        public void AddOrUpdate(T toAddOrUpdate)
        {
            var entry = _dataBaseContext.Entry(toAddOrUpdate);  
            switch (entry.State)  
            {  
                case EntityState.Detached:  
                    _dataBaseContext.Add(toAddOrUpdate);  
                    break;  
                case EntityState.Modified:  
                    _dataBaseContext.Update(toAddOrUpdate);  
                    break;  
                case EntityState.Added:  
                    _dataBaseContext.Add(toAddOrUpdate);  
                    break;  
                case EntityState.Unchanged:  
                    //item already in db no need to do anything  
                    break;

                default:  
                    throw new ArgumentOutOfRangeException();  
            }  
        }

        public virtual void Update(T toUpdate)
        {
            _dataBaseContext.Entry(toUpdate).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            T entity = FindSingle(id);
            _dataBaseContext.Set<T>().Remove(entity);
        }

        public virtual void Delete(T entity)
        {
            _dataBaseContext.Set<T>().Remove(entity);
        }
        private IQueryable<T> GetQueryable(Expression<Func<T, bool>> filter, string includeProperties)
        {
            IQueryable<T> query = _dataBaseContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (string includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query;
        }
    }
}