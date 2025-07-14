using DailyTaskPlanner.Services;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace DailyTaskPlanner;

public partial class MainPage : ContentPage
{
    private readonly DatabaseService _db = new();
    private ObservableCollection<TaskItem> _tasks = new();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private async Task LoadTasks()
    {
        var tasks = await _db.GetTasksAsync();

        var activeTasks = tasks
            .Where(t => !t.IsCompleted)
            .OrderBy(t => t.Time)
            .ToList();

        var completedTasks = tasks
            .Where(t => t.IsCompleted)
            .ToList();

        _tasks.Clear();

        foreach (var task in activeTasks)
            _tasks.Add(task);

        foreach (var task in completedTasks)
            _tasks.Add(task);

        TaskList.ItemsSource = null;
        TaskList.ItemsSource = _tasks;
    }

    private async void OnAddTaskClicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(TaskTitle.Text))
            {
                await DisplayAlert("Ошибка", "Введите название задачи", "OK");
                return;
            }

            var task = new TaskItem
            {
                Title = TaskTitle.Text,
                Time = TaskTime.Time,
                IsCompleted = false
            };

            await _db.SaveTaskAsync(task); 
            await NotificationService.ScheduleTaskNotification(task);
            await LoadTasks();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ошибка", ex.Message, "OK");
        }
    }

    private async void OnTaskCompleted(object sender, CheckedChangedEventArgs e)
    {
        var checkBox = sender as CheckBox;
        var task = checkBox?.BindingContext as TaskItem;

        if (task != null)
        {
            await _db.UpdateTaskAsync(task);
        }
    }

    private async void OnTaskDeleteClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var task = button?.CommandParameter as TaskItem;

        if (task != null)
        {
            await _db.DeleteTaskAsync(task); 
            await LoadTasks();
        }
    }

    private async void OnSettingsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.SettingsPage());
    }
}