using Autofac;
using MvvmCross_Application1.Core.Module;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross_Application1.Core.Data
{

    public class Bootstarpper
    {
        public IContainer Build(Dictionary<Type,Type> mappedtypes)
        {
            var cb = new ContainerBuilder();
            cb.RegisterModule<MyModule>();
            if (mappedtypes != null && mappedtypes.Any())
            {
                cb.RegisterModule(new MappedTypeModule(mappedtypes));
            }
            return cb.Build();


        }
    }

    public interface IDataService
    {
        void Insert();
        void Delete();

    }
    public class DataService:IDataService
    {
      //  private readonly SQLiteConnection connection;

        public void Delete()
        {
           // new SQLiteConnection(new SQLite.SQLite3., path);
            throw new NotImplementedException();
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }
    }

    /*public interface ISqlLite1
    {
         SQLiteConnection GetConnection();
    }
    public class SqlLiteAndroid : ISqlLite1
    {
        public SQLiteConnection conn;
        public SqlLiteAndroid()
        {

        }
        public SQLiteConnection GetConnection()
        {
            var filename = "TestDb.db3";
            string documentpath = Environment.GetFolderPath(Environment.SpecialFolder.System);
            var path = "/data/data/"
                Application.Context.PackageName;
            + getPackageName()
                + "/databases/";
            conn = new SQLiteConnection(path);

            return conn;
        }

        SQLiteConnection ISqlLite1.GetConnection()
        {
            throw new NotImplementedException();
        }
    }*/
  /*  public class DataBase
    {
        public SQLiteConnection connection;
        public DataBase()
        {
            var conn = new SqlLiteAndroid();
            connection = conn.GetConnection();
            connection.CreateTable<Favourites>();
        }

        public bool InsertIntoTableFavourities(Favourites fav)
        {
            try
            {
                connection.Insert(fav);
            }
            catch (SQLite.SQLiteException ex)
            {
                return false;
            }

            return true;
        }

    }*/
}
