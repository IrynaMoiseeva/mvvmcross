using System;
using MvvmCross_Application1.Core.DataBase;
using SQLite.Net.Attributes;

namespace MvvmCross_Application1.Core.Model
{
    [Table("Channels")]
    public class Channels: IEntity
    {
       
        public int? Id { get; set; }
        public string PlayListId { get; set; }
        public string Title { get; set; }
       
    }
}

