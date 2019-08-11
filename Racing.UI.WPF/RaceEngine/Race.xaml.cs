using Racing.BL.Models;
using Racing.BL.RaceEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Racing.UI.WPF.RaceEngine
{
    /// <summary>
    /// Interaction logic for Race.xaml
    /// </summary>
    public partial class Race : Page
    {
        BL.Models.Race race;
        RaceLogic raceEngine;
        List<RaceParticipant> listOfParticipants = new List<RaceParticipant>();
        int raceNumber;
        int seasonId;

        public Race(List<Driver> inputListOfDrivers, RaceTrack inputRaceTrack)
        {
            InitializeComponent();

            btnFinishRace.IsEnabled = false;

            foreach (var driver in inputListOfDrivers)
            {
                RaceParticipant participant = new RaceParticipant(driver);

                listOfParticipants.Add(participant);
            }

            race = new BL.Models.Race(listOfParticipants, inputRaceTrack);
            raceEngine = new RaceLogic(race.RaceLength);

            dgParticipants.ItemsSource = listOfParticipants;
        }

        public Race(List<Driver> inputListOfDrivers, RaceTrack inputRaceTrack, int raceNumber, int seasonId) : this (inputListOfDrivers, inputRaceTrack)
        {
            this.raceNumber = raceNumber;
            this.seasonId = seasonId;
        }

        private void BtnNextTurn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            listOfParticipants = raceEngine.Turn(listOfParticipants).ToList();

            btnNextTurn.IsEnabled = raceEngine.IsRaceFinished(listOfParticipants);

            if (btnNextTurn.IsEnabled == false)
            {
                listOfParticipants = raceEngine.SetFinalPositionParticipants(listOfParticipants).ToList();
                race.SetParticipantsFinalPosition(listOfParticipants);
                DatabaseManager.Instance.RaceRepository.CreateRace(race, seasonId);
                btnFinishRace.IsEnabled = true;
            }

            dgParticipants.ItemsSource = listOfParticipants;
        }

        private void BtnFinishRace_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new SeasonPage(seasonId));
        }
    }
}
