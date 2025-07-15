using DailyTaskPlanner.Models;
using DailyTaskPlanner.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace DailyTaskPlanner.ViewModels
{
    public partial class WeeklyMealTaskPageViewModel : ObservableObject
    {
        private readonly MealTaskService _taskService = new();

        public ObservableCollection<MealTask> MondayTasks { get; set; } = new();
        public ObservableCollection<MealTask> TuesdayTasks { get; set; } = new();
        public ObservableCollection<MealTask> WednesdayTasks { get; set; } = new();
        public ObservableCollection<MealTask> ThursdayTasks { get; set; } = new();
        public ObservableCollection<MealTask> FridayTasks { get; set; } = new();
        public ObservableCollection<MealTask> SaturdayTasks { get; set; } = new();
        public ObservableCollection<MealTask> SundayTasks { get; set; } = new();

        public WeeklyMealTaskPageViewModel()
        {
            LoadTasks();
        }

        private async void LoadTasks()
        {
            var allTasks = await _taskService.GetTasksForDay("Понедельник");
            foreach (var task in allTasks)
                MondayTasks.Add(task);
        }

        [RelayCommand]
        private async void AddTask(string day)
        {
            // Логика добавления новой задачи
        }

        [RelayCommand]
        private async void ToggleTask(MealTask task)
        {
            task.IsCompleted = !task.IsCompleted;
            await _taskService.UpdateTaskAsync(task);
        }

        [RelayCommand]
        private async void DeleteTask(MealTask task)
        {
            await _taskService.DeleteTaskAsync(task);
        }
    }
}