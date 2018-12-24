using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross_Application1.Core.DataBase;
using MvvmCross_Application1.Core.Model;

namespace MvvmCross_Application1.Core.Repositories
{
   public interface IFavorRepository:  ILocalRepositoryOperations<FavoriteVideos>
    {
        Task<List<FavoriteVideos>> Get();
        Task<FavoriteVideos> Get(int id);
        Task UpdateFavor(FavoriteVideos favor);

    }
}
