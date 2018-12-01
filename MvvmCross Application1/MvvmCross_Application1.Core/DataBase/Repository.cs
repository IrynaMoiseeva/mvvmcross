﻿
using System;
using System.Collections.Generic;

using SQLite.Net;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SQLite;

namespace MvvmCross_Application1.Core.DataBase
{
    public interface IRepository<T> where T : class, new()
    {
        Task<List<T>> Get();
        Task<T> Get(int id);
        Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);
        Task<T> Get(Expression<Func<T, bool>> predicate);
        AsyncTableQuery<T> AsQueryable();
        Task<int> Insert(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
    }

    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private SQLiteAsyncConnection db;

        public Repository(SQLiteAsyncConnection db)
        {
            this.db = db;
        }

        public AsyncTableQuery<T> AsQueryable() =>
            db.Table<T>();

        public async Task<List<T>> Get()
        {
            try
            {


                //var list = db.Table<T>().
                return await db.Table<T>().ToListAsync();//.ConfigureAwait(false);
            }
            catch (Exception e)
            {
                var f = e;
                return null;
            }

            //return  db.Table<T>().ToListAsync();
        }

        public async Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = db.Table<T>();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = query.OrderBy<TValue>(orderBy);

            return await query.ToListAsync();
        }

        public async Task<T> Get(int id) =>
             await db.FindAsync<T>(id);

        public async Task<T> Get(Expression<Func<T, bool>> predicate) =>
            await db.FindAsync<T>(predicate);

        public async Task<int> Insert(T entity) =>
             await db.InsertAsync(entity);

        public async Task<int> Update(T entity) =>
             await db.UpdateAsync(entity);

        public async Task<int> Delete(T entity) =>
             await db.DeleteAsync(entity);
    }
}

