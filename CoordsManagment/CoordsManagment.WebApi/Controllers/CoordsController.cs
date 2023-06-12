using System;
using System.Collections.Generic;
using System.Web.Http;
using CoordsManagment.Domain.CustomExceptions;
using CoordsManagment.Domain.DomainEntities;
using CoordsManagment.Domain.ServicesContracts;

namespace CoordsManagment.WebApi.Controllers
{
    /// <summary>
    /// Actions to manage coordinates
    /// </summary>
    public class CoordsController : ApiController
    {
        private readonly ICoordinateService _service;

        public CoordsController(ICoordinateService service)
        {
            _service = service;
        }

        /// <summary>
        /// Action to register coordinates
        /// </summary>
        /// <param name="coords"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Register(List<decimal> coords)
        {
            if (coords.Count != 3)
            {
                return BadRequest("Only 3 coordinate list allowed");
            }

            try
            {
                _service.Register(GenerateEntities(coords));
                return Ok("The coordenates have been loaded properly.");
            }
            catch(CannotSaveDataException ex)
            {
                return BadRequest($"Error in loading data: {ex.Message}");
            }
            catch(Exception ex) 
            {
                return BadRequest($"Unknown error: {ex.Message}");
            }
        }

        private Coordinates GenerateEntities(List<decimal> coords)
        {
            return new Coordinates
            {
                CoordinateX = coords[0],
                CoordinateY = coords[1],
                CoordinateZ = coords[2]
            };
        }
    }
}
