using MvvmCross_Application1.Core.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross_Application1.Core.Repositories
{
    class VideoRepository
    {
      /*  private readonly SQLiteAsyncConnection conn;

        public string StatusMessage { get; set; }

        public VideoRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Video>().Wait();
        }

        public async Task CreateBill(Video video)
        {
            try
            {
                // Basic validation to ensure we have a url.
                if (string.IsNullOrWhiteSpace(video.Url))
                    throw new Exception("url is required");

                // Insert a new customer bill into the database
                var result = await conn.InsertAsync(video).ConfigureAwait(continueOnCapturedContext: false);
                //StatusMessage = $"{result} record(s) added [Customer Email: {bill.CustomerEmail})";
            }
            catch (Exception ex)
            {
               // StatusMessage = $"Failed to create {bill.CustomerEmail}'s bill. Error: {ex.Message}";
            }
        }

        public Task<List<Video>> GetAllVideos()
        {
            // Return a list of bills saved to the Bill table in the database.
            return conn.Table<Video>().ToListAsync();
        }*/
    }
}
