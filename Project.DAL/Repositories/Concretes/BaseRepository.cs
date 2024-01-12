using Microsoft.EntityFrameworkCore;
using Project.DAL.ContextClasses;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly MyContext _context;

        public BaseRepository(MyContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveChangesAsync();
        }

        public virtual async Task AddWithOutSaveAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(ICollection<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await SaveChangesAsync();
        }

        public virtual async Task AddRangeWithOutSaveAsync(ICollection<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AnyAsync(expression);
        }

        public virtual async Task DeleteAsync(T entity)
        {
            entity.Status = DataStatus.Deleted;
            entity.DeletedDate = DateTime.Now;
            await SaveChangesAsync();
        }

        public virtual void DeleteWithOutSave(T entity)
        {
            entity.Status = DataStatus.Deleted;
            entity.DeletedDate = DateTime.Now;
        }

        public virtual async Task DeleteRangeAsync(ICollection<T> entities)
        {
            foreach (T entity in entities)
            {
                DeleteWithOutSave(entity);
            }

            await SaveChangesAsync();
        }

        public virtual void DeleteRangeWithOutSave(ICollection<T> entities)
        {
            foreach (T entity in entities)
            {
                DeleteWithOutSave(entity);
            }
        }

        public virtual async Task DestroyAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await SaveChangesAsync();
        }

        public virtual void DestroyWithOutSave(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual async Task DestroyRangeAsync(ICollection<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            await SaveChangesAsync();
        }

        public virtual void DestroyRangeWithOutSave(ICollection<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public virtual async Task<T?> FindAsync(params object[] id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T?> FindFirstDataAsync()
        {
            return await _context.Set<T>().OrderBy(x => x.CreatedDate).FirstOrDefaultAsync();
        }

        public virtual async Task<T?> FindLastDataAsync()
        {
            return await _context.Set<T>().OrderByDescending(x => x.CreatedDate).FirstOrDefaultAsync();
        }

        public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public virtual IQueryable<T> GetActives()
        {
            return Where(x => x.Status != DataStatus.Deleted);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public virtual IQueryable<T> GetModifieds()
        {
            return Where(x => x.Status == DataStatus.Updated);
        }

        public virtual IQueryable<T> GetPassives()
        {
            return Where(x => x.Status == DataStatus.Deleted);
        }

        public virtual object Select(Expression<Func<T, object>> expression)
        {
            return _context.Set<T>().Select(expression);
        }

        public virtual async Task<X?> SelectViaDtoAsync<X>(Expression<Func<T, X>> expression) where X : class
        {
            return await _context.Set<T>().Select(expression).FirstOrDefaultAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            entity.Status = DataStatus.Updated;
            entity.ModifiedDate = DateTime.Now;
            T toBeUpdated = (await FindAsync(entity.Id))!;
            _context.Entry(toBeUpdated).CurrentValues.SetValues(entity);
            await SaveChangesAsync();
        }

        public virtual async Task UpdateWithOutSaveAsync(T entity)
        {
            entity.Status = DataStatus.Updated;
            entity.ModifiedDate = DateTime.Now;
            T toBeUpdated = (await FindAsync(entity.Id))!;
            _context.Entry(toBeUpdated).CurrentValues.SetValues(entity);
        }

        public virtual async Task UpdateRangeAsync(ICollection<T> entities)
        {
            foreach (T item in entities)
            {
                await UpdateWithOutSaveAsync(item);
            }

            await SaveChangesAsync();
        }

        public virtual async Task UpdateRangeWithOutSaveAsync(ICollection<T> entities)
        {
            foreach (T item in entities)
            {
                await UpdateWithOutSaveAsync(item);
            }
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
    }
}
