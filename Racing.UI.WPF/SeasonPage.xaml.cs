using Racing.BL.Models;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using System.Windows;

namespace Racing.UI.WPF
{
    /// <summary>
    /// Interaction logic for SeasonPage.xaml
    /// </summary>
    public partial class SeasonPage : Page
    {
        List<RaceTrack> seasonTracks = new List<RaceTrack>();
        List<Driver> listOfDrivers = new List<Driver>();
        int seasonRaceNumber;
        readonly int seasonId;
        List<SeasonParticipant> seasonParticipants = new List<SeasonParticipant>();
        Season thisSeason;

        public SeasonPage(int seasonId)
        {
            InitializeComponent();

            this.seasonId = seasonId;
            thisSeason = new Season(seasonId);
            List<Race> seasonRaces = new List<Race>();

            seasonRaces = DatabaseManager.Instance.SeasonRepository.GetRacesFromSeason(seasonId);
            seasonRaceNumber = seasonRaces.Count();

            DatabaseManager.Instance.SeasonRepository.CreateNewSeason(seasonId);
            thisSeason.CalculateTable(seasonRaces, seasonParticipants);

            seasonTracks = DatabaseManager.Instance.RaceTrackRepository.GetAllRaceTracks().ToList();
            listOfDrivers = DatabaseManager.Instance.DriverRepository.GetAllDrivers().ToList();
            dgTable.ItemsSource = seasonParticipants;

            if (seasonRaceNumber >= seasonTracks.Count())
            {
                lblNextRace.Content = "Season finished";
                btnNextRace.IsEnabled = false;
                btnNextSeason.Visibility = Visibility.Visible;
            }
            else
            {
                lblNextRace.Content = "Next race: " + seasonTracks[seasonRaceNumber].Name;
            }
        }

        private void BtnNextRace_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new RaceEngine.Race(listOfDrivers, seasonTracks[seasonRaceNumber], seasonRaceNumber, seasonId));
        }

        private void BtnNextSeason_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            int newSeasonId = seasonId + 1;

            NavigationService.Navigate(new SeasonPage(newSeasonId));
        }
    }
}
