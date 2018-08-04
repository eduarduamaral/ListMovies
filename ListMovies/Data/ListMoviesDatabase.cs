//using System;
//using SQLite;
//using ListMovies.Models;
//using System.Threading.Tasks;
//using System.Collections.Generic;

//namespace ListMovies.Data
//{
//    public class ListMoviesDatabase
//    {
//        readonly SQLiteAsyncConnection database;

//        public ListMoviesDatabase(string dbPath)
//        {
//            database = new SQLiteAsyncConnection(dbPath);
//            database.CreateTableAsync<FavoriteMovies>().Wait();
//        }

//        public Task<List<FavoriteMovies>> GetItemsAsync()
//        {
//            return database.Table<FavoriteMovies>().ToListAsync();
//        }

//        public Task<int> SaveItemAsync(FavoriteMovies item)
//        {
//            if (item.id != 0)
//            {
//                return database.UpdateAsync(item);
//            }
//            else
//            {
//                return database.InsertAsync(item);
//            }
//        }
//    }
//}