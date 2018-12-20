using System;


namespace MvvmCross_Application1.Core.DataBase
{
    public abstract class DataBaseConnection : IDisposable
    {
        private readonly IDbConnectionManager dbmanager;


        protected IOperationsAsync DbConnection
        {
            get
            {
                try
                {
                    return dbmanager.GetConnection();
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot connect to database.", e);
                }
            }   
        }

        protected DataBaseConnection(IDbConnectionManager dbmanager)
        {

            this.dbmanager = dbmanager;
        }

        public virtual void Dispose() { }
    }
}

