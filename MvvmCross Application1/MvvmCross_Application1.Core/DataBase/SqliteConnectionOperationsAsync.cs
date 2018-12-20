using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross.Platform.Core;
using SQLite;

namespace MvvmCross_Application1.Core.DataBase
{
    public class SqliteConnectionOperationsAsync : IOperationsAsync
    {
        private SQLiteAsyncConnection connection;

        public SqliteConnectionOperationsAsync(SQLiteAsyncConnection connection)
        {
            this.connection = connection;
        }

        public void Dispose()
        {
            connection.DisposeIfDisposable();
            connection = null;
        }

        public async Task<int> UpdateOrCreateAsync<TEntity>(TEntity item)
            where TEntity : class, IEntity, new()
        {
            return await UpdateOrCreateAsync(item, CancellationToken.None);
        }

        public async Task<int> UpdateOrCreateAsync<TEntity>(TEntity item, CancellationToken ct)
            where TEntity : class, IEntity, new()
        {
            return await connection.InsertOrReplaceAsync(item);
        }

        public async Task<IEnumerable<TEntity>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> whereClause)
            where TEntity : class, IEntity, new()
        {
            return await FindAsync(whereClause, CancellationToken.None);
        }

        public async Task<IEnumerable<TEntity>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> whereClause, CancellationToken ct)
            where TEntity : class, IEntity, new()
        {
            var results =
                await connection.Table<TEntity>()
                                .Where(whereClause)
                                .ToListAsync();

            return results;
        }


        public async Task<int> DropTableAsync<TEntity>()
            where TEntity : class, IEntity, new()
        {
            return await DropTableAsync<TEntity>(CancellationToken.None);
        }

        public async Task<int> DropTableAsync<TEntity>(CancellationToken ct)
            where TEntity : class, IEntity, new()
        {
          
            return await connection.DropTableAsync<TEntity>();
        }

        public async Task<int> CreateTableAsync<TEntity>()
            where TEntity : class, IEntity, new()
        {
            return await CreateTableAsync<TEntity>(CancellationToken.None);
        }

        public async Task<int> CreateTableAsync<TEntity>(CancellationToken ct)
            where TEntity : class, IEntity, new()
        {
        

            var tableResult = await connection.CreateTableAsync<TEntity>(CreateFlags.ImplicitPK |CreateFlags.AutoIncPK);

            try
            {
                var typeResult = 1;

                return typeResult;
            }
            catch (Exception e)
            {
              
                return -1;
            }
        }

        public async Task<TEntity> GetAsync<TEntity>(object pk)
            where TEntity : class, IEntity, new()
        {
            return await GetAsync<TEntity>(pk, CancellationToken.None);
        }

        public async Task<TEntity> GetAsync<TEntity>(object pk, CancellationToken ct)
            where TEntity : class, IEntity, new()
        {
            return await connection.GetAsync<TEntity>(pk);
        }

        public async Task<TEntity> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class, IEntity, new()
        {
            return await GetAsync(predicate, CancellationToken.None);
        }

        public async Task<TEntity> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken ct)
            where TEntity : class, IEntity, new()
        {
            return await connection.Table<TEntity>()
                                   .Where(predicate)
                                   .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> TableAsync<TEntity>()
            where TEntity : class, IEntity, new()
        {
            return await TableAsync<TEntity>(CancellationToken.None);
        }

        public async Task<IEnumerable<TEntity>> TableAsync<TEntity>(CancellationToken ct)
            where TEntity : class, IEntity, new()
        {
            return await connection.Table<TEntity>().ToListAsync();
        }

        public async Task<int> InsertAllAsync<TEntity>(IEnumerable<TEntity> objects)
            where TEntity : class, IEntity, new()
        {
            return await InsertAllAsync(objects, CancellationToken.None);
        }

        public async Task<int> InsertAllAsync<TEntity>(IEnumerable<TEntity> objects, CancellationToken ct)
            where TEntity : class, IEntity, new()
        {
            return await connection.InsertAllAsync(objects);
        }

        public async Task<int> InsertAsync<TEntity>(TEntity obj)
            where TEntity : class, IEntity, new()
        {
            return await InsertAsync(obj, CancellationToken.None);
        }

        public async Task<int> InsertAsync<TEntity>(TEntity obj, CancellationToken ct)
            where TEntity : class, IEntity, new()
        {
            return await connection.InsertAsync(obj);
        }

        public async Task<int> UpdateAsync<TEntity>(TEntity obj)
            where TEntity : class, IEntity, new()
        {
            return await UpdateAsync(obj, CancellationToken.None);
        }

        public async Task<int> UpdateAsync<TEntity>(TEntity obj, CancellationToken ct)
            where TEntity : class, IEntity, new()
        {
            return await connection.UpdateAsync(obj);
        }

        public async Task<int> UpdateAllAsync<TEntity>(IEnumerable<TEntity> objects)
            where TEntity : class, IEntity, new()
        {
            return await UpdateAllAsync(objects, CancellationToken.None);
        }

        public async Task<int> UpdateAllAsync<TEntity>(IEnumerable<TEntity> objects, CancellationToken ct)
            where TEntity : class, IEntity, new()
        {
            return await connection.UpdateAllAsync(objects);
        }

        public async Task<int> DeleteAsync<TEntity>(TEntity objectToDelete)
            where TEntity : class, IEntity, new()
        {
            return await DeleteAsync(objectToDelete, CancellationToken.None);
        }

        public async Task<int> DeleteAsync<TEntity>(TEntity objectToDelete, CancellationToken ct)
            where TEntity : class, IEntity, new()
        {
            return await connection.DeleteAsync(objectToDelete);
        }

        public async Task<int> DeleteAsync(object primaryKey)
        {
            return await DeleteAsync(primaryKey, CancellationToken.None);
        }

        public async Task<int> DeleteAsync(object primaryKey, CancellationToken ct)
        {
            return await connection.DeleteAsync(primaryKey);
        }

        public async Task<int> DeleteAllAsync<TEntity>()
            where TEntity : class, IEntity, new()
        {
            return await DeleteAllAsync<TEntity>(CancellationToken.None);
        }

        public async Task<int> DeleteAllAsync<TEntity>(CancellationToken ct)
            where TEntity : class, IEntity, new()
        {
            var result = await DropTableAsync<TEntity>(ct);
            result += await CreateTableAsync<TEntity>(ct);

            return result;
        }

        public async Task<int> DeleteAllAsync<TEntity>(IEnumerable<TEntity> objects)
            where TEntity : class, IEntity, new()
        {
            return await DeleteAllAsync(objects, CancellationToken.None);
        }

        public async Task<int> DeleteAllAsync<TEntity>(IEnumerable<TEntity> objects, CancellationToken ct)
            where TEntity : class, IEntity, new()
        {
            var num = 0;
            foreach (var entity in objects)
            {
                var result = await DeleteAsync(entity, ct);
                num += result;
                ct.ThrowIfCancellationRequested();
            }

            return num;
        }

        public async Task<int> ExecuteAsync(string query, params object[] args)
        {
            return await ExecuteAsync(CancellationToken.None, query, args);
        }

        public async Task<int> ExecuteAsync(CancellationToken ct, string query, params object[] args)
        {
            return await connection.ExecuteAsync(query, args);
        }

        public async Task<TEntity> ExecuteScalarAsync<TEntity>(string query, params object[] args)
        {
            return await ExecuteScalarAsync<TEntity>(CancellationToken.None, query, args);
        }

        public async Task<TEntity> ExecuteScalarAsync<TEntity>(CancellationToken ct, string query, params object[] args)
        {
            return await connection.ExecuteScalarAsync<TEntity>(query, args);
        }
    }
}


