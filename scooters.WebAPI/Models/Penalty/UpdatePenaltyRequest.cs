using FluentValidation;
using FluentValidation.Results;

namespace scooters.WebAPI.Models;

public class UpdatePenaltyRequest
{
#region Model
  public string? TypePenalty { get; set; }
public int AmountPenalty { get; set; }


#endregion

#region Validator
public class Validator: AbstractValidator<UpdatePenaltyRequest>
{
public Validator()
{
    RuleFor(x=>x.TypePenalty)
        .MaximumLength(255).WithMessage("Length must be less than 256");
    RuleFor(x=>x.AmountPenalty)
        .NotNull().WithMessage("Length > 0");
}

}
#endregion
}
public static class UpdatePenaltyRequestExtension
{
public static ValidationResult Validate(this UpdatePenaltyRequest model)
{
return new UpdatePenaltyRequest.Validator().Validate(model);
}
}