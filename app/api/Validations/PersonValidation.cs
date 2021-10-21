using app.Models;
using app.Requests;
using FluentValidation;

namespace app.Validations
{
    public class PersonValidation: AbstractValidator<PersonRequest>
    {
        public PersonValidation()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName cannot be null");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName cannot be null");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address cannot be null");
            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Gender cannot be null");
        }
    }
}