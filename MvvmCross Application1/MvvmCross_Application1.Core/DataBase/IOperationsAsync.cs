using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MvvmCross_Application1.Core.DataBase
{
    public interface IOperationsAsync : IDisposable
    {
         
        Task<int> UpdateOrCreateAsync<TEntity>(TEntity item)
            where TEntity : class, IEntity, new();


        Task<int> DropTableAsync<TEntity>()
            where TEntity : class, IEntity, new();
       

        Task<int> CreateTableAsync<TEntity>()
            where TEntity : class, IEntity, new();

        Task<int> CreateTableAsync<TEntity>(CancellationToken ct)
            where TEntity : class, IEntity, new();

       
        Task<TEntity> GetAsync<TEntity>(object pk)
            where TEntity : class, IEntity, new();

        Task<TEntity> GetAsync<TEntity>(object pk, CancellationToken ct)
            where TEntity : class, IEntity, new();

       
        Task<TEntity> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class, IEntity, new();

        Task<TEntity> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken ct)
            where TEntity : class, IEntity, new();


        Task<IEnumerable<TEntity>> TableAsync<TEntity>()
            where TEntity : class, IEntity, new();

        Task<int> InsertAllAsync<TEntity>(IEnumerable<TEntity> objects)
            where TEntity : class, IEntity, new();
      
        Task<int> InsertAllAsync<TEntity>(IEnumerable<TEntity> objects, CancellationToken ct)
            where TEntity : class, IEntity, new();


        Task<int> InsertAsync<TEntity>(TEntity obj)
            where TEntity : class, IEntity, new();

        Task<int> InsertAsync<TEntity>(TEntity obj, CancellationToken ct)
            where TEntity : class, IEntity, new();

       
        Task<int> UpdateAllAsync<TEntity>(IEnumerable<TEntity> objects)
            where TEntity : class, IEntity, new();

        Task<int> UpdateAllAsync<TEntity>(IEnumerable<TEntity> objects, CancellationToken ct)
            where TEntity : class, IEntity, new();


        Task<int> UpdateAsync<TEntity>(TEntity obj)
            where TEntity : class, IEntity, new();

        Task<int> UpdateAsync<TEntity>(TEntity obj, CancellationToken ct)
            where TEntity : class, IEntity, new();

     
        Task<int> DeleteAsync<TEntity>(TEntity objectToDelete)
            where TEntity : class, IEntity, new();

        Task<int> DeleteAsync<TEntity>(TEntity objectToDelete, CancellationToken ct)
            where TEntity : class, IEntity, new();

       
        Task<int> DeleteAsync(object primaryKey);
    }
}

