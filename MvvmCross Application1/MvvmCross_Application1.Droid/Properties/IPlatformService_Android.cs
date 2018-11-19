﻿using Android.Content;
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
        public SQLiteDatabase db;

        public void Insert(string VidId)
        {
            var f = con.GetTableInfo("Favor12");
            var before = con.Table<Favor12>().ToArray();

            var data1 = before.Where(x => x.VideoId == VidId).FirstOrDefault();

            /* if table is empty */
            if (before == null) 
            {
                con.Insert(new Favor12() { VideoId = VidId });
                con.Commit();
            }

            /* check wether videoid is already added */
            else if (data1 == null)
            {
                con.Insert(new Favor12() { VideoId = VidId });
                con.Commit();
            }

            var t = con.GetMapping<Favor12>().HasAutoIncPK.ToString();
             before = con.Table<Favor12>().ToArray();

        }

        public List<Favor12> Select()
        {

            var data = con.Table<Favor12>().ToList();
            return data;

        }


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


        public void GetConnection()
        {
            
            //string[] names = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames();
            var destinationPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydb.sqlite");
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

            
        }


    }

}






