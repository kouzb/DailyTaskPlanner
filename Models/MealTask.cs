using SQLite;

namespace DailyTaskPlanner.Models;

public class MealTask
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string DayOfWeek { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public TimeSpan Time { get; set; }
    public bool IsCompleted { get; set; }
}