using Racing.UI.WPF.RaceEngine;
using System.Windows;
using System.Windows.Controls;

namespace Racing.UI.WPF
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Page
    {

        int seasonId = DatabaseManager.Instance.SeasonRepository.GetSeasonNumber();

        public UserWindow()
        {
            InitializeComponent();

            if (seasonId < 1)
            {
                seasonId = 0;
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            frmUserFrame.NavigationService.Navigate(new ShowDrivers());
        }

        private void BtnStartScreen_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnShowAllDriver_Click(object sender, RoutedEventArgs e)
        {
            frmUserFrame.NavigationService.Navigate(new ShowDrivers());
        }

        private void BtnShowAllRaceTracks_Click(object sender, RoutedEventArgs e)
        {
            frmUserFrame.NavigationService.Navigate(new ShowRaceTracks());
        }

        private void BtnRace_Click(object sender, RoutedEventArgs e)
        {
            frmUserFrame.NavigationService.Navigate(new StartingConditions());
        }

        private void BtnNewSeason_Click(object sender, RoutedEventArgs e)
        {
            frmUserFrame.NavigationService.Navigate(new SeasonPage(0, seasonId++));
        }
    }
}
