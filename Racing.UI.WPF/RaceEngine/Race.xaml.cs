using Racing.BL.Models;
using System.Collections.Generic;
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
        }
    }
}
