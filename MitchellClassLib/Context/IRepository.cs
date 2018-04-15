using MitchellClassLib.Commons.DTOs;
using MitchellClassLib.Commons.Models;
using System.Collections.Generic;

namespace MitchellClassLib
{
    public interface IRepository
    {
        IVehicleDTO AddVehicle(Vehicle vehicle);

        IEnumerable<IVehicleDTO> GetVehicles();

        IVehicleDTO UpdateVehicle(Vehicle vehicle);

        bool DeleteVehicle(int id);

        IEnumerable<IVehicleDTO> GetVehicleByFilter(string filter, string value);

        IVehicleDTO GetVehicleId(int id);
    }
}