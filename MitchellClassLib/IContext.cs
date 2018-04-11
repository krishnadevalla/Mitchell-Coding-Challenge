using MitchellClassLib.Commons.Models;
using System.Collections.Generic;

namespace MitchellClassLib
{
    public interface IContext
    {
        bool addVehicle(Vehicle vehicle);

        Vehicle getVehicleById(int id);

        IEnumerable<Vehicle> getVehicles();

        Vehicle updateVehicle(Vehicle vehicle);

        bool deleteVehicle(int id);
    }
}
