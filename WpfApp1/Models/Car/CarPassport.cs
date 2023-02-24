using System;

namespace WpfApp1.Models.Car
{
    public class CarPassport
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string CarBrand { get; set; }
        public string CarCategory { get; set; }
        public int Power { get; set; }
        public string CountryOfOrigin { get; set; }
        public DateTime YearRelease { get; set; }
    }
}
