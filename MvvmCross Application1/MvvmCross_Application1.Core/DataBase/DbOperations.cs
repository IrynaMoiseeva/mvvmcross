using System;
using System.Collections.Generic;
using System.Linq;
using MvvmCross_Application1.Core.Model;

namespace MvvmCross_Application1.Core.DataBase
{
    public  class DbOperations
    {
        public string DestinationPath { get; set; }

        public SQLite.SQLiteConnection con;
       

        public DbOperations(SQLite.SQLiteConnection conection)
        {
            con = conection;
        }

        public void Insert(string VidId, Type modelType )
        {
            var f = con.GetTableInfo(modelType.ToString());
         /*  var before = con.Table<Favor12>.ToArray();

            var data1 = before.Where(x => x.VideoId == VidId).FirstOrDefault();

           
            if (before == null) 
            {
                con.Insert(new Favor12() { VideoId = VidId });
                con.Commit();
            }

            /* check wether videoid is already added */
          /* else if (data1 == null)
            {
                con.Insert(new Favor12() { VideoId = VidId });
                con.Commit();
            }

            var t = con.GetMapping<Favor12>().HasAutoIncPK.ToString();
             before = con.Table<Favor12>().ToArray();
*/
        }

        //public  List<TEntity> Select<TEntity>(BaseEntity obj) where TEntity : IEntity
        //   public abstract List<TEntity> Select<TEntity>(TEntity obj) where TEntity : IEntity;
        //  public List<E> Select() 
        //public string ABC<T>(T obj) where T : IDestination
       /* public List<Favor12> Select()
        {

            var data = con.Table<Favor12>().ToList();
            return data;

        }*/

        public void Remove(string VidId)
        {
            var before = con.Table<Favor12>().ToArray();

            var data1 = before.Where(x => x.VideoId == VidId).FirstOrDefault();

            if (data1 != null)

            {
                con.Delete<Favor12>(data1.Id);

                con.Commit();
            }
        }


      /*  public void GetConnection()
        {
            
            //string[] names = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames();
            var destinationPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydb.sqlite");
            DestinationPath = destinationPath;
            using (Stream source = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MvvmCross_Application1.Droid.Resources.raw.mydb.sqlite"))
            {
                using (var destination = System.IO.File.Create(destinationPath))
                {
                    source.CopyTo(destination);
                }
            }
            try
            {

                 con = new SQLiteConnection(destinationPath);


                con.CreateTable<Favor12>(SQLite.CreateFlags.ImplicitPK | SQLite.CreateFlags.AutoIncPK);

            }
            catch (Exception ex)
            {

                con.Dispose();
            }

            
        }*/

        public List<Favor12> Select()
        {
            var data = con.Table<Favor12>().ToList();
            return data;

        }
    }

}







   

