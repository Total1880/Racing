using System.Windows;
using System.Windows.Controls;

namespace Racing.UI.WPF
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Page
    {
        public UserWindow()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            frmUserFrame.NavigationService.Navigate(new ShowDrivers());
        }

        private void BtnAddDriver_Click(object sender, RoutedEventArgs e)
        {
            frmUserFrame.NavigationService.Navigate(new NewDriver());
        }

        private void BtnStartScreen_Click(object sender, RoutedEventArgs e)
        {
            frmUserFrame.NavigationService.Navigate(new ShowDrivers());
        }

        private void BtnShowAllRaceTracks_Click(object sender, RoutedEventArgs e)
        {
            frmUserFrame.NavigationService.Navigate(new ShowRaceTracks());
        }
    }
}
