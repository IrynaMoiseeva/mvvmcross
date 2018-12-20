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
       // public int? Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        // public string Image { get; set; }
        /* public Channels(int? Id, string PlayListId, string Title )
         {
             this.Id = Id;
             this.PlayListId = PlayListId;
             this.Title = Title;
         }*/
    }
}

