using MvvmCross_Application1.Core.Contracts;
using MvvmCross_Application1.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross_Application1.Core.Repositories
{
    class FoodRepository : IFoodRepository
    {
        private List<Food> AllFoods; 
        public FoodRepository()
        {
            AllFoods = new List<Food>()
        { new Food()
        {
            Id=1,
            Name = "Apple",
                    Price = 12,
                    Quantity = 9,
                    Type=1,
                    Image="apple.png"

        },
           new Food     { Id=1,
            Name = "Apple2",
                    Price = 12,
                    Quantity = 9,
                    Type=1,
                    Image="apple.png"

        },
            new Food     { Id=1,
            Name = "Apple3",
                    Price = 12,
                    Quantity = 9,
                    Type=1,
                    Image="apple.png"

        },
             new Food     { Id=1,
            Name = "Apple4",
                    Price = 12,
                    Quantity = 9,
                    Type=1,
                    Image="apple.png"

        },
              new Food     { Id=1,
            Name = "Apple5",
                    Price = 12,
                    Quantity = 9,
                    Type=1,
                    Image="apple.png"

        },
               new Food     { Id=1,
            Name = "Apple6",
                    Price = 12,
                    Quantity = 9,
                    Type=1,
                    Image="apple.png"

        },

                new Food()
        {
                     Id=2,
                    Name = "Tomatoes",
                    Price = 12,
                    Quantity = 9,
                     Type=2,
                     Image="tomatoes.png"
                },
                new Food()
        {
                    Id =3,
            Name = "Pear",
                    Price = 12,
                    Quantity = 9,
                    Type=1,
                    Image="pear.png"
                }
                };

        }
        //public async Task<Food> GetFoodDetails(int foodId)
        //{
        //    return await Task.FromResult(AllFoods.FirstOrDefault(j => j.Id == foodId));
        //}
        public Food GetFoodDetails(int foodId)
        {
           var t= AllFoods.FirstOrDefault(j => j.Id == foodId);
            return t;


        }
        public List<Food> GetTypeFood(int foodType)
        {
            var FoodList = AllFoods.Where(j => j.Type == foodType).ToList();
            return FoodList;


        }

        public List<Food> GetAllFood()
        {
            var FoodList = AllFoods;
            return AllFoods;


        }
        public List<Food> GetListFood( int[] foodId)
        {

            var FoodList = AllFoods.Where(p => foodId.Contains(p.Id)).ToList();
            return FoodList;


        }
    }
}

