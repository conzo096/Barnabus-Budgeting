﻿using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barnabus_Budgeting.Backend
{
    public static class Constants
    {
        public const string DatabaseFilename = "BarnabusBudgetingSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }

    public static class TaskExtensions
    {
        // NOTE: Async void is intentional here. This provides a way
        // to call an async method from the constructor while
        // communicating intent to fire and forget, and allow
        // handling of exceptions
        public static async void SafeFireAndForget(this Task task,
            bool returnToCallingContext,
            Action<Exception> onException = null)
        {
            try
            {
                await task.ConfigureAwait(returnToCallingContext);
            }

            // if the provided action is not null, catch and
            // pass the thrown exception
            catch (Exception ex) when (onException != null)
            {
                onException(ex);
            }
        }
    }

    public class BarnabusDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public BarnabusDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(UserGoal).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, new [] {typeof(UserGoal), typeof(IncomeTransaction), typeof(ExpenseTransaction) } ).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public List<T> GetItems<T>() where T : new()
        {
            return Database.Table<T>().ToListAsync().Result;
        }

        public Task<int> SaveItemAsync<T>(T item) where T : DatabaseItem, new()
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync<T>(T item)
        {
            return Database.DeleteAsync(item);
        }

    }
}
