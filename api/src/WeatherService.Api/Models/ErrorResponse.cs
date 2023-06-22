namespace WeatherService.Api.Models {
    public class ErrorResponse {
        public ErrorResponse(string Message) {
            this.Error = new Error(Message);
        }
        public Error Error { get; set; }
    }

    public class Error {
        public Error (string Message) {
            this.Message = Message;
        }
        public string Message { get; set; }
    }
}