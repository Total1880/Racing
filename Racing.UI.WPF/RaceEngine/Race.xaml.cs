﻿using Racing.BL.Models;
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
        List<RaceParticipant> listOfParticipants = new List<RaceParticipant>();

        public Race(List<Driver> inputListOfDrivers, RaceTrack inputRaceTrack)
        {
            InitializeComponent();

            race = new BL.Models.Race(inputListOfDrivers, inputRaceTrack);

            DatabaseManager.Instance.RaceRepository.CreateRace(race);

            foreach (var driver in inputListOfDrivers)
            {
                RaceParticipant participant = new RaceParticipant(driver);

                listOfParticipants.Add(participant);
            }

            dgParticipants.ItemsSource = listOfParticipants;
        }

        private IEnumerable<RaceParticipant> Turn(List<RaceParticipant> raceParticipants)
        {
            Random random = new Random();
            foreach (var participant in raceParticipants)
            {
                participant.Distance += random.Next(0, participant.Speed);
            }

            return raceParticipants.OrderByDescending(x => x.Distance);
        }

        private void BtnNextTurn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            listOfParticipants = Turn(listOfParticipants).ToList();

            dgParticipants.ItemsSource = listOfParticipants;
        }
    }
}
