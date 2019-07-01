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

        public Race(List<Driver> inputListOfDrivers, RaceTrack inputRaceTrack)
        {
            InitializeComponent();

            btnNextRace.IsEnabled = false;

            foreach (var driver in inputListOfDrivers)
            {
                RaceParticipant participant = new RaceParticipant(driver);

                listOfParticipants.Add(participant);
            }

            race = new BL.Models.Race(listOfParticipants, inputRaceTrack);
            raceEngine = new RaceLogic(race.RaceLength);

            dgParticipants.ItemsSource = listOfParticipants;
        }

        private void BtnNextTurn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            listOfParticipants = raceEngine.Turn(listOfParticipants).ToList();

            btnNextTurn.IsEnabled = raceEngine.IsRaceFinished(listOfParticipants);

            if (btnNextTurn.IsEnabled == false)
            {
                listOfParticipants = raceEngine.SetFinalPositionParticipants(listOfParticipants).ToList();
                race.SetParticipantsFinalPosition(listOfParticipants);
                DatabaseManager.Instance.RaceRepository.CreateRace(race);
            }

            dgParticipants.ItemsSource = listOfParticipants;
        }

        private void BtnNextRace_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
