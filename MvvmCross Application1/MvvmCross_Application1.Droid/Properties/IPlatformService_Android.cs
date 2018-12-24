using MvvmCross_Application1.Core.Services;
using System.IO;

namespace MvvmCross_Application1.Droid.Properties
{
    public class PlatformService_Android : IPlatformService
    {
        public string DestinationPath
        {
            get { return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydb.sqlite"); }
        }
    }
}




