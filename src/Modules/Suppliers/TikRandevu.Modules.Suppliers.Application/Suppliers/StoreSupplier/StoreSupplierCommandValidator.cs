using FluentValidation;

namespace TikRandevu.Modules.Suppliers.Application.Suppliers.StoreSupplier;

public class StoreSupplierCommandValidator : AbstractValidator<StoreSupplierCommand>
{
    public StoreSupplierCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.FullAddress)
            .NotEmpty()
            .NotNull()
            .Must(x => x.Length < 225);
    }
}