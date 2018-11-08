using Android.Content;
using Android.Database.Sqlite;
using MvvmCross_Application1.Core.Model;
using MvvmCross_Application1.Core.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross_Application1.Droid.Properties
{


    public class PlatformService_Android : IPlatformService
    {
        public string GetPlatform() { return "android"; }
        public SQLiteConnection con;
        public SQLiteOpenHelper openhelper;
        public SQLiteDatabase db;

       // private void DatabaseAccess(Context context)
        
        public void GetConnection()
        {
            // 
            string[] names = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames();
            var destinationPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydb1.sqlite");
            using (Stream source = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MvvmCross_Application1.Droid.Resources.raw.mydb.sqlite"))
            {
                using (var destination = System.IO.File.Create(destinationPath))
                {
                    source.CopyTo(destination);
                }
            }
            try
            {

                 var con = new SQLiteConnection(destinationPath);
               
          
                con.CreateTable<FavoriteData>();
                var f=con.GetTableInfo("FavoriteData");
                con.Insert(new FavoriteData(){ VideoId = "three0" });
                con.Insert(new FavoriteData() { VideoId = "four0" });
                var before= con.Table<FavoriteData>().ToArray();

                var data1 = before.Where(x => x.VideoId == "four0").FirstOrDefault();
                if (data1.VideoId!=null)
                   // con.Query<Favorite>("DELETE FROM [DBBucketEntitiy] WHERE [id] = " + id);
              //  dbConn.Query<BucketItem>("DELETE FROM [DBBucketEntitiy] WHERE [id] = " + id);
                con.Delete<FavoriteData> (data1 );

                con.Commit();

                var after = con.Table<FavoriteData>().ToArray();

              var filename = "mydb.sqlite";
              //  SQLiteDatabase f;

            }
            catch (Exception ex)
            {
                
               // throw ex;
            }

           /* 

            string dbName = "mydb.sqlite";
            string dbPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName);
            // Check if your DB has already been extracted.
            if (!File.Exists(dbPath))
            {
                using (BinaryReader br = new BinaryReader(Android.App.Application.Context.Assets.Open(dbName)))
                {
                //    using (BinaryWriter bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                   // {
                       byte[] buffer = new byte[2048];
                        int len = 0;
                        while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                           // bw.Write(buffer, 0, len);
                        }
                    }
                //}
            }
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, filename);

            // create a write stream
            
            
               // raw.SetProvider(new SQLitePCL.SQLite3Provider_esqlite3());

           
                    // var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                                                                     // con = new SQLite.Net.SQLiteConnection(plat, path);
            String DATABASE_PATH = "/data/data/" + "MvvmCross_Application1.MvvmCross_Application1" + "/databases/" + "mydb.sqlite";
              // var  con = new SQLiteConnection(DATABASE_PATH);
                try {}
                catch (Exception ex)
                {
                    //con.dispose(false);
                    throw ex;
                }
                finally
                {

                    con.CreateTable<Favorite>();
                }

            //db.CreateTable<PersonName>();*/
            }
        
          

    }

    }

    




