using SQLitePCL;
using System.Runtime.InteropServices;

namespace DailyTaskPlanner;

public class TaskItem
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public TimeSpan Time { get; set; }
    public bool IsCompleted { get; set; }
}