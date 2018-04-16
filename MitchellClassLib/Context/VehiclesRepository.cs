using MitchellClassLib.Commons.DTOs;
using MitchellClassLib.Commons.Helpers;
using MitchellClassLib.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MitchellClassLib
{
    public class VehiclesRepository : IRepository
    {
        #region Private fields

        private List<VehicleDTO> veh = new List<VehicleDTO>();
        private object Lock = new object();

        #endregion Private fields

        #region Public fields

        /// <summary>
        /// Hold all vehicles in memory. This is a static list. This mimic database table
        /// </summary>
        public static List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        #endregion Public fields

        #region Public methods

        /// <summary>
        /// Gets all vehicles
        /// </summary>
        /// <returns> List of vehicles</returns>
        public virtual IEnumerable<IVehicleDTO> GetVehicles()
        {
            List<VehicleDTO> veh = new List<VehicleDTO>();
            Vehicles.ForEach(x => veh.Add(x.MapDto()));
            return veh;
        }

        /// <summary>
        /// Addes vehicle to list of vehicles
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns> vehicle which is added to the list </returns>
        public IVehicleDTO AddVehicle(Vehicle vehicle)
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

        /// <summary>
        /// Deletes the vehicle with the id provided
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteVehicle(int id)
        {
            if (Vehicles.Any(x => x.Id == id))
            {
                Vehicles.RemoveAll(x => x.Id == id);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Updates the vehicle which is in the list
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public IVehicleDTO UpdateVehicle(Vehicle vehicle)
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

        /// <summary>
        /// Gets a vehicle which matches the id provided
        /// </summary>
        /// <param name="id"></param>
        /// <returns> vehicle</returns>
        public IVehicleDTO GetVehicleId(int id)
        {
            return Vehicles.FirstOrDefault(x => x.Id == id)?.MapDto();
        }

        /// <summary>
        /// Gets vehicle matching the filter
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="value"></param>
        /// <returns>list of vehicles</returns>
        public IEnumerable<IVehicleDTO> GetVehicleByFilter(string filter, string value)
        {
            if (filter == "" || value == "")
                return GetVehicles();
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
                    return GetVehicles();
            }
            return veh;
        }

        #endregion Public methods
    }
}