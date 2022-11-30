using FluentValidation;
using FluentValidation.Results;

namespace scooters.WebAPI.Models;

public class UpdateUserRequest
{
#region Model
  public string? Number { get; set; }
    public string? FirstName { get; set; }
    public string? Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Login { get; set; }
    public bool Is_bloked { get; set; } 


#endregion

#region Validator
public class Validator: AbstractValidator<UpdateUserRequest>
{
public Validator()
{
    RuleFor(x=>x.Number)
        .MaximumLength(255).WithMessage("Length must be less than 256");
    RuleFor(x=>x.FirstName)
        .MaximumLength(255).WithMessage("Length must be less than 256");
    RuleFor(x=>x.Email)
        .MaximumLength(255).WithMessage("Length must be less than 256");
    RuleFor(x=>x.Login)
        .MaximumLength(255).WithMessage("Length must be less than 256");
    RuleFor(x=>x.Is_bloked)
        .NotEqual(false).WithMessage(" The value must be true");
    RuleFor(x=>x.DateOfBirth)
        .InclusiveBetween(DateTime.MinValue,DateTime.Today).WithMessage("Length must be less than 256");
}

}
#endregion
}
public static class UpdateUserRequestExtension
{
public static ValidationResult Validate(this UpdateUserRequest model)
{
return new UpdateUserRequest.Validator().Validate(model);
}
}