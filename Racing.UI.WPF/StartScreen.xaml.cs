using Racing.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Racing.UI.WPF
{
    /// <summary>
    /// Interaction logic for StartScreen.xaml
    /// </summary>
    public partial class StartScreen : Page
    {
        List<Driver> allDrivers = new List<Driver>();

        public StartScreen()
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
