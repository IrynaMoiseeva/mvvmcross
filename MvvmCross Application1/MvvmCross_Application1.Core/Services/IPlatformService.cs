﻿using MvvmCross_Application1.Core.DataBase;
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
        string DestinationPath { get; }
       string GetPlatform();

        void GetConnection();
        void Insert(string VidId);
        void Remove(string VidId);
       // void RemoveTable();
       
    List<Favor12> Select();

    }

    public abstract class PlatformService : IPlatformService
    {
        string IPlatformService.DestinationPath { get; }

        public abstract string GetPlatform();// { return "dddd"; }

        void IPlatformService.Insert(string VidId) { }
        void IPlatformService.Remove(string VidId) { }
        void IPlatformService.GetConnection() { }
        //  public abstract List<TEntity> Select<TEntity>(TEntity obj) where TEntity :  IEntity;
        public abstract List<Favor12> Select();

     //   public abstract void RemoveTable();


       
        /*{
            var b = "kuku";
            return null;
            }
*/

    }
}
