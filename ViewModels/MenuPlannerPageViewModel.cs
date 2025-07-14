using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DailyTaskPlanner.Models;
using System;

namespace DailyTaskPlanner.ViewModels
{
    public partial class MenuPlannerPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string mondayMenu = string.Empty;

        [ObservableProperty]
        private string tuesdayMenu = string.Empty;

        [ObservableProperty]
        private string wednesdayMenu = string.Empty;

        [ObservableProperty]
        private string thursdayMenu = string.Empty;

        [ObservableProperty]
        private string fridayMenu = string.Empty;

        [ObservableProperty]
        private string saturdayMenu = string.Empty;

        [ObservableProperty]
        private string sundayMenu = string.Empty;

        [RelayCommand]
        private async void Save()
        {
            Preferences.Default.Set("MondayMenu", MondayMenu);
            Preferences.Default.Set("TuesdayMenu", TuesdayMenu);
            Preferences.Default.Set("WednesdayMenu", WednesdayMenu);
            Preferences.Default.Set("ThursdayMenu", ThursdayMenu);
            Preferences.Default.Set("FridayMenu", FridayMenu);
            Preferences.Default.Set("SaturdayMenu", SaturdayMenu);
            Preferences.Default.Set("SundayMenu", SundayMenu);

            await App.Current.MainPage.DisplayAlert("Сохранено", "Меню на неделю сохранено", "OK");
        }
    }
}