using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace DailyTaskPlanner.ViewModels
{
    public partial class SettingsPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool areNotificationsEnabled = true;

        [ObservableProperty]
        private bool soundEnabled = true;

        [ObservableProperty]
        private bool vibrationEnabled = true;

        [ObservableProperty]
        private string selectedReminderTime = "За 10 минут";

        public ObservableCollection<string> ReminderTimes { get; set; }

        public SettingsPageViewModel()
        {
            ReminderTimes = new ObservableCollection<string>
            {
                "Не напоминать",
                "За 5 минут",
                "За 10 минут",
                "За 15 минут"
            };
        }

        [RelayCommand]
        private void Save()
        {
            Preferences.Default.Set("AreNotificationsEnabled", AreNotificationsEnabled);
            Preferences.Default.Set("SoundEnabled", SoundEnabled);
            Preferences.Default.Set("VibrationEnabled", VibrationEnabled);

            Preferences.Default.Set("SelectedReminderTime", SelectedReminderTime ?? "За 10 минут");

            App.Current.MainPage.DisplayAlert("Сохранено", "Настройки обновлены", "OK");
        }
    }
}