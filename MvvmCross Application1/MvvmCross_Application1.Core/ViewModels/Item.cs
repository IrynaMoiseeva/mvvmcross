using MvvmCross.Core.Navigation;
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

    public class Cart : MvxNotifyPropertyChanged
    {
        public static  Cart Instance = new Cart();

        private  static Dictionary<int, Food> _cartFoods=new Dictionary<int, Food>();
        public Dictionary<int, Food> CartFoods
        {
            get { return _cartFoods; }
            set { _cartFoods = value; RaisePropertyChanged(() => CartFoods); }
        }
    }

  /*  public interface ICart
        {  }
    public class Cart:ICart
    {
        private ICart _cart;
        //public static readonly Cart Instance = new Cart();
         public static Dictionary<int, Food> CartFoods=new Dictionary<int, Food>();
       /* public  Dictionary<int, Food> _cartFoods;
        public Dictionary<int, Food> CartFoods
        {
            get { return _cartFoods; }
            set { _cartFoods = value; }
        }
        public Cart(ICart cart)
        {
            _cart = cart;
        }
    }*/
    

    public class Food : MvxViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Type { get; set; }
        public string Image { get; set; }
        //Dictionary<int, Food> CartFoods;
        // public Food CartFood;
        IMvxMessenger messenger;
        public Cart Cart1
        {
            get
            {
                return (Cart.Instance);
            }
        }
        //  public int Icon { get; set; }
       // public Cart Cart1;
        public MvxCommand AddCommand { get; }
        public MvxCommand SubCommand { get; }

        public Food()
        {

            //CartFood = new Food();
            //CartFoods = new Dictionary<int, Food>();
            
            AddCommand = new MvxCommand(Add);
            SubCommand = new MvxCommand(Sub);
        }

        private void Add()
        {
           var messenger = Mvx.Resolve<IMvxMessenger>();
            Quantity++;
            var message = new AddFoodMessage(
    this,
    this.Id,
    this.Quantity
);

           // messenger.Publish(message);


              if (Cart1.CartFoods.ContainsKey(this.Id))
              {
                  Cart1.CartFoods[this.Id].Quantity = this.Quantity;
              }
              else
              {
                  Cart1.CartFoods.Add(this.Id,
                      new Food()
                      {
                          Id = this.Id,
                          Name = this.Name,
                          Price = this.Price,
                          Quantity = this.Quantity,
                          Type=this.Type
                      });

              }

        }


        private void Sub()
        {
            Quantity--;
            /* if (CartFoods.ContainsKey(this.Id))
             {
                 if (this.Quantity > 0)
                 {
                     CartFoods[this.Id].Quantity = this.Quantity;
                 }
                 else CartFoods.Remove(this.Id);
             }*/
        }

        //Quantity is changed by clicking on plus and minus icons, we need to update it in the view
        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                RaisePropertyChanged(() => Quantity);
            }
        }
    }




    public class FoodInfo
    {
        public int Id { get; set; }
        public string Details { get; set; }


    }
}
