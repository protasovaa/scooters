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
    public class PenaltyController : ControllerBase
    {
        private readonly IPenaltyService PenaltyService;
        private readonly IMapper mapper;

        /// <summary>
        /// Penalty controller
        /// </summary>
        public PenaltyController(IPenaltyService  PenaltyService,IMapper mapper)
        {
            this.PenaltyService=PenaltyService;
            this.mapper=mapper;
        }
        // <summary>
        /// create penalty
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreatePenalty([FromBody] PenaltyModel penalty)   
        {
            var response =PenaltyService.CreatePenalty(penalty);
            return Ok(response);
        }

        
        /// <summary>
        /// Get Penalty by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetPenaltys([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =PenaltyService.GetPenaltys(limit,offset);

            return Ok(mapper.Map<PageResponse<PenaltyResponse>>(pageModel));
        }
        /// <summary>
        /// Delete Penalty
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletePenalty([FromRoute] Guid id)
        {
            try
            {
                PenaltyService.DeletePenalty(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get Penalty
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPenalty([FromRoute] Guid id)
        {
            try
            {
                var PenaltyModel =PenaltyService.GetPenalty(id);
                return Ok(mapper.Map<PenaltyResponse>(PenaltyModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update Penalty
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdatePenalty([FromRoute] Guid id, [FromBody] UpdatePenaltyRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =PenaltyService.UpdatePenalty(id,mapper.Map<UpdatePenaltyModel>(model));
            return Ok(mapper.Map<PenaltyResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }
          
    }

}