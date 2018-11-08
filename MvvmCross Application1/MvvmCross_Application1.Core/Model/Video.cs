using MvvmCross.Core.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross_Application1.Core.Model
{
  
    public class Video : MvxViewModel
    {
       
        public string VideoId { get; set; }
        public string Title { get; set; }
        public Video(string id, string title)
        {
            Title = title;
            VideoId = id;


            SubCommand = new MvxCommand(Sub);

        }


        public MvxCommand SubCommand { get; }

        private void Sub()
        {
            var r = 1; ;
        }
    }

    public class Channel : MvxViewModel
    {
        
        public int Id { get; set; }
        public string PlayListId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }

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
        public Channel(int id,string playlistid, string title, string image)
        {
            Id = id;
            Title = title;
            PlayListId = playlistid;
            Image = image;

        }
    }
}
