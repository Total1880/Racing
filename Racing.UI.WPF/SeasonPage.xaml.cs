using Racing.BL.Models;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using System;

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

        public SeasonPage(int raceNumber, int seasonId)
        {
            InitializeComponent();

            seasonRaceNumber = raceNumber;
            this.seasonId = seasonId;

            DatabaseManager.Instance.SeasonRepository.CreateNewSeason(seasonId);
            CalculateTable();

            seasonTracks = DatabaseManager.Instance.RaceTrackRepository.GetAllRaceTracks().ToList();
            listOfDrivers = DatabaseManager.Instance.DriverRepository.GetAllDrivers().ToList();
            dgTable.ItemsSource = seasonParticipants;

            if (seasonRaceNumber >= seasonTracks.Count())
            {
                lblNextRace.Content = "Season finished";
                btnNextRace.IsEnabled = false;
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

        private void CalculateTable()
        {
            List<Race> seasonRaces = new List<Race>();

            seasonRaces = DatabaseManager.Instance.SeasonRepository.GetRacesFromSeason(seasonId);

            foreach (var seasonRace in seasonRaces)
            {
                foreach (var driver in seasonRace.ListOfParticipants)
                {
                    bool driverAlreadyInTable = false;

                    foreach (var seasonParticipant in seasonParticipants)
                    {
                        if (seasonParticipant.DriverId == driver.DriverId)
                        {
                            driverAlreadyInTable = true;

                            switch (driver.Position)
                            {
                                case 1:
                                    seasonParticipant.Points += 5;
                                    break;
                                case 2:
                                    seasonParticipant.Points += 4;
                                    break;
                                case 3:
                                    seasonParticipant.Points += 3;
                                    break;
                                case 4:
                                    seasonParticipant.Points += 2;
                                    break;
                                case 5:
                                    seasonParticipant.Points += 1;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    if (!driverAlreadyInTable)
                    {
                        SeasonParticipant newSeasonParticipant = new SeasonParticipant(driver);

                        switch (driver.Position)
                        {
                            case 1:
                                newSeasonParticipant.Points += 5;
                                break;
                            case 2:
                                newSeasonParticipant.Points += 4;
                                break;
                            case 3:
                                newSeasonParticipant.Points += 3;
                                break;
                            case 4:
                                newSeasonParticipant.Points += 2;
                                break;
                            case 5:
                                newSeasonParticipant.Points += 1;
                                break;
                            default:
                                break;
                        }

                        seasonParticipants.Add(newSeasonParticipant);
                    }
                }
            }
        }
    }
}
