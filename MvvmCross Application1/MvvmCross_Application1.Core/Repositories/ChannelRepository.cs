using MvvmCross_Application1.Core.DataBase;
using MvvmCross_Application1.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross_Application1.Core.Repositories
{
    public class ChannelRepository : LocalRepositoryAsyncBase<Channels>, IChannelRepository
    {
        public ChannelRepository(IDbConnectionManager connectionFactory)
            : base(connectionFactory)
        {
            var f = connectionFactory.GetConnection();
        }

        public Task<List<Channels>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Channels> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Channels>> ReadData()
        {
            var f = await ReadAll();
            return f;
        }



        public Task UpdateFavor(Channels channel)
        {
            throw new NotImplementedException();
        }
    }
}