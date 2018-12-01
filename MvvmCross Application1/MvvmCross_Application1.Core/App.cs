using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross_Application1.Core.Contracts;
using MvvmCross_Application1.Core.DataBase;
using MvvmCross_Application1.Core.Repositories;
using MvvmCross_Application1.Core.Services;



namespace MvvmCross_Application1.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                 .EndingWith("Repository")
                 .AsInterfaces()
                 .RegisterAsLazySingleton();
           /* CreatableTypes()
                .EndingWith("ConnectionFactory")
                .AsInterfaces()
                .RegisterAsLazySingleton();

          /*  CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
                */
            
            // RegisterAppStart<MvvmCross.Core.ViewModels.FoodsViewModel>();
            Mvx.RegisterType<IConnectionFactory, SingletonConnectionFactory>();
            
            RegisterAppStart<ViewModels.FoodRecyclerViewModel>();
        }
    }
    
}
