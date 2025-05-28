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
    /// Interaction logic for EditCarWindow.xaml
    /// </summary>
    public partial class EditCarWindow : Window
    {
        public Car EditedCar { get; private set; }

        public EditCarWindow(Car car)
        {
            InitializeComponent();

            MakeTextBox.Text = car.Make;
            ModelTextBox.Text = car.Model;
            YearTextBox.Text = car.Year.ToString();
            PriceTextBox.Text = car.Price.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                EditedCar = new Car
                {
                    Make = MakeTextBox.Text,
                    Model = ModelTextBox.Text,
                    Year = int.Parse(YearTextBox.Text),
                    Price = decimal.Parse(PriceTextBox.Text)
                };

                this.Close();
            }
            catch
            {
                MessageBox.Show("Incorrect data entry. Please check the fields.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
