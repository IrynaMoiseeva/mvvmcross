using MvvmCross.Core.ViewModels;
using MvvmCross_Application1.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MvvmCross_Application1.Core.Services.IFoodDataService;

namespace MvvmCross_Application1.Core.ViewModels
{
    public class FoodDetailsViewModel: MvxViewModel
    {
        private int _foodId;
        private Food _selectedFood;
        private readonly IFoodDataService _foodDataService;
        public void Init(int foodId)
        {
            _foodId = foodId;
        }
        public Food SelectedFood
        {
            get { return _selectedFood; }
            set
            {
                _selectedFood = value;
                RaisePropertyChanged(() => SelectedFood);
            }
        }
        public override async void Start()
        {
            base.Start();
            try { Initialize1(); }
            catch (Exception ex) { }
        }
        public FoodDetailsViewModel(IFoodDataService foodDataService)
        {
            _foodDataService = foodDataService;
        }
        
        /*public  override async Task Initialize()
        {
            SelectedFood = await _foodDataService.GetFoodDetails(_foodId);
            SelectedFood.Id = 5;
        }*/
        public   void Initialize1()
        {
            SelectedFood =  _foodDataService.GetFoodDetails(_foodId);
           // SelectedFood.Id = 5;
        }
    }
}
