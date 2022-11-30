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
    public class ScooterController : ControllerBase
    {
        private readonly IScooterService ScooterService;
        private readonly IMapper mapper;

        /// <summary>
        /// Scooter controller
        /// </summary>
        public ScooterController(IScooterService  ScooterService,IMapper mapper)
        {
            this.ScooterService=ScooterService;
            this.mapper=mapper;
        }
        /// <summary>
        /// create scooter
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateScooter([FromBody] CreateScooterRequest scooter)
        {
            var validationResult = scooter.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel =ScooterService.CreateScooter(mapper.Map<CreateScooterModel>(scooter));
                return Ok(resultModel);
            }
            catch (Exception e)
            {
                    return BadRequest(e);
            }
        }

        
        /// <summary>
        /// Get Scooter by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetScooters([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =ScooterService.GetScooters(limit,offset);

            return Ok(mapper.Map<PageResponse<ScooterResponse>>(pageModel));
        }
        /// <summary>
        /// Delete Scooter
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteScooter([FromRoute] Guid id)
        {
            try
            {
                ScooterService.DeleteScooter(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get Scooter
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetScooter([FromRoute] Guid id)
        {
            try
            {
                var ScooterModel =ScooterService.GetScooter(id);
                return Ok(mapper.Map<ScooterResponse>(ScooterModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update Scooter
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateScooter([FromRoute] Guid id, [FromBody] UpdateScooterRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =ScooterService.UpdateScooter(id,mapper.Map<UpdateScooterModel>(model));
            return Ok(mapper.Map<ScooterResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }
          
    }

}