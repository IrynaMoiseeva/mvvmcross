using System;
using SQLite.Net.Attributes;

namespace MvvmCross_Application1.Core.DataBase
{
    public abstract class BaseEntity : IEntity
    {
        [PrimaryKey, AutoIncrement]
        // public virtual int Id { get; set; }
        public int? Id { get; set; }
    }
}
