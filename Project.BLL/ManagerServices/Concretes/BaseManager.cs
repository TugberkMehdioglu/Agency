using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class BaseManager<T> : IManager<T> where T : class, IEntity
    {
        private readonly IRepository<T> _repository;

        public BaseManager(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }

        public virtual async Task<string?> AddAsync(T entity)
        {
            if (entity == null || entity.Status == DataStatus.Deleted) return "Lütfen gerekli alanları doldurun";

            try
            {
                await _repository.AddAsync(entity);
            }
            catch (Exception exception)
            {
                return $"Veritabanı işlemi sırasında hata oluştu, ALINAN HATA => {exception.Message}, İÇERİĞİ => {exception.InnerException}";
            }

            return null;
        }

        public virtual async Task<string?> AddRangeAsync(ICollection<T> entities)
        {
            if (entities == null || entities.Count < 1) return "Lütfen gerekli alanları doldurun";

            try
            {
                await _repository.AddRangeAsync(entities);
            }
            catch (Exception exception)
            {
                return $"Veritabanı işlemi sırasında hata oluştu, ALINAN HATA => {exception.Message}, İÇERİĞİ => {exception.InnerException}";
            }

            return null;
        }

        public virtual async Task<string?> AddRangeWithOutSaveAsync(ICollection<T> entities)
        {
            if (entities == null || entities.Count < 1) return "Lütfen gerekli alanları doldurun";

            try
            {
                await _repository.AddRangeWithOutSaveAsync(entities);
            }
            catch (Exception exception)
            {
                return $"Veritabanı işlemi sırasında hata oluştu, ALINAN HATA => {exception.Message}, İÇERİĞİ => {exception.InnerException}";
            }

            return null;
        }

        public virtual async Task<string?> AddWithOutSaveAsync(T entity)
        {
            if (entity == null || entity.Status == DataStatus.Deleted) return "Lütfen gerekli alanları doldurun";

            try
            {
                await _repository.AddWithOutSaveAsync(entity);
            }
            catch (Exception exception)
            {
                return $"Veritabanı işlemi sırasında hata oluştu, ALINAN HATA => {exception.Message}, İÇERİĞİ => {exception.InnerException}";
            }

            return null;
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public virtual async Task<string?> DeleteAsync(T entity)
        {
            if (entity == null || entity.Status == DataStatus.Deleted) return "Lütfen gerekli alanları doldurun";

            try
            {
                await _repository.DeleteAsync(entity);
            }
            catch (Exception exception)
            {
                return $"Veritabanı işlemi sırasında hata oluştu, ALINAN HATA => {exception.Message}, İÇERİĞİ => {exception.InnerException}";
            }

            return null;
        }

        public virtual async Task<string?> DeleteRangeAsync(ICollection<T> entities)
        {
            if (entities == null || entities.Count < 1) return "Lütfen gerekli alanları doldurun";

            try
            {
                await _repository.DeleteRangeAsync(entities);
            }
            catch (Exception exception)
            {
                return $"Veritabanı işlemi sırasında hata oluştu, ALINAN HATA => {exception.Message}, İÇERİĞİ => {exception.InnerException}";
            }

            return null;
        }

        public virtual string? DeleteRangeWithOutSave(ICollection<T> entities)
        {
            if (entities == null || entities.Count < 1) return "Lütfen gerekli alanları doldurun";

            try
            {
                _repository.DeleteRangeWithOutSave(entities);
            }
            catch (Exception exception)
            {
                return $"Veritabanı işlemi sırasında hata oluştu, ALINAN HATA => {exception.Message}, İÇERİĞİ => {exception.InnerException}";
            }

            return null;
        }

        public virtual string? DeleteWithOutSave(T entity)
        {
            if (entity == null || entity.Status == DataStatus.Deleted) return "Lütfen gerekli alanları doldurun";

            try
            {
                _repository.DeleteWithOutSave(entity);
            }
            catch (Exception exception)
            {
                return $"Veritabanı işlemi sırasında hata oluştu, ALINAN HATA => {exception.Message}, İÇERİĞİ => {exception.InnerException}";
            }

            return null;
        }

        public virtual async Task<string?> DestroyAsync(T entity)
        {
            if (entity == null || entity.Status == DataStatus.Deleted) return "Lütfen gerekli alanları doldurun";

            try
            {
                await _repository.DestroyAsync(entity);
            }
            catch (Exception exception)
            {
                return $"Veritabanı işlemi sırasında hata oluştu, ALINAN HATA => {exception.Message}, İÇERİĞİ => {exception.InnerException}";
            }

            return null;
        }

        public virtual async Task<string?> DestroyRangeAsync(ICollection<T> entities)
        {
            if (entities == null || entities.Count < 1) return "Lütfen gerekli alanları doldurun";

            try
            {
                await _repository.DestroyRangeAsync(entities);
            }
            catch (Exception exception)
            {
                return $"Veritabanı işlemi sırasında hata oluştu, ALINAN HATA => {exception.Message}, İÇERİĞİ => {exception.InnerException}";
            }

            return null;
        }

        public virtual string? DestroyRangeWithOutSave(ICollection<T> entities)
        {
            if (entities == null || entities.Count < 1) return "Lütfen gerekli alanları doldurun";

            try
            {
                _repository.DestroyRangeWithOutSave(entities);
            }
            catch (Exception exception)
            {
                return $"Veritabanı işlemi sırasında hata oluştu, ALINAN HATA => {exception.Message}, İÇERİĞİ => {exception.InnerException}";
            }

            return null;
        }

        public virtual string? DestroyWithOutSave(T entity)
        {
            if (entity == null || entity.Status == DataStatus.Deleted) return "Lütfen gerekli alanları doldurun";

            try
            {
                _repository.DestroyWithOutSave(entity);
            }
            catch (Exception exception)
            {
                return $"Veritabanı işlemi sırasında hata oluştu, ALINAN HATA => {exception.Message}, İÇERİĞİ => {exception.InnerException}";
            }

            return null;
        }

        public virtual async Task<T?> FindAsync(params object[] id)
        {
            return await _repository.FindAsync(id);
        }

        public virtual async Task<T?> FindFirstDataAsync()
        {
            return await _repository.FindFirstDataAsync();
        }

        public virtual async Task<T?> FindLastDataAsync()
        {
            return await _repository.FindLastDataAsync();
        }

        public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.FirstOrDefaultAsync(expression);
        }

        public virtual IQueryable<T> GetActives()
        {
            return _repository.GetActives();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual IQueryable<T> GetModifieds()
        {
            return _repository.GetModifieds();
        }

        public virtual IQueryable<T> GetPassives()
        {
            return _repository.GetPassives();
        }

        public virtual object Select(Expression<Func<T, object>> expression)
        {
            return _repository.Select(expression);
        }

        public virtual async Task<X?> SelectViaDtoAsync<X>(Expression<Func<T, X>> expression) where X : class
        {
            return await _repository.SelectViaDtoAsync(expression);
        }

        public virtual async Task<string?> UpdateAsync(T entity)
        {
            if (entity == null || entity.Status == DataStatus.Deleted) return "Lütfen gerekli alanları doldurun";

            try
            {
                await _repository.UpdateAsync(entity);
            }
            catch (Exception exception)
            {
                return $"Veritabanı işlemi sırasında hata oluştu, ALINAN HATA => {exception.Message}, İÇERİĞİ => {exception.InnerException}";
            }

            return null;
        }

        public virtual async Task<string?> UpdateRangeAsync(ICollection<T> entities)
        {
            if (entities == null || entities.Count < 1) return "Lütfen gerekli alanları doldurun";

            try
            {
                await _repository.UpdateRangeAsync(entities);
            }
            catch (Exception exception)
            {
                return $"Veritabanı işlemi sırasında hata oluştu, ALINAN HATA => {exception.Message}, İÇERİĞİ => {exception.InnerException}";
            }

            return null;
        }

        public virtual async Task<string?> UpdateRangeWithOutSaveAsync(ICollection<T> entities)
        {
            if (entities == null || entities.Count < 1) return "Lütfen gerekli alanları doldurun";

            try
            {
                await _repository.UpdateRangeWithOutSaveAsync(entities);
            }
            catch (Exception exception)
            {
                return $"Veritabanı işlemi sırasında hata oluştu, ALINAN HATA => {exception.Message}, İÇERİĞİ => {exception.InnerException}";
            }

            return null;
        }

        public virtual async Task<string?> UpdateWithOutSaveAsync(T entity)
        {
            if (entity == null || entity.Status == DataStatus.Deleted) return "Lütfen gerekli alanları doldurun";

            try
            {
                await _repository.UpdateWithOutSaveAsync(entity);
            }
            catch (Exception exception)
            {
                return $"Veritabanı işlemi sırasında hata oluştu, ALINAN HATA => {exception.Message}, İÇERİĞİ => {exception.InnerException}";
            }

            return null;
        }

        public virtual IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
