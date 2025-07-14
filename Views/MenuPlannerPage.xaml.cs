using DailyTaskPlanner.ViewModels;

namespace DailyTaskPlanner.Views;

public partial class MenuPlannerPage : ContentPage
{
    public MenuPlannerPage()
    {
        InitializeComponent();
        BindingContext = new MenuPlannerPageViewModel();

        var viewModel = new MenuPlannerPageViewModel
        {
            MondayMenu = Preferences.Default.Get("MondayMenu", ""),
            TuesdayMenu = Preferences.Default.Get("TuesdayMenu", ""),
            WednesdayMenu = Preferences.Default.Get("WednesdayMenu", ""),
            ThursdayMenu = Preferences.Default.Get("ThursdayMenu", ""),
            FridayMenu = Preferences.Default.Get("FridayMenu", ""),
            SaturdayMenu = Preferences.Default.Get("SaturdayMenu", ""),
            SundayMenu = Preferences.Default.Get("SundayMenu","")
        };
    }
}