using System;
using SQLite;

namespace MvvmCross_Application1.Core.DataBase
{
    public abstract class DataBaseConnection : IDisposable
    {
        private readonly IConnectionFactory factory;


        protected /*SQLite.SQLiteConnection*/ SQLiteAsyncConnection DbConnection
        {
            get
            {
                try
                {
                    return factory.ProduceConnection();
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot create connection to database.", e);
                }
            }   
        }

        protected DataBaseConnection(IConnectionFactory factory)
        {
            //factory.ThrowIfNull(nameof(factory));

            this.factory = factory;
        }

        public virtual void Dispose() { }
    }
}

