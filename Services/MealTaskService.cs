using DailyTaskPlanner.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DailyTaskPlanner.Services
{
    public class MealTaskService
    {
        private readonly SQLiteAsyncConnection _database;

        public MealTaskService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "meal_tasks.db");
            _database = new SQLiteAsyncConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

            _database.CreateTableAsync<MealTask>().Wait();
        }

        public Task<List<MealTask>> GetTasksForDay(string day) =>
            _database.Table<MealTask>().Where(t => t.DayOfWeek == day).ToListAsync();

        public Task<int> SaveTaskAsync(MealTask task) =>
            _database.InsertAsync(task);

        public Task<int> UpdateTaskAsync(MealTask task) =>
            _database.UpdateAsync(task);

        public Task<int> DeleteTaskAsync(MealTask task) =>
            _database.DeleteAsync(task);
    }
}