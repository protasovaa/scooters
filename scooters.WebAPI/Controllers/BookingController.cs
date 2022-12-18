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
    public class BookingController : ControllerBase
    {
        private readonly IBookingService BookingService;
        private readonly IMapper mapper;

        /// <summary>
        /// Booking controller
        /// </summary>
        public BookingController(IBookingService  BookingService,IMapper mapper)
        {
            this.BookingService=BookingService;
            this.mapper=mapper;
        }
         /// <summary>
        /// create Booking
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateBooking([FromQuery] Guid UserId, [FromQuery] Guid ScooterId,[FromBody] BookingModel booking)
        {
            var response = BookingService.CreateBooking(UserId, ScooterId, booking);
            return Ok(response);
        }


        
        /// <summary>
        /// Get Booking by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetBookings([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =BookingService.GetBookings(limit,offset);

            return Ok(mapper.Map<PageResponse<BookingResponse>>(pageModel));
        }
        /// <summary>
        /// Delete Booking
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBooking([FromRoute] Guid id)
        {
            try
            {
                BookingService.DeleteBooking(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get Booking
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBooking([FromRoute] Guid id)
        {
            try
            {
                var BookingModel =BookingService.GetBooking(id);
                return Ok(mapper.Map<BookingResponse>(BookingModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update Booking
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateBooking([FromRoute] Guid id, [FromBody] UpdateBookingRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =BookingService.UpdateBooking(id,mapper.Map<UpdateBookingModel>(model));
            return Ok(mapper.Map<BookingResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }
          
    }

}