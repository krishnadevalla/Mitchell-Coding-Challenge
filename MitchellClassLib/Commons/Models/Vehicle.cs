﻿using MitchellClassLib.Commons.DTOs;
using System;
using System.ComponentModel.DataAnnotations;

namespace MitchellClassLib.Commons.Models
{
    /// <summary>
    /// Model for vehicle
    /// </summary>
    public class Vehicle : IVehicle
    {
        /// <summary>
        /// Id is a identifier of a vehicles
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Year when vehicle was manufactured
        /// </summary>
        [Required]
        [Range(1950, 2050)]
        public int Year { get; set; }

        /// <summary>
        /// Make of a vehicle
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Make { get; set; }

        /// <summary>
        /// Model of a vehicle
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        /// <summary>
        /// Created timestamp of a record for the vehicle
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Updated timestamp of a record for the vehicle
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Converts or maps vehicle model to vehicle dto
        /// </summary>
        /// <returns>
        /// Returns vehicle dto
        /// </returns>
        public VehicleDTO MapDto()
        {
            return new VehicleDTO()
            {
                Id = Id.Value,
                Make = Make,
                Model = Model,
                Year = Year
            };
        }
    }
}