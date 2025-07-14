using DailyTaskPlanner.Models;
using DailyTaskPlanner.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DailyTaskPlanner.ViewModels
{
    public partial class TemplatesPageViewModel : ObservableObject
    {
        private readonly TemplateService _templateService;

        [ObservableProperty]
        private List<MealTemplate> templates = new();

        public TemplatesPageViewModel()
        {
            _templateService = new TemplateService();
            LoadTemplates();
        }

        private async void LoadTemplates()
        {
            Templates = await _templateService.GetTemplatesAsync();
        }

        [RelayCommand]
        private async void CreateTemplate()
        {
            var template = new MealTemplate
            {
                Name = "Новый шаблон",
                Monday = "Завтрак: ..., Обед: ..., Ужин: ...",
                Tuesday = "Завтрак: ..., Обед: ..., Ужин: ...",
                Wednesday = "Завтрак: ..., Обед: ..., Ужин: ...",
                Thursday = "Завтрак: ..., Обед: ..., Ужин: ...",
                Friday = "Завтрак: ..., Обед: ..., Ужин: ..."
            };

            await _templateService.SaveTemplateAsync(template);
            await App.Current.MainPage.DisplayAlert("Готово", "Шаблон создан", "OK");
            LoadTemplates();
        }

        public async void ApplyTemplate(MealTemplate template)
        {
            var menuPage = new Views.MenuPlannerPage();
            var viewModel = menuPage.BindingContext as MenuPlannerPageViewModel;

            if (viewModel != null)
            {
                viewModel.MondayMenu = template.Monday;
                viewModel.TuesdayMenu = template.Tuesday;
                viewModel.WednesdayMenu = template.Wednesday;
                viewModel.ThursdayMenu = template.Thursday;
                viewModel.FridayMenu = template.Friday;
            }

            await Shell.Current.Navigation.PushAsync(menuPage);
        }
    }
}