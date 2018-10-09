using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross_Application1.Core.Services
{
    class DataService
    {
       /* public class DataService: IDataService
        {
            private readonly SQLiteConnection _connection;

            public DataService(IMvxSqliteConnectionFactory factory)
            {
                _connection = factory.GetConnection("data.dat");
                _connection.CreateTable<Item>();
            }

            public void Save(Item item)
            {
                _connection.Insert(item);
            }

            public Item Load()
            {
                return _connection.Table<Item>().FirstOrDefault();
            }
        }*/
    }
}
