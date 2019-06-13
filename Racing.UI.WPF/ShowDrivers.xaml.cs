using Racing.BL.Models;
using System;
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

        private void BtnDeleteDriver_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Driver driver = (Driver)dgAllDrivers.SelectedItem;

                DatabaseManager.Instance.DriverRepository.DeleteDriver(driver);

                NavigationService.Navigate(new ShowDrivers());
            }
            catch (Exception)
            {
                MessageBox.Show("Select a driver");
            }
        }

        private void BtnAddDriver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewDriver());
        }
    }
}
