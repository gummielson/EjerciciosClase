using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using ColorsManagment.Domain.CustomExceptions;
using ColorsManagment.Domain.Entities;
using ColorsManagment.Domain.ServicesContracts;

namespace ColorsManagment.WebAPI.Controllers
{
    public class ColorController : ApiController
    {
        private readonly IColorServices _colorServices;

        public ColorController(IColorServices services)
        {
            _colorServices = services;
        }

        /// <summary>
        /// Action to register colours. Can only enter 3 strings in the list. 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult RegisterColor(List<string> values)
        {
            (bool, string) validation = ValidateEntries(values);

            if (validation.Item1)
            {
                return BadRequest(validation.Item2);
            };

            try
            {
                _colorServices.Register(GenerateEntities(values));
                return Ok("The color has been loaded properly.");
            }
            catch (ValidationException ex) 
            {
                return BadRequest($"Error creating entites: {ex.Message}");
            }
            catch (CannotInsertDataException ex)
            {
                return BadRequest($"Error inserting data: {ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Unknown error: {ex.Message}");
            }
        }

        private (bool, string) ValidateEntries(List<string> values)
        {
            if(values == null)
            {
                return (true, "Invalid input");
            }
            else if(values.Count != 3)
            {
                return (true, "Only can be three elements on the list");
            }else if (!int.TryParse(values[1], out _))
            {
                return (true, "The second element must be numeric");
            }
            else
            {
                return (false, string.Empty);
            }
        }

        private ColorEntity GenerateEntities(List<string> values)
        {
            return new ColorEntity
            {
                Color = values[0],
                NumericValue = int.Parse(values[1]),
                DefaultValue = values[2]
            };
        }
    }
}