﻿using Racing.BL.Models;
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
        Season thisSeason;

        public SeasonPage(int raceNumber, int seasonId)
        {
            InitializeComponent();

            seasonRaceNumber = raceNumber;
            this.seasonId = seasonId;
            thisSeason = new Season(seasonId);
            List<Race> seasonRaces = new List<Race>();

            seasonRaces = DatabaseManager.Instance.SeasonRepository.GetRacesFromSeason(seasonId);

            DatabaseManager.Instance.SeasonRepository.CreateNewSeason(seasonId);
            thisSeason.CalculateTable(seasonRaces, seasonParticipants);

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

        
    }
}
