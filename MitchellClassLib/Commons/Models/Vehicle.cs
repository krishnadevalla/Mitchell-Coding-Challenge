using System;

namespace MitchellClassLib.Commons.Models
{
    public class Vehicle
    {
        /// <summary>
        /// Id is a identifier of a vehicles
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Year when vehicle was manufactured 
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Make of a vehicle
        /// </summary>
        public string Make { get; set; }

        /// <summary>
        /// Model of a vehicle
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Created timestamp of a record for the vehicle
        /// </summary>
        public DateTime? CreatedAt { get ; set; }

        /// <summary>
        /// Updated timestamp of a record for the vehicle
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}