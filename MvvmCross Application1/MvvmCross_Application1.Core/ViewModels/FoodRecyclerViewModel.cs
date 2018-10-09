
using MvvmCross.Core.ViewModels;
using MvvmCross_Application1.Core.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MvvmCross.Plugins.Messenger;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross_Application1.Core.Model;
using System.Windows.Input;
using MvvmCross_Application1.Core.Services;
using MvvmCross.Core.Navigation;
using MvvmCross_Application1.Core.Enums;

namespace MvvmCross_Application1.Core.ViewModels
{
    
   /* public class MyObject
    {
        public int i;
        public MyObject(int i)
        {
            this.i = i;
        }
    }*/
    public class FoodRecyclerViewModel : MvxViewModel<MyObject>
    {
        private readonly IFoodDataService _foodDataService;
        private MyObject _myObject;

        public override void Prepare(MyObject parameter)
        {
            // receive and store the parameter here
           /* _myObject = parameter;
            int r = (int)parameter.i;
            
            if (r == (int)TabPageTypes.Fruits)
            {
                SomeFoods.AddRange(Fruits);
            }
            if (r == (int)TabPageTypes.Vegetables)
            {
                SomeFoods.AddRange(Vegetables);
            }
            Foods = SomeFoods;*/
        }
        private List<Food> _foods;
        public List<Food> Foods //{ get; set; }
        {
            get { return _foods; }
            set
            {
                _foods = value;
                RaisePropertyChanged(() => Foods);
            }
        }

        
        public List<Food> Fruits;
        public List<Food> SomeFoods=new List<Food>();

        public List<Food> Vegetables;

       

        public override async Task Initialize()
        {
            //Do heavy work and data loading here
        //    SomeFoods =  _foodDataService.GetAllFood();
        }

        public MvxCommand ChangeCommand { get; }

        protected void Init(IMvxBundle bundle)
        {
            var t = 1;
        }
       
        
        
        private readonly IMvxNavigationService _navigationService;
        public FoodRecyclerViewModel(IFoodDataService foodDataService)
        {
            _foodDataService = foodDataService;
            Fruits = _foodDataService.GetTypeFood(1);//fruits
            Vegetables = _foodDataService.GetTypeFood(2);//vegetables 
          



        }

        
        public override async void Start()
        {
            base.Start();
           
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

        public MvxCommand<Food> ShowCartCommand
        {
            get
            {
                return new MvxCommand<Food>(selectedFood =>
                {
                    ShowViewModel<FoodCartViewModel>();
                });
            }
        }







    }
}

