﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross_Application1.Core.DataBase;
using MvvmCross_Application1.Core.Model;

namespace MvvmCross_Application1.Core.Repositories
{

    public class FavorRepository: LocalRepositoryAsyncBase<FavoriteVideos>, IFavorRepository 
    {
        public FavorRepository(IDbConnectionManager connectionFactory)
            : base(connectionFactory)
        {
          
        }

        public Task<List<FavoriteVideos>> Get()
        {
            throw new NotImplementedException();

        }
        public async Task UpdateFavor(FavoriteVideos favor)
        {
            await UpdateOrCreate(favor);
        }
        public Task<FavoriteVideos> Get(int id)
        {
            throw new NotImplementedException();
        }
       
         public async Task<IEnumerable<FavoriteVideos>> ReadData() 
        {
            var f= await ReadAll();
            return f;
        }

    }
}
