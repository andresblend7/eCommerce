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

        public async Task<bool>AddAsync<TEntity>(TEntity entity) where TEntity : class
        {

            await this.db.Set<TEntity>().AddAsync(entity);
            return await this.SaveAsync();
        }

        public Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
            var context = this.db.Set<TEntity>();
            context.Remove(entity);

            return await this.SaveAsync();
        }

        /// <summary>
        /// Método Encargado de retornar una sola unidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<TEntity> GetOneAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var entitiy = this.db.Set<TEntity>().Where(predicate);

            return await entitiy.FirstOrDefaultAsync();
             
        }

        public virtual async Task<bool> SaveAsync()
        {
            //Guardamos los cambios en la base de datos
            return await this.db.SaveChangesAsync() > 0;
        }

        public async Task<List<TEntity>> SearchAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var entitiy = this.db.Set<TEntity>().Where(predicate);

            var result = await entitiy.ToListAsync();

            return result;
        }

  

        public Task<bool> UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            var context = this.db.Set<TEntity>();
            context.Update(entity);
            return this.SaveAsync();

        }

        IQueryable<TEntity> ICoreModel.GetAllAsync<TEntity>()
        {
            //Obtenemos todos los elementos de la base de datos
            return this.db.Set<TEntity>();
        }
    }
}
