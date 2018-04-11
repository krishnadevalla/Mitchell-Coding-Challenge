using MitchellClassLib.Commons.DTOs;
using MitchellClassLib.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MitchellClassLib
{
    public class VehiclesContext : IContext
    {
        public static List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();


        public bool addVehicle(Vehicle vehicle)
        {
            if (vehicle != null && !Vehicles.Any(x => x.Id == vehicle.Id))
            {
                vehicle.CreatedAt = DateTime.Now;
                Vehicles.Add(vehicle);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Vehicle getVehicleById(int id)
        {
            return Vehicles.FirstOrDefault(x => x.Id == id);
        }

        public bool deleteVehicle(int id)
        {
            if (Vehicles.Any(x => x.Id == id))
            {
                Vehicles.RemoveAll(x => x.Id == id);
                return true;
            }
            return false;
        }

        public IEnumerable<Vehicle> getVehicles()
        {
            return Vehicles;
        }

        public Vehicle updateVehicle(Vehicle vehicle)
        {
            Vehicle v = Vehicles.FirstOrDefault(x => x.Id == vehicle.Id);
            if (v != null)
            {
                v.Make = vehicle.Make;
                v.Model = vehicle.Model;
                v.Year = vehicle.Year;
                v.UpdatedAt = DateTime.Now;
                return v;
            }
            return null;
        }
    }
}
