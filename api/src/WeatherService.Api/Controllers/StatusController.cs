using Microsoft.AspNetCore.Mvc;
using WeatherService.Api.Models;
using Newtonsoft.Json.Linq;
using WeatherService.Api.Exceptions;

namespace WeatherService.Api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase {
        private readonly IConfiguration _config;

        public StatusController(IConfiguration config) {
            _config = config;
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{name}")]
        public IActionResult GetStatus(string name) {
            var weatherAPIEndpoint = _config.GetValue<string>("WeatherAPIEndpoint");
            var apiKey = _config.GetValue<string>("WeatherAPIKey");

            try {
                var currentResponse = readWeatherApi(weatherAPIEndpoint + "current.json?key=" + apiKey + "&q=" + name + "&aqi=no");
                JObject current = JObject.Parse(currentResponse);

                string astronomyResponse = readWeatherApi(weatherAPIEndpoint + "astronomy.json?key=" + apiKey + "&q=" + name + "&dt=" + DateTime.Now.ToString("yyyy-MM-dd"));
                JObject astronomy = JObject.Parse(astronomyResponse);
                
                CityStatus cityStatus = new CityStatus(
                    (string)current["location"]["name"],
                    (string)current["location"]["region"],
                    (string)current["location"]["country"],
                    ((DateTime)current["location"]["localtime"]).ToString("yyyy-MM-dd HH:mm"),
                    (float)current["current"]["temp_c"],
                    (string)astronomy["astronomy"]["astro"]["sunrise"],
                    (string)astronomy["astronomy"]["astro"]["sunset"]
                );

                return Ok(cityStatus);
            } catch(ParsingWeatherAPIException e) {
                return NotFound(new ErrorResponse(e.Message));
            } catch {
                return NotFound(new ErrorResponse("An error ocurred while processing your request."));
            }
        }

        private string readWeatherApi(string url) {
            using (var client = new HttpClient()) {
                var response = client.GetAsync(url).GetAwaiter().GetResult();

                var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                var json = JObject.Parse(responseString);

                if (!json.ContainsKey("location")) {
                    if (json.ContainsKey("error") && (int)json["error"]["code"] == 1006) {
                        throw new ParsingWeatherAPIException("The specified city does not exist in our database.");
                    }

                    throw new ParsingWeatherAPIException("An error ocurred while calling the weather api.");
                }

                return responseString;
            }
        }
    }
}