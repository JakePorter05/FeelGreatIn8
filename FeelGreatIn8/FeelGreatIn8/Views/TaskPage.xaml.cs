using FeelGreatIn8.ViewModels;
using Xamarin.Forms;

namespace FeelGreatIn8.Views
{
    public partial class TaskPage : ContentPage
    {
        public TaskPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as TaskViewModel).OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            (BindingContext as TaskViewModel).Disappearing();
        }
    }
}