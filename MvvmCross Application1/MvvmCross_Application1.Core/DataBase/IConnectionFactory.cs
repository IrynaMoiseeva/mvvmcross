using System;
using SQLite;

namespace MvvmCross_Application1.Core.DataBase
{
    public interface IConnectionFactory
    {
       // SQLite.SQLiteConnection ProduceConnection();!!!
        SQLiteAsyncConnection ProduceConnection();
    } 
}
