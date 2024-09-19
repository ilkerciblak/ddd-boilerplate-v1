using FluentValidation;

namespace TikRandevu.Modules.Suppliers.Application.SupplierRezervations.StoreSupplierRezervations;

public class StoreSupplierRezervartionsCommandValidator : AbstractValidator<StoreSupplierRezervationsCommand>
{
    public StoreSupplierRezervartionsCommandValidator()
    {
        RuleFor(x => x.RezervationDate)
            .Must(x => !x.Equals(DateTime.UtcNow));
    }
}