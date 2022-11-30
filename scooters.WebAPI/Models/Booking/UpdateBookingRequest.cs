using FluentValidation;
using FluentValidation.Results;

namespace scooters.WebAPI.Models;

public class UpdateBookingRequest
{
#region Model

public DateTime TimeOfBooking { get; set; }
public DateTime TimeOfStart { get; set; }
public DateTime TimeOfFinish { get; set; }

#endregion

#region Validator
public class Validator: AbstractValidator<UpdateBookingRequest>
{
public Validator()
{
    RuleFor(x=>x.TimeOfBooking)
        .InclusiveBetween(DateTime.MinValue,DateTime.Today).WithMessage("Length must be less than 256");
    RuleFor(x=>x.TimeOfStart)
        .InclusiveBetween(DateTime.MinValue,DateTime.Today).WithMessage("Length must be less than 256");
    RuleFor(x=>x.TimeOfFinish)
        .InclusiveBetween(DateTime.MinValue,DateTime.Today).WithMessage("Length must be less than 256");

}

}
#endregion
}
public static class UpdateBookingRequestExtension
{
public static ValidationResult Validate(this UpdateBookingRequest model)
{
return new UpdateBookingRequest.Validator().Validate(model);
}
}