using FeelGreatIn8.ViewModels;
using Xamarin.Forms;

namespace FeelGreatIn8.Views
{
    public partial class TaskPage : ContentPage
    {
        TaskViewModel viewModel;

        public TaskPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new TaskViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            viewModel.Disappearing();
        }
    }
}