using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarDbManager
{
    public static class CarDb
    {
        private static string FilePath = "cars.txt";

        public static List<Car> LoadCars()
        {
            var cars = new List<Car>();

            if (!File.Exists(FilePath))
                return cars;

            var lines = File.ReadAllLines(FilePath);
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                    cars.Add(Car.FromString(line));
            }

            return cars;
        }

        public static void SaveCars(List<Car> cars)
        {
            try
            {
                var lines = new List<string>();
                foreach (var car in cars)
                    lines.Add(car.ToString());

                File.WriteAllLines(FilePath, lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving file:" + ex.Message);
            }
        }

    }
}
