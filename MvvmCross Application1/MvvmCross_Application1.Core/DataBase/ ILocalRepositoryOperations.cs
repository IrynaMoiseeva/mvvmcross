using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MvvmCross_Application1.Core.DataBase
{
    public interface  ILocalRepositoryOperations<TEntity> : IDisposable
        where TEntity : class, IEntity, new()
    {
        Task<int> InsertAsync(TEntity item);
       
        Task<int> UpdateOrCreate(TEntity item);

        Task<int> Create(TEntity item);

        Task<TEntity> Read(int id);
       
        Task<IEnumerable<TEntity>> ReadAll();
       
        Task<int> Update(TEntity item);

        Task<int> Delete(TEntity item);
      
        Task DropTable();

        Task CreateTableIfNotExists();
      
        Task CreateTable();
    }
}


