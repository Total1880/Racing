using Racing.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Racing.UI.WPF
{
    /// <summary>
    /// Interaction logic for ShowRaceTracks.xaml
    /// </summary>
    public partial class ShowRaceTracks : Page
    {
        List<RaceTrack> allRaceTracks = new List<RaceTrack>();

        public ShowRaceTracks()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            allRaceTracks = DatabaseManager.Instance.RaceTrackRepository.GetAllRaceTracks().ToList();

            dgAllRaceTracks.ItemsSource = allRaceTracks;
        }

        private void BtnDeleteRaceTrack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RaceTrack raceTrack = (RaceTrack)dgAllRaceTracks.SelectedItem;

                DatabaseManager.Instance.RaceTrackRepository.DeleteRaceTrack(raceTrack);

                NavigationService.Navigate(new ShowRaceTracks());
            }
            catch (Exception)
            {
                MessageBox.Show("Select a racetrack");
            }
        }
    }
}
