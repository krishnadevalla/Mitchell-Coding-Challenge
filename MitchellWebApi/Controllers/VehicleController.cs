using MitchellClassLib;
using MitchellClassLib.Commons.DTOs;
using MitchellClassLib.Commons.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace MitchellWebApi.Controllers
{
    /// <summary>
    /// WebApi that manages vehicles
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VehicleController : ApiController
    {
        private IRepository repository;

        /// <summary>
        /// Constructor with Dependency Injection
        /// </summary>
        public VehicleController(IRepository vehiclerepo)
        {
            repository = vehiclerepo;
        }

        /// <summary>
        /// Gets all the vehicles
        /// </summary>
        [Route("vehicles")]
        [ResponseType(typeof(List<VehicleDTO>))]
        public IHttpActionResult Get()
        {
            return Ok(repository.GetVehicles());
        }

        /// <summary>
        /// Gets a specific vehicle with the id
        /// </summary>
        /// <param name="id"></param>
        // GET vehicles/5
        [Route("vehicles/{id}", Name = "GetById")]
        [ResponseType(typeof(VehicleDTO))]
        public IHttpActionResult Get(int id)
        {
            IVehicleDTO vehicle = repository.GetVehicleId(id);
            if (vehicle != null)
                return Ok(vehicle);
            else
                return NotFound();
        }

        /// <summary>
        /// Gets vehicles based on filter
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="value"></param>
        [Route("vehicles/{filter}/{value}")]
        [ResponseType(typeof(List<VehicleDTO>))]
        public IHttpActionResult Get(string filter, string value)
        {
            return Ok(repository.GetVehicleByFilter(filter, value));
        }

        /// <summary>
        /// Inserts the vehicle into the database
        /// </summary>
        // POST vehicles
        [Route("vehicles")]
        [ResponseType(typeof(VehicleDTO))]
        public IHttpActionResult Post(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                IVehicleDTO veh = repository.AddVehicle(vehicle);
                if (veh != null)
                    return CreatedAtRoute("GetById", new { id = vehicle.Id }, veh);
                else
                    return BadRequest("Vehicle is null or duplicate");
            }
            else
                return BadRequest("Vehicle is not valid");
        }

        /// <summary>
        /// Updates the vehicle for an existing one
        /// </summary>
        // PUT vehicles
        [Route("vehicles")]
        [ResponseType(typeof(VehicleDTO))]
        public IHttpActionResult Put(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                IVehicleDTO veh = repository.UpdateVehicle(vehicle);
                if (veh != null)
                    return Ok(veh);
                else
                    return NotFound();
            }
            else
                return BadRequest("Vehicle is not valid");
        }

        /// <summary>
        /// Delete the vehicle with that id
        /// </summary>
        /// <param name="id"></param>
        // DELETE vehicles/5
        [Route("vehicles/{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (repository.DeleteVehicle(id))
                return Ok();
            else
                return NotFound();
        }
    }
}