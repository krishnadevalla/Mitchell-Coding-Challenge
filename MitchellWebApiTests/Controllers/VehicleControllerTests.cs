using Microsoft.VisualStudio.TestTools.UnitTesting;
using MitchellClassLib;
using MitchellClassLib.Commons.DTOs;
using MitchellClassLib.Commons.Models;
using Moq;
using System.Collections.Generic;
using System.Net;
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
        public void ApiGetVehiclesTest_ReturnsAllVehicles()
        {
            // Arrange
            var contextMock = new VehiclesContext();
            VehiclesContext.Vehicles.Add(new Vehicle()
            {
                Id = 1,
                Make = "Honda",
                Model = "HRV",
                Year = 2015
            });
            VehiclesContext.Vehicles.Add(new Vehicle()
            {
                Id = 2,
                Make = "Honda",
                Model = "HRV",
                Year = 2016
            });

            controller = new VehicleController(contextMock)
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
            IMock<IContext> mockContext = new Mock<VehiclesContext>();
            var controller = new VehicleController(mockContext.Object);
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
        public void ApiGetVehicleByIdTest()
        {
            // Arrange
            IMock<IContext> mockContext = new Mock<VehiclesContext>();
            var controller = new VehicleController(mockContext.Object);
            Vehicle vehicle = new Vehicle()
            {
                Make = "Honda",
                Model = "HRV",
                Year = 2015
            };
            // Act
            controller.Post(vehicle);
            OkNegotiatedContentResult<IVehicleDTO> response = controller.Get(1) as OkNegotiatedContentResult<IVehicleDTO>;


            // Assert
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(2015, (response.Content as VehicleDTO).Year);

        }

        [TestMethod()]
        public void ApiGetVehicleByFilterAndValue()
        {
            // Arrange
            var contextMock = new VehiclesContext();
            VehiclesContext.Vehicles.Add(new Vehicle()
            {
                Id = 1,
                Make = "Honda",
                Model = "Model",
                Year = 2015
            });
            VehiclesContext.Vehicles.Add(new Vehicle()
            {
                Id = 2,
                Make = "Honda",
                Model = "Model",
                Year = 2016
            });

            controller = new VehicleController(contextMock)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var response = controller.Get("Model","Model") as OkNegotiatedContentResult<IEnumerable<IVehicleDTO>>;


            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(2, (response.Content as List<VehicleDTO>).Count);
        }

        [TestMethod()]
        public void ApiPutVehicleTest()
        {
            // Arrange
            IMock<IContext> mockContext = new Mock<VehiclesContext>();
            var controller = new VehicleController(mockContext.Object);
            Vehicle vehicle = new Vehicle()
            {
                Make = "Honda",
                Model = "HRV",
                Year = 2015
            };
            Vehicle updatedVehicle = new Vehicle()
            {
                Id = 1,
                Make = "Honda",
                Model = "HRV",
                Year = 2016
            };

            // Act
            IHttpActionResult actionResult = controller.Post(vehicle);
            actionResult = controller.Put(updatedVehicle);
            var contentResult = actionResult as OkNegotiatedContentResult<IVehicleDTO>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(2016, (contentResult.Content as VehicleDTO).Year);
        }

        [TestMethod()]
        public void ApiDeleteVehicleTest()
        {
            // Arrange
            IMock<IContext> mockContext = new Mock<VehiclesContext>();
            var controller = new VehicleController(mockContext.Object);
            Vehicle vehicle = new Vehicle()
            {
                Make = "Honda",
                Model = "HRV",
                Year = 2015
            };

            // Act
            IHttpActionResult actionResult = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }


        [TestMethod]
        public void PutVehicle_ShouldReturnNotFound()
        {
            // Arrange
            IMock<IContext> mockContext = new Mock<VehiclesContext>();
            controller = new VehicleController(mockContext.Object)
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
            var result = controller.Put(vehicle);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}