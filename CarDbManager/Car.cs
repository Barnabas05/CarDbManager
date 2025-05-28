using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDbManager
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Make};{Model};{Year};{Price}";
        }

        public static Car FromString(string line)
        {
            var parts = line.Split(';');
            return new Car
            {
                Make = parts[0],
                Model = parts[1],
                Year = int.Parse(parts[2]),
                Price = decimal.Parse(parts[3])
            };
        }
    }
}
