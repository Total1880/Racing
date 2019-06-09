using Racing.BL.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Racing.UI.WPF
{
    /// <summary>
    /// Interaction logic for NewRaceTrack.xaml
    /// </summary>
    public partial class NewRaceTrack : Page
    {
        string name;
        int length;

        public NewRaceTrack()
        {
            InitializeComponent();
        }

        private void BtnAddRaceTrack_Click(object sender, RoutedEventArgs e)
        {
            bool checkIfInputIsCorrect = true;

            if (string.IsNullOrEmpty(txtRaceTrackName.Text))
            {
                MessageBox.Show("The new track needs a name");
                checkIfInputIsCorrect = false;
            }

            if (string.IsNullOrEmpty(txtRaceTrackLength.Text))
            {
                MessageBox.Show("We need to know how long the track is");
                checkIfInputIsCorrect = false;
            }
            else if (!Int32.TryParse(txtRaceTrackLength.Text, out length))
            {
                MessageBox.Show("The length needs to be a number");
                checkIfInputIsCorrect = false;
            }
            else if (length < 1)
            {
                MessageBox.Show("The length needs to be a positive number");
                checkIfInputIsCorrect = false;
            }

            if (checkIfInputIsCorrect)
            {
                name = txtRaceTrackName.Text;

                RaceTrack newRaceTrack = new RaceTrack(name, length);
                DatabaseManager.Instance.RaceTrackRepository.AddRaceTrack(newRaceTrack);

                NavigationService.Navigate(new ShowRaceTracks());
            }
        }
    }
}
