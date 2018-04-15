namespace MitchellClassLib.Commons.Helpers
{
    public sealed class VehicleIdHelper
    {
        private static VehicleIdHelper instance;
        public int NextId { get; set; } = 1;

        private VehicleIdHelper()
        { }

        public static VehicleIdHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VehicleIdHelper();
                }
                return instance;
            }
        }
    }
}