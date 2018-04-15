using Microsoft.VisualStudio.TestTools.UnitTesting;
using MitchellClassLib.Commons.Models;
using System.Linq;

namespace MitchellClassLib.Tests
{
    [TestClass()]
    public class VehiclesContextTests
    {
        [TestMethod()]
        public void GetVehiclesTest()
        {
            // arrange
            Vehicle vehicle1 = new Vehicle()
            {
                Make = "Honda",
                Model = "HRV",
                Year = 2015
            };
            Vehicle vehicle2 = new Vehicle()
            {
                Make = "Honda",
                Model = "HRV",
                Year = 2015
            };

            // act
            VehiclesContext vc = new VehiclesContext();
            vc.addVehicle(vehicle1);
            vc.addVehicle(vehicle2);

            // assert
            Assert.IsTrue(vc.getVehicles().Count() == 2);
        }

        [TestMethod()]
        public void AddVehicleTest()
        {
            // arrange
            Vehicle vehicle = new Vehicle()
            {
                Make = "Honda",
                Model = "HRV",
                Year = 2015
            };

            // act
            VehiclesContext vc = new VehiclesContext();
            vc.addVehicle(vehicle);

            // assert
            Assert.IsTrue(VehiclesContext.Vehicles.Contains(vehicle));
        }

        [TestMethod()]
        public void GetVehicleByIdTest()
        {
            // arrange
            Vehicle vehicle = new Vehicle()
            {
                Make = "Honda",
                Model = "HRV",
                Year = 2015
            };

            // act
            VehiclesContext vc = new VehiclesContext();
            vc.addVehicle(vehicle);

            // assert
            Assert.ReferenceEquals(vc.getVehicleId(vehicle.Id.Value), vehicle.MapDto());
        }

        [TestMethod()]
        public void DeleteVehicleTest()
        {
            // arrange
            Vehicle vehicle = new Vehicle()
            {
                Make = "Honda",
                Model = "HRV",
                Year = 2015
            };

            // act
            VehiclesContext vc = new VehiclesContext();
            vc.addVehicle(vehicle);

            // assert
            Assert.IsTrue(vc.deleteVehicle(vehicle.Id.Value));
        }

        [TestMethod()]
        public void UpdateVehicleTest()
        {
            // arrange
            Vehicle vehicle = new Vehicle()
            {
                Make = "Honda",
                Model = "HRV",
                Year = 2015
            };
            Vehicle updatedVehicle = new Vehicle()
            {
                Make = "Honda",
                Model = "HRV",
                Year = 2016
            };

            // act
            VehiclesContext vc = new VehiclesContext();
            vc.addVehicle(vehicle);
            vc.updateVehicle(updatedVehicle);
            updatedVehicle.Id = vehicle.Id;

            // assert
            Assert.ReferenceEquals(vehicle, updatedVehicle);
        }
    }
}