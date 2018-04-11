using MitchellClassLib;
using MitchellClassLib.Commons.Models;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace MitchellWebApi.Controllers
{
    /// <summary>
    /// WebApi that manages vehicles
    /// </summary>
    [EnableCors(origins: "http://localhost", headers: "*", methods: "get,post")]
    public class VehicleController : ApiController
    {
        private IContext context;

        /// <summary>
        /// Constructor with Dependency Injection
        /// </summary>
        public VehicleController(IContext vehiclecontext)
        {
            context = vehiclecontext;
        }

        /// <summary>
        /// Gets all the vehicles
        /// </summary>
        [Route("vehicles")]
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult Get()
        {
            return Ok(context.getVehicles());
        }

        /// <summary>
        /// Gets a specific vehicle with the id
        /// </summary>
        /// <param name="id"></param>
        // GET vehicles/5
        [Route("vehicles/{id}")]
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult Get(int id)
        {
            Vehicle vehicle = context.getVehicleById(id);
            if (vehicle != null)
                return Ok(vehicle);
            else
                return BadRequest("No vehical found");

        }


        /// <summary>
        /// Posts the vehicle
        /// </summary>
        // POST vehicles
        [Route("vehicles")]
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult Post([FromBody]Vehicle vehicle)
        {
            if (context.addVehicle(vehicle))
                return Ok(vehicle);
            else
                return BadRequest("Vehicle is null or duplicate");

        }


        /// <summary>
        /// Updates the vehicle
        /// </summary>
        // PUT vehicles/5
        [Route("vehicles")]
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult Put([FromBody]Vehicle vehicle)
        {
            if (context.updateVehicle(vehicle) != null)
                return Ok(vehicle);
            else
                return BadRequest("No vehical found");
        }



        /// <summary>
        /// Delete the vehicle with that id
        /// </summary>
        /// <param name="id"></param>
        // DELETE vehicles/5
        [Route("vehicles/{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (context.deleteVehicle(id))
                return Ok();
             else
                return BadRequest("No vehical found");
        }
    }
}
