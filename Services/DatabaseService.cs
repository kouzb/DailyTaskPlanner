using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DailyTaskPlanner.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "tasks.db");
            _database = new SQLiteAsyncConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

            _database.CreateTableAsync<TaskItem>().Wait();
        }

        public Task<List<TaskItem>> GetTasksAsync() =>
            _database.Table<TaskItem>().ToListAsync();

        public Task<int> SaveTaskAsync(TaskItem task) =>
            _database.InsertAsync(task);

        public Task<int> UpdateTaskAsync(TaskItem task) =>
            _database.UpdateAsync(task);

        public Task<int> DeleteTaskAsync(TaskItem task) =>
            _database.DeleteAsync(task);
    }
}