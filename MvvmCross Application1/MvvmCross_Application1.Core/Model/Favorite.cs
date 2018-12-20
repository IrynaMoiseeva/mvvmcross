using MvvmCross_Application1.Core.DataBase;
using SQLite.Net.Attributes;

namespace MvvmCross_Application1.Core.Model
{
    [Table("FavoriteVideos")]
    public class FavoriteVideos: IEntity
    {
       //[PrimaryKey, AutoIncrement]
        public int? Id { get; set; }

        public string VideoId { get; set; }
       
    }
   
}
