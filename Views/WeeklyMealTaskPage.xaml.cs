using Microsoft.Maui.Controls;
using DailyTaskPlanner.Models;
using DailyTaskPlanner.Services;

namespace DailyTaskPlanner.Views
{
    public partial class WeeklyMealTaskPage : ContentPage
    {
        public WeeklyMealTaskPage()
        {
            InitializeComponent();
            BindingContext = new WeeklyMealTaskPageViewModel();
        }

        private async void OnDeleteTaskClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var task = button?.CommandParameter as MealTask;

            if (task != null)
            {
                var service = new MealTaskService();
                await service.DeleteTaskAsync(task);

                // Обнови список задач на странице
                var viewModel = BindingContext as WeeklyMealTaskPageViewModel;
                if (viewModel != null)
                {
                    // Например, убери задачу из MondayTasks
                    viewModel.MondayTasks.Remove(viewModel.MondayTasks.FirstOrDefault(t => t.Id == task.Id));
                }
            }
        }
    }
}