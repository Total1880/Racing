using Racing.BL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Racing.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Driver> allDrivers = new List<Driver>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            allDrivers = DatabaseManager.Instance.DriverRepository.GetAllDrivers().ToList();

            dgAllDrivers.ItemsSource = allDrivers;
        }
    }
}
