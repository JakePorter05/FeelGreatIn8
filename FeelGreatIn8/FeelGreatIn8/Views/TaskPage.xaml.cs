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

        private void stepper_FruitVeg(object sender, ValueChangedEventArgs e)
        {
            viewModel.ChangeFruitVeg(e.NewValue);
        }

        private void stepper_Food(object sender, ValueChangedEventArgs e)
        {
            viewModel.ChangeFood(e.NewValue);
        }

        private void stepper_Water(object sender, ValueChangedEventArgs e)
        {
            viewModel.ChangeWater(e.NewValue);
        }
    }
}