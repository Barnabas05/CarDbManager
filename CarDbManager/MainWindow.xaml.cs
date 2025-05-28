using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CarDbManager;

namespace CarDbManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {

        private List<Car> cars = new List<Car>();
        public MainWindow()
        {
            InitializeComponent();
            LoadCars();
        }
        private void LoadCars()
        {
            cars = CarDb.LoadCars();
            CarsDataGrid.ItemsSource = null;
            CarsDataGrid.ItemsSource = cars;
        }
        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddCarWindow();
            addWindow.ShowDialog();

            if (addWindow.NewCar != null)
            {
                cars.Add(addWindow.NewCar);
                CarDb.SaveCars(cars);
                CarsDataGrid.Items.Refresh();
            }
        }
        private void EditCarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarsDataGrid.SelectedItem is Car selectedCar)
            {
                var window = new EditCarWindow(selectedCar);
                window.ShowDialog();

                if (window.EditedCar != null)
                {
                   
                    selectedCar.Make = window.EditedCar.Make;
                    selectedCar.Model = window.EditedCar.Model;
                    selectedCar.Year = window.EditedCar.Year;
                    selectedCar.Price = window.EditedCar.Price;

                    CarDb.SaveCars(cars);
                    CarsDataGrid.Items.Refresh();
                }
            }
        }
        private void DeleteCarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarsDataGrid.SelectedItem is Car selectedCar)
            {
                if (MessageBox.Show("Are you sure?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    cars.Remove(selectedCar);
                    CarDb.SaveCars(cars);
                    LoadCars();
                }
            }
            else
            {
                MessageBox.Show("Please select a car to delete.");
            }
        }
        private void GenerateCars_Click(object sender, RoutedEventArgs e)
        {
            var makes = new[]
            {
                "Toyota", "Ford", "BMW", "Honda", "Audi", "Mercedes", "Volkswagen",
                "Skoda", "Renault", "Peugeot", "Hyundai", "Kia", "Mazda", "Nissan", "Opel",
                "Chevrolet", "Fiat", "Dacia", "Seat", "Volvo", "Jaguar", "Lexus", "Subaru"
            };
            var models = new[]
            {
                "A", "B", "C", "X", "Y", "Z", "Sport", "City", "Family", "Eco",
                "Touring", "Deluxe", "GT", "Hybrid", "Classic", "Pro", "Max", "Comfort",
                "Rapid", "Plus", "Vibe", "Active", "Drive"
            };
            var rnd = new Random();
            cars = new List<Car>();

            for (int i = 0; i < 100; i++)
            {
                var car = new Car
                {
                    Make = makes[rnd.Next(makes.Length)],
                    Model = models[rnd.Next(models.Length)] + rnd.Next(100, 999),
                    Year = rnd.Next(2000, 2025),
                    Price = rnd.Next(1000000, 50000000)
                };

                cars.Add(car);
            }

            CarDb.SaveCars(cars);
            CarsDataGrid.ItemsSource = null;
            CarsDataGrid.ItemsSource = cars;

            MessageBox.Show("100 cars successfully generated and saved.");
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            string makeFilter = MakeFilterBox.Text.Trim().ToLower();
            string modelFilter = ModelFilterBox.Text.Trim().ToLower();

            int.TryParse(YearFromBox.Text.Trim(), out int yearFrom);
            int.TryParse(YearToBox.Text.Trim(), out int yearTo);

            var filtered = cars.Where(car =>
                (string.IsNullOrEmpty(makeFilter) || car.Make.ToLower().Contains(makeFilter)) &&
                (string.IsNullOrEmpty(modelFilter) || car.Model.ToLower().Contains(modelFilter)) &&
                (yearFrom == 0 || car.Year >= yearFrom) &&
                (yearTo == 0 || car.Year <= yearTo)
            ).ToList();

            CarsDataGrid.ItemsSource = null;
            CarsDataGrid.ItemsSource = filtered;
        }
        private void ClearFilterButton_Click(object sender, RoutedEventArgs e)
        {
            MakeFilterBox.Text = "";
            ModelFilterBox.Text = "";
            YearFromBox.Text = "";
            YearToBox.Text = "";

            CarsDataGrid.ItemsSource = null;
            CarsDataGrid.ItemsSource = cars;
        }

    }
}