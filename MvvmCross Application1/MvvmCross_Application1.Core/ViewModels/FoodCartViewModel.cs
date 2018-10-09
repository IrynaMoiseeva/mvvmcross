using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using MvvmCross_Application1.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross_Application1.Core.ViewModels
{
   public class FoodCartViewModel: MvxViewModel
    {
        
        public Cart Cart
        {
            get
            {
                return (Cart.Instance) ;
            }
        }

        public FoodCartViewModel(IMvxMessenger messenger )
        {
            
           
        }
       
        public MvxCommand<Food> ShowFoodDetailsCommand
        {
            get
            {
                return new MvxCommand<Food>(selectedFood =>
                {
                    ShowViewModel<FoodDetailsViewModel>
                    (new { foodId = selectedFood.Id });
                });
            }
        }
        
    }
}
