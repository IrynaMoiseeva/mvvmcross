using System;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross.Platform;
using MvvmCross_Application1.Core.Services;
using MvvmCross_Application1.Core.ViewModels;
using SQLite;

namespace MvvmCross_Application1.Core.DataBase
{

    public class DbConnectionManager: IConnectionFactory
    {
        private readonly IPlatformService sqlitePlatformContext;
        public static SQLiteAsyncConnection connection;
        private static object syncObj = new Object();
        public string dbPath;
        private volatile IOperationsAsync asyncConnection;

        public DbConnectionManager(IPlatformService sqlitePlatformContext)
        {
            this.sqlitePlatformContext = sqlitePlatformContext;
            dbPath = sqlitePlatformContext.DestinationPath;
        }

         public void DropConnection()
          {
              if (asyncConnection == null)
                  return;

              lock (syncObj)
              {
                  asyncConnection = null;
              }
          }

          public IOperationsAsync GetConnection()
          {
              if (asyncConnection != null)
                  return asyncConnection;

              lock (syncObj)
              {
                  if (asyncConnection != null)
                      return asyncConnection;

                  var sqLiteAsyncConnection = CreateSqLiteAsyncConnection();
                  asyncConnection = new SqliteConnectionOperationsAsync(sqLiteAsyncConnection);
              }

              return asyncConnection;
          }


        private SQLiteAsyncConnection CreateSqLiteAsyncConnection()
        {
            var sqLiteAsyncConnection = new SQLiteAsyncConnection(dbPath);
           
            return sqLiteAsyncConnection;
        }
    }
}
