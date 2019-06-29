﻿using Racing.BL.Models;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;

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

        public SeasonPage(int raceNumber)
        {
            InitializeComponent();

            seasonRaceNumber = raceNumber;

            seasonTracks = DatabaseManager.Instance.RaceTrackRepository.GetAllRaceTracks().ToList();
            listOfDrivers = DatabaseManager.Instance.DriverRepository.GetAllDrivers().ToList();

            lblNextRace.Content = "Next race: " + seasonTracks[seasonRaceNumber].Name;
        }

        private void BtnNextRace_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Race(listOfDrivers, seasonTracks[seasonRaceNumber]));
        }
    }
}
