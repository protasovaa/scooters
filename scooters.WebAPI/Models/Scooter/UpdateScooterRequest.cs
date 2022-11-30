using FluentValidation;
using FluentValidation.Results;

namespace scooters.WebAPI.Models;

public class UpdateScooterRequest
{
#region Model
 public string? Address { get; set; }
public bool IsBooking { get; set; }
public int Price { get; set; }


#endregion

#region Validator
public class Validator: AbstractValidator<UpdateScooterRequest>
{
public Validator()
{
    RuleFor(x=>x.Address)
        .MaximumLength(255).WithMessage("Length must be less than 256");
    RuleFor(x=>x.Price)
        .NotNull().WithMessage("Length > 0");
    RuleFor(x=>x.IsBooking)
        .NotEqual(false).WithMessage(" The value must be true");
}

}
#endregion
}
public static class UpdateScooterRequestExtension
{
public static ValidationResult Validate(this UpdateScooterRequest model)
{
return new UpdateScooterRequest.Validator().Validate(model);
}
}