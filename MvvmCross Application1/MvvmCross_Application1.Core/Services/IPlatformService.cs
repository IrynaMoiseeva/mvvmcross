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
        void Insert(string VidId);
        void Remove(string VidId);
        //bool InsertIntoTableFavourities(Favorite fav);

    }

    public  class PlatformService: IPlatformService
    {
        public string GetPlatform() { return "dddd"; }
         void IPlatformService.Insert(string VidId) { }
        void IPlatformService.Remove(string VidId) { }




        void IPlatformService.GetConnection()
        {
            
        }
    }
}
