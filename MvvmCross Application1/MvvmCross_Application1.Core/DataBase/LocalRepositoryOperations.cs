using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MvvmCross_Application1.Core.DataBase
{

    public abstract class LocalRepositoryAsyncBase<TEntity> : DataBaseConnection,  ILocalRepositoryOperations<TEntity>
        where TEntity : class,IEntity,new()
    {
        private const int ErrorValue = -1;

        private TEntity ErrorEntity() => default(TEntity);

        private IEnumerable<TEntity> ErrorEntityEnum => new TEntity[0];

        protected LocalRepositoryAsyncBase(IDbConnectionManager dbmanager)
                    : base(dbmanager)
        {
        }


        public async Task<int> InsertAsync(TEntity item)
        {
            try
            {

                return await DbConnection.InsertAsync(item).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                LogException(e);
                return ErrorValue;
            }
        }


        public async Task<int> UpdateOrCreate(TEntity item)
        {
            try
            {

                return await DbConnection.UpdateOrCreateAsync(item).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                LogException(e);
                return ErrorValue;
            }
        }



        public async Task<int> Create(TEntity item)
        {
            try
            {
                return await DbConnection.InsertAsync(item).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                LogException(e);
                return ErrorValue;
            }
        }


        public async Task<int> CreateAll(IEnumerable<TEntity> items)
        {
            try
            {
                return await DbConnection.InsertAllAsync(items).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                LogException(e);
                return ErrorValue;
            }
        }


        public async Task<TEntity> Read(int id)
        {
            try
            {
                return await DbConnection.GetAsync<TEntity>(id).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                LogException(e);
                return ErrorEntity();
            }
        }


        public async Task<IEnumerable<TEntity>> ReadAll()
        {
            try
            {

                return await DbConnection.TableAsync<TEntity>();
            }
            catch (Exception e)
            {
                LogException(e);
                return ErrorEntityEnum;
            }
        }


        public async Task<int> Update(TEntity item)
        {
            try
            {
                return await DbConnection.UpdateAsync(item).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                LogException(e);
                return ErrorValue;
            }
        }


        public async Task<int> UpdateAll(IEnumerable<TEntity> items)
        {
            try
            {
                return await DbConnection.UpdateAllAsync(items).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                LogException(e);
                return ErrorValue;
            }
        }

        public async Task<int> Delete(TEntity item)
        {
            try
            {
                return await DbConnection.DeleteAsync(item);
            }
            catch (Exception e)
            {
                LogException(e);
                return ErrorValue;
            }
        }


        public async Task CreateTableIfNotExists()
        {
            try
            {
                await DropTable();
                await CreateTable();
            }

            catch (Exception e)
            {
                LogException(e);

            }
        }


        public async Task DropTable()
        {
            try
            {
                await DbConnection.DropTableAsync<TEntity>().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                LogException(e);

            }
        }


        public async Task CreateTable()
        {
            try
            {
                await DbConnection.CreateTableAsync<TEntity>().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                LogException(e);

            }
        }

        private void LogException(Exception e)
        {
            Debug.WriteLine("Exception");
                
        }


    }
}



