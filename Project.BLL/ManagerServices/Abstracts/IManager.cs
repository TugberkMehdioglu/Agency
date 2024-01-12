using Project.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Abstracts
{
    public interface IManager<T> where T : class, IEntity
    {
        //List Commands
        IQueryable<T> GetAll();
        IQueryable<T> GetActives();
        IQueryable<T> GetModifieds();
        IQueryable<T> GetPassives();


        //Modify Commands
        Task<string?> AddAsync(T entity);
        Task<string?> AddWithOutSaveAsync(T entity);
        Task<string?> AddRangeAsync(ICollection<T> entities);
        Task<string?> AddRangeWithOutSaveAsync(ICollection<T> entities);
        Task<string?> UpdateAsync(T entity);
        Task<string?> UpdateWithOutSaveAsync(T entity);
        Task<string?> UpdateRangeAsync(ICollection<T> entities);
        Task<string?> UpdateRangeWithOutSaveAsync(ICollection<T> entities);
        Task<string?> DeleteAsync(T entity);
        string? DeleteWithOutSave(T entity);
        Task<string?> DeleteRangeAsync(ICollection<T> entities);
        string? DeleteRangeWithOutSave(ICollection<T> entities);
        Task<string?> DestroyAsync(T entity);
        string? DestroyWithOutSave(T entity);
        Task<string?> DestroyRangeAsync(ICollection<T> entities);
        string? DestroyRangeWithOutSave(ICollection<T> entities);
        Task SaveChangesAsync(); //For ...WithOutSaveAsync methods


        //Expression Commands
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<X?> SelectViaDtoAsync<X>(Expression<Func<T, X>> expression) where X : class;//For DTO Classes without unboxing
        object Select(Expression<Func<T, object>> expression);


        //FindCommands
        Task<T?> FindAsync(params object[] id);
        Task<T?> FindFirstDataAsync();
        Task<T?> FindLastDataAsync();
    }
}
