using Racing.BL.Models;
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
        public SeasonPage()
        {
            InitializeComponent();

            List<RaceTrack> seasonTracks = new List<RaceTrack>();
            int seasonRaceNumber = 0;

            seasonTracks = DatabaseManager.Instance.RaceTrackRepository.GetAllRaceTracks().ToList();
        }
    }
}
