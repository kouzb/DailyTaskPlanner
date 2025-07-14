﻿namespace DailyTaskPlanner.Models;

public class MealTemplate
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Monday { get; set; } = string.Empty;
    public string Tuesday { get; set; } = string.Empty;
    public string Wednesday { get; set; } = string.Empty;
    public string Thursday { get; set; } = string.Empty;
    public string Friday { get; set; } = string.Empty;
    public string Saturday { get;set; } = string.Empty;
    public string Sunday { get; set; } = string.Empty;
}