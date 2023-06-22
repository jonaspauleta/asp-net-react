namespace WeatherService.Api.Models {
    public class CityStatus {
        public CityStatus(string City, string Region, string Country, string LocalTime, float Temperature, string Sunrise, string Sunset) {
            this.City = City;
            this.Region = Region;
            this.Country = Country;
            this.LocalTime = LocalTime;
            this.Temperature = Temperature;
            this.Sunrise = Sunrise;
            this.Sunset = Sunset;
        }

        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string LocalTime { get; set; }
        public float Temperature { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
    }
}
