using System;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross_Application1.Core.Services;
using MvvmCross_Application1.Core.ViewModels;
using SQLite;

namespace MvvmCross_Application1.Core.DataBase
{
  /* public interface IConnectionAsync : IDisposable
    {
        /// <summary>
        /// Update entity if exists or create new one
        /// </summary>
        Task<int> UpdateOrCreateAsync<TEntity>(TEntity item)
            where TEntity : class, IEntity, new();
        /// <summary>
        /// Update entity if exists or create new one
        /// </summary>
        Task<int> UpdateOrCreateAsync<TEntity>(TEntity item, CancellationToken ct)
            where TEntity : class, IEntity, new();
    }

    public interface IConnectionFactory
    {
        IConnectionAsync ProduceConnection();
    }

*/


    public class SingletonConnectionFactory: IConnectionFactory
    {
        //private readonly object asyncConnectionFactoryLock = new object();
        private readonly IPlatformService sqlitePlatformContext;

       // private volatile IConnectionAsync asyncConnection;

        public SingletonConnectionFactory(IPlatformService sqlitePlatformContext)
        {
          //  sqlitePlatformContext.ThrowIfNull(nameof(sqlitePlatformContext));

            this.sqlitePlatformContext = sqlitePlatformContext;
        }

        /* public void DropConnection()
         {
             if (asyncConnection == null)
                 return;

             lock (asyncConnectionFactoryLock)
             {
                 asyncConnection = null;
             }
         }

         public IConnectionAsync ProduceConnection()
         {
             if (asyncConnection != null)
                 return asyncConnection;

             lock (asyncConnectionFactoryLock)
             {
                 if (asyncConnection != null)
                     return asyncConnection;

                 var sqLiteAsyncConnection = ProduceSqLiteAsyncConnection();
                 asyncConnection = new SqliteConnectionWrapperAsync(sqLiteAsyncConnection);
             }

             return asyncConnection;
         }*/

        // SQLiteConnection IConnectionFactory.ProduceConnection() !!!
        SQLiteAsyncConnection IConnectionFactory.ProduceConnection()
        {
            var dbPath = GetDbPath();
            //var storeDateTimeAsticks = StoreDateTimeAsTicks();
            //  var useFlags = UseCustomSqliteOpenFlags();
            // var sqLiteAsyncConnection =
            // useFlags == true
            //? new SQLiteAsyncConnection(dbPath, GetSqliteOpenFlags(), storeDateTimeAsticks)
            //: new SQLiteAsyncConnection(dbPath, storeDateTimeAsticks);
           
          //  var con = new SQLite.SQLiteConnection(dbPath); !!!
            var con= new SQLiteAsyncConnection(dbPath);
            return con;
        }

        protected virtual string GetDbPath() => MainViewModel._platformService.DestinationPath;// insteadof   sqlitePlatformContext.DestinationPath;


        //  protected virtual bool StoreDateTimeAsTicks() => true;

        //  protected virtual bool UseCustomSqliteOpenFlags() => false;





        /* protected virtual SQLiteOpenFlags GetSqliteOpenFlags()
          {
              return SQLiteOpenFlags.Create;
          }
          */

    }
}
