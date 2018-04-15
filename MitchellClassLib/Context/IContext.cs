using MitchellClassLib.Commons.DTOs;
using MitchellClassLib.Commons.Models;
using System.Collections.Generic;

namespace MitchellClassLib
{
    public interface IContext
    {
        IVehicleDTO addVehicle(Vehicle vehicle);

        IEnumerable<IVehicleDTO> getVehicles();

        IVehicleDTO updateVehicle(Vehicle vehicle);

        bool deleteVehicle(int id);

        IEnumerable<IVehicleDTO> getVehicleByFilter(string filter, string value);

        IVehicleDTO getVehicleId(int id);
    }
}