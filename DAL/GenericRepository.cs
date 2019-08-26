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
    public class GenericRepository<TContext> : IGenericRepository where TContext: DbContext, new()
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
                using(var transaction = _context.Database.BeginTransaction())
                {
                    _context.Set<T>().Add(entity);

                    Commit();

                    transaction.Commit();
                }
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
                using(var transaction = await _context.Database.BeginTransactionAsync())
                {
                    await _context.Set<T>().AddAsync(entity);

                    await CommitAsync();

                    transaction.Commit();
                }
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
                    using (var transaction = await _context.Database.BeginTransactionAsync())
                    {
                        await _context.Set<T>().AddAsync(item);

                        await CommitAsync();

                        transaction.Commit();
                    }
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
            IQueryable<T> query = _context.Set<T>();

            return include.Aggregate(query, (current, item) => current.Include(item));
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public bool Delete<T>(T entity) where T : class
        {
            try
            {
                using(var transaction = _context.Database.BeginTransaction())
                {
                    if (_context.Entry(entity).State == EntityState.Detached)
                    {
                        _context.Set<T>().Attach(entity);
                    }

                    _context.Set<T>().Remove(entity);

                    Commit();

                    transaction.Commit();
                }
            }
            catch (DbUpdateException ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteAsync<T>(T entity) where T : class
        {
            try
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    if (_context.Entry(entity).State == EntityState.Detached)
                    {
                        _context.Set<T>().Attach(entity);
                    }

                    _context.Set<T>().Remove(entity);

                    await CommitAsync();

                    transaction.Commit();
                }
            } catch(DbUpdateException ex)
            {
                return false;
            }
            return true;
        }
        public async Task<T> GetSingleAsync<T>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) where T : class
        {
            try
            {
                    var items = _context.Set<T>();

                    return await items.Where<T>(where).FirstOrDefaultAsync<T>();
            }
            catch
            {
                return null;
            }
        }

        public T Update<T>(T entity) where T : class
        {
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    var entry = _context.Entry(entity);
                    _context.Set<T>().Attach(entity);

                    entry.State = EntityState.Modified;

                    Commit();

                    transaction.Commit();
                }
            }
            catch(DbUpdateException ex)
            {
                throw;
            }

            return entity;
        }

        public async Task<T> UpdateAsync<T>(T entity) where T : class
        {
            try
            {
                using(var transaction = await _context.Database.BeginTransactionAsync())
                {
                    var entry = _context.Entry(entity);
                    _context.Set<T>().Attach(entity);

                    entry.State = EntityState.Modified;

                    await CommitAsync();

                    transaction.Commit();
                }
            } catch(DbUpdateException ex)
            {
                throw;
            }
            return entity;
        }

        public async Task<bool> DeleteManyAsync<T>(params T[] entities) where T : class
        {
            try
            {
                foreach (var item in entities)
                {
                    using(var transaction = await _context.Database.BeginTransactionAsync())
                    {
                        if (_context.Entry(item).State == EntityState.Detached)
                        {
                            _context.Set<T>().Attach(item);
                        }

                        _context.Set<T>().Remove(item);

                        await CommitAsync();

                        transaction.Commit();
                    }
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
                    using(var transaction = await _context.Database.BeginTransactionAsync())
                    {
                        var entry = _context.Entry(item);
                        _context.Set<T>().Attach(item);

                        entry.State = EntityState.Modified;
                        await CommitAsync();

                        transaction.Commit();
                    }
                }
            }
            catch(DbUpdateException ex)
            {
                throw;
            }

            return entities;
        }
        }
}
