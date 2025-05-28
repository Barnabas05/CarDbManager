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
using System.Windows.Shapes;

namespace CarDbManager
{
    /// <summary>
    /// Interaction logic for AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        public Car NewCar;
        public AddCarWindow()
        {
            InitializeComponent();


        }
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string make = CarMakeBox.Text.Trim();
            string model = CarModelBox.Text.Trim();
            string yearText = CarYearBox.Text.Trim();
            string priceText = CarPriceBox.Text.Trim();


            if (string.IsNullOrEmpty(make))
            {
                MessageBox.Show("Manufacturer is required.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                CarMakeBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(model))
            {
                MessageBox.Show("Model is required.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                CarModelBox.Focus();
                return;
            }
            if (!int.TryParse(yearText, out int year) || year < 1900 || year > DateTime.Now.Year)
            {
                MessageBox.Show("The year is invalid or missing. Please enter a number between 1900 and the current year.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                CarYearBox.Focus();
                return;
            }
            if (!decimal.TryParse(priceText, out decimal price) || price < 0)
            {
                MessageBox.Show("The price is invalid or missing. Please enter a non-negative number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                CarPriceBox.Focus();
                return;
            }

            NewCar = new Car
            {
                Make = make,
                Model = model,
                Year = year,
                Price = price
            };

            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NewCar = null;
            Close(); 
        }
    }
}
