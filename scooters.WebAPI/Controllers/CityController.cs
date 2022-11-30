using AutoMapper;
using scooters.Services.Abstract;
using scooters.Services.Models;
using scooters.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace scooters.WebAPI.Controllers
{
    /// <summary>
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService CityService;
        private readonly IMapper mapper;

        /// <summary>
        /// City controller
        /// </summary>
        public CityController(ICityService  CityService,IMapper mapper)
        {
            this.CityService=CityService;
            this.mapper=mapper;
        }
        // <summary>
        /// create city
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateCity([FromBody] CityModel city)   
        {
            var response =CityService.CreateCity(city);
            return Ok(response);
        }

        
        /// <summary>
        /// Get City by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetCitys([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =CityService.GetCitys(limit,offset);

            return Ok(mapper.Map<PageResponse<CityResponse>>(pageModel));
        }
        /// <summary>
        /// Delete City
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCity([FromRoute] Guid id)
        {
            try
            {
                CityService.DeleteCity(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get City
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCity([FromRoute] Guid id)
        {
            try
            {
                var CityModel =CityService.GetCity(id);
                return Ok(mapper.Map<CityResponse>(CityModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update City
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateCity([FromRoute] Guid id, [FromBody] UpdateCityRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =CityService.UpdateCity(id,mapper.Map<UpdateCityModel>(model));
            return Ok(mapper.Map<CityResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }
          
    }

}