using AutoMapper;
using scooters.Entities.Models;
using scooters.Repository;
using scooters.Services.Abstract;
using scooters.Services.Models;

namespace scooters.Services.Implementation;

public class BookingService :IBookingService
{
private readonly IRepository<Booking> BookingRepository;
private readonly IMapper mapper;
public BookingService(IRepository<Booking> BookingRepository, IMapper mapper)
{
this.BookingRepository=BookingRepository;
this.mapper = mapper;
}

public void DeleteBooking(Guid id)
{
var BookingToDelete =BookingRepository.GetById(id);
if (BookingToDelete == null)
{
throw new Exception("Booking not found");
}
BookingRepository.Delete(BookingToDelete);
}

public BookingModel GetBooking(Guid id)
{
var Booking =BookingRepository.GetById(id);
return mapper.Map<BookingModel>(Booking);
}

public PageModel<BookingPreviewModel> GetBookings(int limit = 20, int offset = 0)
{
var Booking =BookingRepository.GetAll();
int totalCount =Booking.Count();
var chunk=Booking.OrderBy(x=>x.TimeOfBooking).Skip(offset).Take(limit);

return new PageModel<BookingPreviewModel>()
{
Items = mapper.Map<IEnumerable<BookingPreviewModel>>(Booking),
TotalCount = totalCount
};
}

public BookingModel UpdateBooking(Guid id, UpdateBookingModel Booking)
{
var existingBooking = BookingRepository.GetById(id);
if (existingBooking == null)
{
throw new Exception("Booking not found");
}
existingBooking.TimeOfBooking=Booking.TimeOfBooking;
existingBooking.TimeOfStart=Booking.TimeOfStart;
existingBooking.TimeOfFinish=Booking.TimeOfFinish;
existingBooking = BookingRepository.Save(existingBooking);
return mapper.Map<BookingModel>(existingBooking);
}
public BookingModel CreateBooking(Guid UserId, Guid ScooterId, BookingModel bookingModel)
    {
      if(BookingRepository.GetAll(x=>x.Id==bookingModel.Id).FirstOrDefault()!=null)
      {
        throw new Exception ("Attempt to create a non-unique object!");
      }
      
        BookingModel createBooking = new BookingModel();
        createBooking.UserId=bookingModel.UserId;
        createBooking.ScooterId=bookingModel.ScooterId;
        createBooking.TimeOfBooking=bookingModel.TimeOfBooking;
        createBooking.TimeOfFinish=bookingModel.TimeOfFinish;
        createBooking.TimeOfStart=bookingModel.TimeOfStart;
        BookingRepository.Save(mapper.Map<Booking>(createBooking));
        return createBooking;

    }
}