using Android.Database.Sqlite;
using MvvmCross_Application1.Core.Model;
using MvvmCross_Application1.Core.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MvvmCross_Application1.Droid.Properties
{

   

    public class PlatformService_Android : IPlatformService
    {
        public string GetPlatform() { return "android"; }

        public string DestinationPath
        {
            get { return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydb.sqlite"); }
        }
       



        public SQLiteConnection con;
        public SQLiteDatabase db;

        public void Insert(string VidId)
        {
            var f = con.GetTableInfo("FavoriteVideos");
            var before = con.Table<FavoriteVideos>().ToArray();

            var data1 = before.Where(x => x.VideoId == VidId).FirstOrDefault();

            /* if table is empty */
            if (before == null) 
            {
                con.Insert(new FavoriteVideos() { VideoId = VidId });
                con.Commit();
            }

            /* check wether videoid is already added */
            else if (data1 == null)
            {
                con.Insert(new FavoriteVideos() { VideoId = VidId });
                con.Commit();
            }

            var t = con.GetMapping<FavoriteVideos>().HasAutoIncPK.ToString();
             before = con.Table<FavoriteVideos>().ToArray();

        }

        //public  List<TEntity> Select<TEntity>(BaseEntity obj) where TEntity : IEntity
        //   public abstract List<TEntity> Select<TEntity>(TEntity obj) where TEntity : IEntity;
        //  public List<E> Select() 
        //public string ABC<T>(T obj) where T : IDestination
        /* public List<FavoriteVideos> Select()
         {

             var data = con.Table<FavoriteVideos>().ToList();
             return data;

         }*/

     /*   public void RemoveTable ()
        {
            try
            {
                int f = con.DropTable<Channels>();
                var f1 = con.CreateTable<Channels>(SQLite.CreateFlags.ImplicitPK | SQLite.CreateFlags.AutoIncPK);
            }

            catch (Exception ex)
            {

                con.Dispose();
            }
        }
        */


        public void Remove(string VidId)
        {
            var before = con.Table<FavoriteVideos>().ToArray();

            var data1 = before.Where(x => x.VideoId == VidId).FirstOrDefault();

            if (data1 != null)

            {
                con.Delete<FavoriteVideos>(data1.Id);

                con.Commit();
            }
        }


        public void GetConnection()
        {
            
            string[] names = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames();
            var destinationPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydb.sqlite");
            //DestinationPath = destinationPath;
           /* using (Stream source = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MvvmCross_Application1.Droid.Resources.raw.mydb.sqlite"))
            {
                using (var destination = System.IO.File.Create(destinationPath))
                {
                    source.CopyTo(destination);
                }
            }
            try
            {

                 con = new SQLiteConnection(destinationPath);


                con.CreateTable<FavoriteVideos>(SQLite.CreateFlags.ImplicitPK | SQLite.CreateFlags.AutoIncPK);

            }
            catch (Exception ex)
            {

                con.Dispose();
            }
*/
            
        }

        public List<FavoriteVideos> Select()
        {
            var data = con.Table<FavoriteVideos>().ToList();
            return data;

        }
    }

}






