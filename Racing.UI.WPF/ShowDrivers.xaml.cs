using Racing.BL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Racing.UI.WPF
{
    /// <summary>
    /// Interaction logic for StartScreen.xaml
    /// </summary>
    public partial class ShowDrivers : Page
    {
        List<Driver> allDrivers = new List<Driver>();

        public ShowDrivers()
        {
            InitializeComponent();
        }

        private void Onloaded(object sender, RoutedEventArgs e)
        {
            allDrivers = DatabaseManager.Instance.DriverRepository.GetAllDrivers().ToList();

            dgAllDrivers.ItemsSource = allDrivers;
        }
    }
}
