namespace WeatherService.Api.Exceptions {
    public class ParsingWeatherAPIException : Exception {
        public ParsingWeatherAPIException() {

        }

        public ParsingWeatherAPIException(string message) : base(message) {
        
        }
    }
}