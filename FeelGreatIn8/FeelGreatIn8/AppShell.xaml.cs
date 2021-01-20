using FeelGreatIn8.Views;
using Xamarin.Forms;

namespace FeelGreatIn8
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TaskPage), typeof(TaskPage));
        }
    }
}
