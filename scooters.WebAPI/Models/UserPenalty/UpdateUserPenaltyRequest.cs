using FluentValidation;
using FluentValidation.Results;

namespace scooters.WebAPI.Models;

public class UpdateUserPenaltyRequest
{
#region Model
  public bool IsPaidFor { get; set; }


#endregion

#region Validator
public class Validator: AbstractValidator<UpdateUserPenaltyRequest>
{
public Validator()
{
   
    RuleFor(x=>x.IsPaidFor)
        .NotEqual(false).WithMessage(" The value must be true");
   
}

}
#endregion
}
public static class UpdateUserPenaltyRequestExtension
{
public static ValidationResult Validate(this UpdateUserPenaltyRequest model)
{
return new UpdateUserPenaltyRequest.Validator().Validate(model);
}
}