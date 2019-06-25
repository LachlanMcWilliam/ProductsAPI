using BandQ.Commons.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BandQ.DAL
{
    public abstract class GenericRepository<TContext> : IGenericRepository where TContext: DbContext, new()
    {
        private TContext _context;

        public TContext Context { get => _context; set => _context = value; }

        protected GenericRepository()
        {
            Context = new TContext();
        }

        public GenericRepository(TContext context)
        {
            Context = context;
        }

        public T Add<T>(T entity) where T : class
        {
            try
            {
                _context.Set<T>().Add(entity);
            }
            catch(Exception ex)
            {
                throw;
            }
            return entity;
        }

        public async Task<T> AddAsync<T>(T entity) where T : class
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
            }
            catch(Exception ex)
            {
                throw;
            }
            return entity;
        }

        public async Task<T[]> AddManyAsync<T>(params T[] entities) where T : class
        {
            try
            {
                foreach (var item in entities)
                {
                    await _context.Set<T>().AddAsync(item);
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return entities;
        }

        public IQueryable<T> AllIncluding<T>(params Expression<Func<T, object>>[] include) where T : class
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void CommitAsync()
        {
            throw new NotImplementedException();
        }

        public bool Delete<T>(T entity) where T : class
        {
            try
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _context.Set<T>().Attach(entity);
                }

                _context.Set<T>().Remove(entity);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public Task<bool> DeleteAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(int Id) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync<T>(int Id) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> GetSingleAsync<T>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) where T : class
        {
            throw new NotImplementedException();
        }

        public T Update<T>(T entity) where T : class
        {
            try
            {
                var entry = _context.Entry(entity);
                _context.Set<T>().Attach(entity);

                entry.State = EntityState.Modified;
            }
            catch(Exception ex)
            {
                throw;
            }

            return entity;
        }

        public Task<T> UpdateAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteManyAsync<T>(params T[] entities) where T : class
        {
            try
            {
                foreach (var item in entities)
                {
                    if (_context.Entry(item).State == EntityState.Detached)
                    {
                        _context.Set<T>().Attach(item);
                    }

                    _context.Set<T>().Remove(item);
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return true;
        }

        public async Task<T[]> UpdateManyAsync<T>(params T[] entities) where T : class
        {
            try
            {
                foreach (var item in entities)
                {
                    var entry = _context.Entry(item);
                    _context.Set<T>().Attach(item);

                    entry.State = EntityState.Modified;
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return entities;
        }

        public Task<T[]> GetManyByIdAsync<T>(params int[] Ids) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
