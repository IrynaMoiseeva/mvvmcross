using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross_Application1.Core.DataBase;
using MvvmCross_Application1.Core.Model;
using MvvmCross_Application1.Core.Repositories;

namespace MvvmCross_Application1.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public App()
        {
           
        }


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
            Mvx.RegisterType<IDbConnectionManager, DbConnectionManager>();

            Mvx.LazyConstructAndRegisterSingleton<IFavorRepository, FavorRepository>();
            Mvx.LazyConstructAndRegisterSingleton<IChannelRepository, ChannelRepository>();
            //RegisterSingleton<ILocalUserRepository, LocalUserRepository>();


            var container = Mvx.Resolve<IDbConnectionManager>();
            var f=container.GetConnection();
           
            f.CreateTableAsync <FavoriteVideos>();
            f.CreateTableAsync <Channels>();
            // var d = container.GetConnection();

            // d.CreateTablesAsync<FavoriteVideos, Channels>(SQLite.CreateFlags.ImplicitPK | SQLite.CreateFlags.AutoIncPK); ;
            //  RegisterAppStart<ViewModels.FoodRecyclerViewModel>();
        }
       // private async Task DBDeployment(IConnectionFactory connection)
        //{


       // }
    }
    
}
