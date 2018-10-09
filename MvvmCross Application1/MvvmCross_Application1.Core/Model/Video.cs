using MvvmCross.Core.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross_Application1.Core.Model
{
    [Table(nameof(Video))]
    public class Video
    {
        [PrimaryKey, AutoIncrement]
        public string VideoId { get; set; }
        public string Title { get; set; }
        public Video(string id, string title)
        {
            Title = title;
            VideoId = id;

        }
    }

    public class Channel : MvxViewModel
    {
        
        public int Id { get; set; }
        public string PlayListId { get; set; }
        public string Title { get; set; }
        private int quantity;
        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = value;
                RaisePropertyChanged(() => Quantity);
            }
        }
        public Channel(int id,string playlistid, string title)
        {
            Id = id;
            Title = title;
            PlayListId = playlistid;

        }
    }
}
