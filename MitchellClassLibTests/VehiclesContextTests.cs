using Microsoft.VisualStudio.TestTools.UnitTesting;
using MitchellClassLib;
using MitchellClassLib.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchellClassLib.Tests
{
    [TestClass()]
    public class VehiclesContextTests
    {
        [TestMethod()]
        public void AddVehicleTest()
        {
            // arrange
            Vehicle vehicle = new Vehicle()
            {
                Id = 1,
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
                Id = 1,
                Make = "Honda",
                Model = "HRV",
                Year = 2015
            };

            // act  
            VehiclesContext vc = new VehiclesContext();
            vc.addVehicle(vehicle);

            // assert
            Assert.IsTrue(vc.getVehicleById(vehicle.Id) == vehicle);
        }

        [TestMethod()]
        public void DeleteVehicleTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetVehiclesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateVehicleTest()
        {
            Assert.Fail();
        }
    }
}