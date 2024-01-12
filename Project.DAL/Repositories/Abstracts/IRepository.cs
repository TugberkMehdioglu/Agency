using Project.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstracts
{
    public interface IRepository<T> where T : class, IEntity
    {
        //List Commands
        IQueryable<T> GetAll();
        IQueryable<T> GetActives();
        IQueryable<T> GetModifieds();
        IQueryable<T> GetPassives();


        //Modify Commands
        Task AddAsync(T entity);
        Task AddWithOutSaveAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task AddRangeWithOutSaveAsync(ICollection<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateWithOutSaveAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task UpdateRangeWithOutSaveAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);
        void DeleteWithOutSave(T entity);
        Task DeleteRangeAsync(ICollection<T> entities);
        void DeleteRangeWithOutSave(ICollection<T> entities);
        Task DestroyAsync(T entity);
        void DestroyWithOutSave(T entity);
        Task DestroyRangeAsync(ICollection<T> entities);
        void DestroyRangeWithOutSave(ICollection<T> entities);
        Task SaveChangesAsync(); //For ...WithOutSaveAsync methods


        //Expression Commands
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<X?> SelectViaDtoAsync<X>(Expression<Func<T, X>> expression) where X : class;
        object Select(Expression<Func<T, object>> expression);

        //FindCommands
        Task<T?> FindAsync(params object[] id);
        Task<T?> FindFirstDataAsync();
        Task<T?> FindLastDataAsync();
    }
}
