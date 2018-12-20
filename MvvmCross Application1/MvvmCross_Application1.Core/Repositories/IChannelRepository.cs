using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross_Application1.Core.DataBase;
using MvvmCross_Application1.Core.Model;

namespace MvvmCross_Application1.Core.Repositories
{
    public interface IChannelRepository:  ILocalRepositoryOperations<Channels>
    {
        Task<List<Channels>> Get();

    }
}
