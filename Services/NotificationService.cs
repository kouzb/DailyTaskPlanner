using Plugin.LocalNotification;

namespace DailyTaskPlanner;

public static class NotificationService
{
    public static async Task ScheduleTaskNotification(TaskItem task)
    {
        var notification = new NotificationRequest
        {
            NotificationId = task.Id,
            Title = "Напоминание",
            Description = task.Title,
            ReturningData = $"task:{task.Id}",
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Today.Add(task.Time)
            }
        };

        await LocalNotificationCenter.Current.Show(notification);
    }

    public static void CancelTaskNotification(int taskId)
    {
        LocalNotificationCenter.Current.Cancel(taskId);
    }
}