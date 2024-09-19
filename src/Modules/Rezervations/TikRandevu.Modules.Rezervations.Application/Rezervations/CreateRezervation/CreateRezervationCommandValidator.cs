using FluentValidation;

namespace TikRandevu.Modules.Rezervations.Application.Rezervations.CreateRezervation;

public class CreateRezervationCommandValidator : AbstractValidator<CreateRezervationCommand>
{
    public CreateRezervationCommandValidator()
    {
        RuleFor(x => x.SupplierId).NotNull().NotEmpty();
        RuleFor(x => x.CustomerId).NotNull().NotEmpty();
        RuleFor(x => x.SupplierProvisionId).NotNull().NotEmpty();
        RuleFor(x => x.RezervationDate).NotEmpty()
            .Must(x => DateTime.Compare(x, DateTime.UtcNow) > 0
            );
    }
}