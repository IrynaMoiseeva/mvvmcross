using MvvmCross_Application1.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross_Application1.Core.Services
{ 
   public interface IPlatformService
    {
     string GetPlatform();
        void GetConnection();
        //bool InsertIntoTableFavourities(Favorite fav);

    }

    public class PlatformService: IPlatformService
    {
        public string GetPlatform() { return "dddd"; }

        

        void IPlatformService.GetConnection()
        {
            
        }
    }
}
