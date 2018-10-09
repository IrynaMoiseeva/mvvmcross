using MvvmCross_Application1.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross_Application1.Core.Contracts
{
    public interface IFoodRepository
    {
        //Task<Food> GetFoodDetails(int foodId);
        Food GetFoodDetails(int foodId);
        List<Food> GetTypeFood(int foodType);
        List<Food> GetAllFood();


    }
}
