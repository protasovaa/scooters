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
    public class UserPenaltyController : ControllerBase
    {
        private readonly IUserPenaltyService UserPenaltyService;
        private readonly IMapper mapper;

        /// <summary>
        /// UserPenalty controller
        /// </summary>
        public UserPenaltyController(IUserPenaltyService  UserPenaltyService,IMapper mapper)
        {
            this.UserPenaltyService=UserPenaltyService;
            this.mapper=mapper;
        }
        /// <summary>
        /// create userPenalty
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateBooking([FromBody] CreateUserPenaltyRequest userPenalty)
        {
            var validationResult = userPenalty.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel =UserPenaltyService.CreateUserPenalty(mapper.Map<CreateUserPenaltyModel>(userPenalty));
                return Ok(resultModel);
            }
            catch (Exception e)
            {
                    return BadRequest(e);
            }
        }

        
        /// <summary>
        /// Get UserPenalty by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetUserPenaltys([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =UserPenaltyService.GetUserPenaltys(limit,offset);

            return Ok(mapper.Map<PageResponse<UserPenaltyResponse>>(pageModel));
        }
        /// <summary>
        /// Delete UserPenalty
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUserPenalty([FromRoute] Guid id)
        {
            try
            {
                UserPenaltyService.DeleteUserPenalty(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get UserPenalty
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUserPenalty([FromRoute] Guid id)
        {
            try
            {
                var UserPenaltyModel =UserPenaltyService.GetUserPenalty(id);
                return Ok(mapper.Map<UserPenaltyResponse>(UserPenaltyModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update UserPenalty
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateUserPenalty([FromRoute] Guid id, [FromBody] UpdateUserPenaltyRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =UserPenaltyService.UpdateUserPenalty(id,mapper.Map<UpdateUserPenaltyModel>(model));
            return Ok(mapper.Map<UserPenaltyResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }
          
    }

}