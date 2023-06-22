using Microsoft.AspNetCore.Mvc;
using WeatherService.Api.Controllers;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using Xunit;

namespace WeatherService.Api.UnitTests {
    public class StatusControllerTests {
        [Fact]
        public void Get_Status_ReturnsOk() {
            string path = TryGetSolutionDirectoryInfo(Directory.GetCurrentDirectory()).ToString() + "/src/WeatherService.Api/";
            var configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json")
                .Build();

            var controller = new StatusController(configuration);

            var result = controller.GetStatus("Dublin");

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_Status_Returns_NotFound_If_City_Not_Exists() {
            string path = TryGetSolutionDirectoryInfo(Directory.GetCurrentDirectory()).ToString() + "/src/WeatherService.Api/";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json")
                .Build();

            var controller = new StatusController(configuration);

            var result = controller.GetStatus("Dublinnn1");

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void Get_Status_Returns_NotFound_For_Empty_String() {
            string path = TryGetSolutionDirectoryInfo(Directory.GetCurrentDirectory()).ToString() + "/src/WeatherService.Api/";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json")
                .Build();

            var controller = new StatusController(configuration);

            var result = controller.GetStatus("");

            Assert.IsType<NotFoundObjectResult>(result);
        }

        private static DirectoryInfo TryGetSolutionDirectoryInfo(string currentPath) {
            var directory = new DirectoryInfo(currentPath ?? Directory.GetCurrentDirectory());
            
            while (directory != null && !directory.GetFiles("*.sln").Any()) {
                directory = directory.Parent;
            }

            return directory;
        }
    }
}