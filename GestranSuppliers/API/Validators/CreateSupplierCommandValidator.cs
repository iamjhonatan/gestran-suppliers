using FluentValidation;
using GestranSuppliers.Application.Commands;

namespace GestranSuppliers.API.Validators;

public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
{
    public CreateSupplierCommandValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty().Length(3, 120);
        RuleFor(x => x.Cnpj).NotNull().NotEmpty()
            .Matches(@"^((\d{2}).(\d{3}).(\d{3})/(\d{4})-(\d{2}))*$");
        RuleFor(x => x.PhoneNumber).Matches(@"^(?:(?:\+|00)?(55)\s?)?(?:(?:\(?[1-9][0-9]\)?)?\s?)?(?:((?:9\d|[2-9])\d{3})-?(\d{4}))$");
        RuleFor(x => x.Email).Matches(@"^([-a-zA-Z0-9_-]*@(gmail|yahoo|ymail|rocketmail|bol|hotmail|live|msn|ig|globomail|oi|pop|inteligweb|r7|folha|zipmail).(com|info|gov|net|org|tv)(.[-a-z]{2})?)*$");
    }
}