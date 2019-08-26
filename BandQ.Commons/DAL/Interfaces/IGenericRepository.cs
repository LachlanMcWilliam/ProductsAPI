using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BandQ.Commons.DAL.Interfaces
{
    public interface IGenericRepository
    {
        //syncronous
        T Add<T>(T entity) where T : class;
        T Update<T>(T entity) where T: class;
        bool Delete<T>(T entity) where T : class;
        void Commit();

        //async
        Task<T> AddAsync<T>(T entity) where T : class;
        Task<T> UpdateAsync<T>(T entity) where T : class;
        Task<bool> DeleteAsync<T>(T entity) where T : class;
        Task<T[]> AddManyAsync<T>(params T[] entities) where T : class;
        Task<bool> DeleteManyAsync<T>(params T[] entities) where T : class;
        Task<T[]> UpdateManyAsync<T>(params T[] entities) where T : class;
        Task<T> GetSingleAsync<T>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) where T : class;
        IQueryable<T> AllIncluding<T>(params Expression<Func<T, object>>[] include) where T : class;
        Task CommitAsync();
    }
}
