using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApiCore.Entities;

namespace WebApiCore.DataAccess.Models
{
    public class CoreModel : ICoreModel
    {

        private readonly AppDbContext db;

        public CoreModel(AppDbContext dbContext)
        {
            this.db = dbContext;
        }

        public async void  AddAsync<TEntity>(TEntity entity) where TEntity : class
        {

            await this.db.Set<TEntity>().AddAsync(entity);

        }

        public Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            //Obtenemos todos los elementos de la base de datos
            return this.db.Set<TEntity>();
        }

        public Task<TEntity> GetOneAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> SaveAsync()
        {
            //Guardamos los cambios en la base de datos
            return await this.db.SaveChangesAsync() > 0;
        }

        public IQueryable<TEntity> SearchAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync<TEntity>(TEntity entity, string propertyName) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync<TEntity>(TEntity entity, List<string> propertiesName) where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}
