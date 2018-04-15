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
            VehiclesRepository vr = new VehiclesRepository();
            vr.AddVehicle(vehicle1);
            vr.AddVehicle(vehicle2);

            // assert
            Assert.IsTrue(vr.GetVehicles().Count() == 2);
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
            VehiclesRepository vr = new VehiclesRepository();
            vr.AddVehicle(vehicle);

            // assert
            Assert.IsTrue(VehiclesRepository.Vehicles.Contains(vehicle));
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
            VehiclesRepository vr = new VehiclesRepository();
            vr.AddVehicle(vehicle);

            // assert
            Assert.ReferenceEquals(vr.GetVehicleId(vehicle.Id.Value), vehicle.MapDto());
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
            VehiclesRepository vr = new VehiclesRepository();
            vr.AddVehicle(vehicle);

            // assert
            Assert.IsTrue(vr.DeleteVehicle(vehicle.Id.Value));
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
            VehiclesRepository vr = new VehiclesRepository();
            vr.AddVehicle(vehicle);
            vr.UpdateVehicle(updatedVehicle);
            updatedVehicle.Id = vehicle.Id;

            // assert
            Assert.ReferenceEquals(vehicle, updatedVehicle);
        }
    }
}