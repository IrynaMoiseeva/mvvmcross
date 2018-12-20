using System;
using SQLite.Net.Attributes;

namespace MvvmCross_Application1.Core.DataBase
{
    public interface IEntity
    {
        [PrimaryKey, AutoIncrement]
         int? Id { get; set; }

    }
}
