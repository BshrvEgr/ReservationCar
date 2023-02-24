using System.Collections.Generic;

namespace WpfApp1.Models.Car
{
    public class Car
    {
        public int CarId { get; set; }
        public CarPassport Passport { get; set; }
        public string CarDescription { get; set; }
        public string MainImageCar { get; set; }
        public float PricePerDay { get; set; }
        public bool Availability { get; set; }
        public List<string> Images { get; set; }
    }
}
