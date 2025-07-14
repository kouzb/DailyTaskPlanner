using Microsoft.Maui.Controls;
using DailyTaskPlanner.Models;
using DailyTaskPlanner.Services;
using DailyTaskPlanner.ViewModels;

namespace DailyTaskPlanner.Views
{
    public partial class TemplatesPage : ContentPage
    {
        public TemplatesPage()
        {
            InitializeComponent();
            BindingContext = new TemplatesPageViewModel();
        }

        private void OnApplyTemplateClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var template = button?.CommandParameter as MealTemplate;

            if (template != null)
            {
                ((TemplatesPageViewModel)BindingContext).ApplyTemplate(template);
            }
        }
    }
}