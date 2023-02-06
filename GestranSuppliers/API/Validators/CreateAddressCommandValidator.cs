using FluentValidation;
using GestranSuppliers.Application.Commands;

namespace GestranSuppliers.API.Validators;

public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressCommandValidator()
    {
        RuleFor(x => x.ZipCode).NotNull().NotEmpty().Matches(@"^[0-9]{5}-[0-9]{3}$");
        RuleFor(x => x.PublicPlace).NotNull().NotEmpty().Length(0, 120);
        RuleFor(x => x.Number);
        RuleFor(x => x.Complement);
        RuleFor(x => x.City).NotNull().NotEmpty().Length(0, 120);
        RuleFor(x => x.State).NotNull().NotEmpty().Length(0, 120);
        RuleFor(x => x.Country).NotNull().NotEmpty().Length(0, 120);
    }
}