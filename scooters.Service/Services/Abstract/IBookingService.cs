using scooters.Services.Models;
namespace scooters.Services.Abstract;

public interface IBookingService
{
BookingModel GetBooking(Guid id);

BookingModel UpdateBooking(Guid id, UpdateBookingModel BookingModel);

void DeleteBooking(Guid id);

PageModel<BookingPreviewModel> GetBookings(int limit = 20, int offset = 0);
BookingModel CreateBooking(Guid UserId, Guid ScooterId, BookingModel bookingModel);

}
