﻿namespace MitchellClassLib.Commons.DTOs
{
    /// <summary>
    /// Model for Vehicle data transfer object
    /// </summary>
    public class VehicleDTO : IVehicleDTO
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
    }
}