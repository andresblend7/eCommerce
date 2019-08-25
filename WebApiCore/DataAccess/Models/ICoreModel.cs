using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApiCore.DataAccess.Models
{
    /// <summary>
    /// Interface encargada de definir los mecanismos de consulta.
    /// </summary>
    public interface ICoreModel
    {
        //Metodo encargado de agregar una entidad a la base de datos
        Task<bool> AddAsync<TEntity>(TEntity entity) where TEntity : class;     
        //Metoeo encargado de consultar todo los registros
        IQueryable<TEntity> GetAllAsync<TEntity>() where TEntity : class;
        //Metodo encargado de buscar registros segun la predicado
        Task<List<TEntity>> SearchAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        //Metodo encargado de consultar un solo registro segun el predicado
        Task<TEntity> GetOneAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;  
        //Metodo encargado de actualizar una entidad
        Task<bool> UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
        //Metodo encargado de eliminar una entidad en la base de datos
        Task<bool> DeleteAsync<TEntity>(TEntity entity) where TEntity : class;
        //Metodo encargado de obtener el total de las filas
        Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class;
        //Metodo encargado de guardar los cambios en la base de datos
        Task<bool> SaveAsync();      
    }
}

