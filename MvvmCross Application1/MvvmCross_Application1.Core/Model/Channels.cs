using System;
using MvvmCross_Application1.Core.DataBase;
using SQLite.Net.Attributes;

namespace MvvmCross_Application1.Core.Model
{
    [Table("Channels")]
    public class Channels: BaseEntity
    {

        public string PlayListId { get; set; }
        public string Title { get; set; }
        //public string Image { get; set; }

    }
    }

