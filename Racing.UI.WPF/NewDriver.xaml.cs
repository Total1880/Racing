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
    /// Interaction logic for NewDriver.xaml
    /// </summary>
    public partial class NewDriver : Page
    {
        string firstName;
        string lastName;
        int speed;

        public NewDriver()
        {
            InitializeComponent();
        }

        private void BtnSaveDriver_Click(object sender, RoutedEventArgs e)
        {
            bool checkIfAllInputIsCorrect = true;

            if(string.IsNullOrEmpty(txtFirstName.Text))
            {
                MessageBox.Show("First name can't be empty");
                checkIfAllInputIsCorrect = false;
            }

            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Last name can't be empty");
                checkIfAllInputIsCorrect = false;
            }

            if (!Int32.TryParse(txtSpeed.Text, out speed))
            {
                MessageBox.Show("Speed needs to be a number");
                checkIfAllInputIsCorrect = false;
            }
            else if (speed < 1 || speed > 20)
            {
                MessageBox.Show("Speed needs to be between 1 and 20");
                checkIfAllInputIsCorrect = false;
            }

            if (checkIfAllInputIsCorrect)
            {
                firstName = txtFirstName.Text;
                lastName = txtLastName.Text;

                Driver newDriver = new Driver(firstName, lastName, speed);
                DatabaseManager.Instance.DriverRepository.AddDriver(newDriver);

                NavigationService.Navigate(new StartScreen());
            }
        }
    }
}
