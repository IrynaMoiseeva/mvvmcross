using MvvmCross_Application1.Core.Contracts;
using MvvmCross_Application1.Core.Repositories;
using MvvmCross_Application1.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross_Application1.Core.Services
{
    class FoodDataService:IFoodDataService
    {
        private readonly IFoodRepository _foodRepository;
        //public async Task<Food> GetFoodDetails(int foodId)
        //{
        //    return await _foodRepository.GetFoodDetails(foodId);
        //}
        public FoodDataService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }
        
        public Food GetFoodDetails(int foodId)
        {
            return  _foodRepository.GetFoodDetails(foodId);
        }

        public List<Food> GetTypeFood(int foodType)
        {
            var FoodList = _foodRepository.GetTypeFood(foodType);
            return FoodList;


        }

          public List<Food> GetAllFood()
          {
            return _foodRepository.GetAllFood();
          }
    }
}
