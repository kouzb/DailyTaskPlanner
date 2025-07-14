using DailyTaskPlanner.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DailyTaskPlanner.Services
{
    public class TemplateService
    {
        private readonly SQLiteAsyncConnection _database;

        public TemplateService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "templates.db");
            _database = new SQLiteAsyncConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

            _database.CreateTableAsync<MealTemplate>().Wait();
        }

        public Task<List<MealTemplate>> GetTemplatesAsync() =>
            _database.Table<MealTemplate>().ToListAsync();

        public Task<int> SaveTemplateAsync(MealTemplate template) =>
            _database.InsertAsync(template);

        public Task<int> UpdateTemplateAsync(MealTemplate template) =>
            _database.UpdateAsync(template);

        public Task<int> DeleteTemplateAsync(MealTemplate template) =>
            _database.DeleteAsync(template);
    }
}