using Racing.BL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Racing.UI.WPF.RaceEngine
{
    /// <summary>
    /// Interaction logic for StartingConditions.xaml
    /// </summary>
    public partial class StartingConditions : Page
    {
        List<RaceTrack> listOfRaceTracks = new List<RaceTrack>();
        List<Driver> listOfDrivers = new List<Driver>();

        public StartingConditions()
        {
            InitializeComponent();

            listOfDrivers = DatabaseManager.Instance.DriverRepository.GetAllDrivers().ToList();
            listOfRaceTracks = DatabaseManager.Instance.RaceTrackRepository.GetAllRaceTracks().ToList();

            foreach (RaceTrack raceTrack in listOfRaceTracks)
            {
                ComboBoxItem item = new ComboBoxItem();

                item.Tag = raceTrack;
                item.Content = raceTrack.Name;
                cmbRace.Items.Add(item);
            }
        }

        private void BtnStartRace_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (cmbRace.SelectedIndex > -1)
            {
                int selectedIndex = cmbRace.SelectedIndex;
                RaceTrack raceTrack = listOfRaceTracks[selectedIndex];
                NavigationService.Navigate(new Race(listOfDrivers, raceTrack));
            }
        }
    }
}
