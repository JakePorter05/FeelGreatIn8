using FeelGreatIn8.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FeelGreatIn8.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}