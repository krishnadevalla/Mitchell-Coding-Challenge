using MitchellClassLib.Commons.DTOs;
using MitchellClassLib.Commons.Helpers;
using MitchellClassLib.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MitchellClassLib
{
    public class VehiclesContext : IContext
    {
        #region Private fields

        private List<VehicleDTO> veh = new List<VehicleDTO>();
        private object Lock = new object();

        #endregion Private fields

        #region Public fields

        public static List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        #endregion Public fields

        #region Public methods

        public virtual IEnumerable<IVehicleDTO> getVehicles()
        {
            List<VehicleDTO> veh = new List<VehicleDTO>();
            Vehicles.ForEach(x => veh.Add(x.MapDto()));
            return veh;
        }

        public IVehicleDTO addVehicle(Vehicle vehicle)
        {
            if (vehicle != null && !Vehicles.Any(x => x.Id == vehicle.Id))
            {
                lock (Lock)
                {
                    vehicle.Id = VehicleIdHelper.Instance.NextId++;
                }
                vehicle.CreatedAt = DateTime.Now;
                Vehicles.Add(vehicle);
                return vehicle.MapDto();
            }
            else
            {
                return null;
            }
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

        public IVehicleDTO updateVehicle(Vehicle vehicle)
        {
            Vehicle v = Vehicles.FirstOrDefault(x => x.Id == vehicle.Id);
            if (v != null)
            {
                v.Make = vehicle.Make;
                v.Model = vehicle.Model;
                v.Year = vehicle.Year;
                v.UpdatedAt = DateTime.Now;
                return v.MapDto();
            }
            return null;
        }

        public IVehicleDTO getVehicleId(int id)
        {
            return Vehicles.FirstOrDefault(x => x.Id == id)?.MapDto();
        }

        public IEnumerable<IVehicleDTO> getVehicleByFilter(string filter, string value)
        {
            if (filter == "" || value == "")
                return getVehicles();
            veh.Clear();
            switch (filter.ToLower())
            {
                case "year":
                    Vehicles.Where(x => x.Year.ToString().ToLower().Contains(value.ToLower())).ToList().ForEach(x => veh.Add(x.MapDto()));
                    break;

                case "make":
                    Vehicles.Where(x => x.Make.ToLower().Contains(value.ToLower())).ToList().ForEach(x => veh.Add(x.MapDto()));
                    break;

                case "model":
                    Vehicles.Where(x => x.Model.ToLower().Contains(value.ToLower())).ToList().ForEach(x => veh.Add(x.MapDto()));
                    break;

                case "id":
                    Vehicles.Where(x => x.Id.ToString().ToLower().Contains(value.ToLower())).ToList().ForEach(x => veh.Add(x.MapDto()));
                    break;

                default:
                    return getVehicles();
            }
            return veh;
        }

        #endregion Public methods
    }
}