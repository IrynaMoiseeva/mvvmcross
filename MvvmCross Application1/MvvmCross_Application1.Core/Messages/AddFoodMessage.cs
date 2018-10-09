using MvvmCross.Plugins.Messenger;
using MvvmCross_Application1.Core.Model;
using MvvmCross_Application1.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross_Application1.Core.Messages
{
    class AddFoodMessage : MvxMessage
    {

       
            public AddFoodMessage(object sender, int id, int quantity)
            : base(sender)
            {
                Id = id;
                Quantity = quantity;
            }

            public int Id
            {
                get;
                private set;
            }
            public int Quantity
            {
                get;
                private set;
            }
        }
    }


