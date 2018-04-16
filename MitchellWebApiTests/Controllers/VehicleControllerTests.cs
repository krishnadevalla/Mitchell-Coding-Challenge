using Microsoft.VisualStudio.TestTools.UnitTesting;
using MitchellClassLib;
using MitchellClassLib.Commons.DTOs;
using MitchellClassLib.Commons.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace MitchellWebApi.Controllers.Tests
{
    [TestClass()]
    public class VehicleControllerTests
    {
        private VehicleController controller;

        [TestMethod()]
        public void ApiGetVehiclesTest_ReturnsAllVehiclesCheckCount()
        {
            // Arrange
            var repo = new VehiclesRepository();
            VehiclesRepository.Vehicles.Add(new Vehicle()
            {
                Id = 1,
                Make = "Honda",
                Model = "HRV",
                Year = 2015
            });
            VehiclesRepository.Vehicles.Add(new Vehicle()
            {
                Id = 2,
                Make = "Honda",
                Model = "HRV",
                Year = 2016
            });
            controller = new VehicleController(repo)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var response = controller.Get() as OkNegotiatedContentResult<IEnumerable<IVehicleDTO>>;

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(2, (response.Content as List<VehicleDTO>).Count);
        }

        [TestMethod()]
        public void ApiPostVehicleTest_ShouldReturnSameVehicleAndIdInURL()
        {
            // Arrange
            var repo = new VehiclesRepository();
            controller = new VehicleController(repo)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            Vehicle vehicle = new Vehicle()
            {
                Make = "Honda",
                Model = "HRV",
                Year = 2015
            };

            // Act
            IHttpActionResult actionResult = controller.Post(vehicle);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<IVehicleDTO>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("GetById", createdResult.RouteName);
            Assert.AreEqual(1, createdResult.RouteValues["Id"]);
            Assert.AreEqual((createdResult.Content as VehicleDTO).Make, vehicle.Make);
        }

        [TestMethod()]
        public void ApiGetVehicleByIdTest_ShouldReturnTheVehicle()
        {
            // Arrange
            var repo = new VehiclesRepository();
            controller = new VehicleController(repo)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            VehiclesRepository.Vehicles.Add(new Vehicle()
            {
                Id = 1,
                Make = "Honda",
                Model = "HRV",
                Year = 2015
            });

            // Act
            OkNegotiatedContentResult<IVehicleDTO> response = controller.Get(1) as OkNegotiatedContentResult<IVehicleDTO>;

            // Assert
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(2015, (response.Content as VehicleDTO).Year);
            Assert.AreEqual("HRV", (response.Content as VehicleDTO).Model);
        }

        [TestMethod]
        public void GetVehicleById_ReturnsNotFound()
        {
            // Arrange
            // Arrange
            var repo = new VehiclesRepository();
            controller = new VehicleController(repo)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var actionResult = controller.Get(10);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void ApiGetVehicleByFilterAndValue()
        {
            // Arrange
            var repo = new VehiclesRepository();
            VehiclesRepository.Vehicles.Add(new Vehicle()
            {
                Id = 1,
                Make = "Honda",
                Model = "Model",
                Year = 2015
            });
            VehiclesRepository.Vehicles.Add(new Vehicle()
            {
                Id = 2,
                Make = "Honda",
                Model = "Model",
                Year = 2016
            });
            controller = new VehicleController(repo)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var response = controller.Get("Model", "Model") as OkNegotiatedContentResult<IEnumerable<IVehicleDTO>>;

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(2, (response.Content as List<VehicleDTO>).Count);
        }

        [TestMethod()]
        public void ApiPutVehicleTest()
        {
            // Arrange
            var repo = new VehiclesRepository();
            controller = new VehicleController(repo)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            VehiclesRepository.Vehicles.Add(new Vehicle()
            {
                Make = "Honda",
                Model = "HRV",
                Year = 2015
            });
            Vehicle updatedVehicle = new Vehicle()
            {
                Id = 1,
                Make = "Honda",
                Model = "HRV",
                Year = 2016
            };

            // Act
            var actionResult = controller.Put(updatedVehicle);
            var contentResult = actionResult as OkNegotiatedContentResult<IVehicleDTO>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(updatedVehicle.Year, (contentResult.Content as VehicleDTO).Year);
        }

        [TestMethod()]
        public void ApiDeleteVehicleTest_ReturnsOkay()
        {
            // Arrange
            var repo = new VehiclesRepository();
            controller = new VehicleController(repo)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            VehiclesRepository.Vehicles.Add(new Vehicle()
            {
                Make = "Honda",
                Model = "HRV",
                Year = 2015
            });

            // Act
            IHttpActionResult actionResult = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public void PutVehicle_ShouldReturnNotFound()
        {
            // Arrange
            var repo = new VehiclesRepository();
            controller = new VehicleController(repo)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            Vehicle vehicle = new Vehicle()
            {
                Id = 1,
                Make = "onda",
                Model = "HRV",
                Year = 2015
            };

            // Act
            var result = controller.Put(vehicle);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}