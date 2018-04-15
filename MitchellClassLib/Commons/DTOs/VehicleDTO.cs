namespace MitchellClassLib.Commons.DTOs
{
    public class VehicleDTO : IVehicleDTO
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}