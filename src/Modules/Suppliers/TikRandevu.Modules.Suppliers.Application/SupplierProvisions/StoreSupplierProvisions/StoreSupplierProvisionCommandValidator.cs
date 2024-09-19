using FluentValidation;

namespace TikRandevu.Modules.Suppliers.Application.SupplierProvisions.StoreSupplierProvisions;

public class StoreSupplierProvisionCommandValidator : AbstractValidator<StoreSupplierProvisionCommand>
{
    public StoreSupplierProvisionCommandValidator()
    {
        RuleFor(x => x.SupplierId).NotNull().NotEmpty();
        RuleFor(x => x.ProvisionId).NotNull().NotEmpty();
        RuleFor(x => x.Price).NotNull().NotEmpty()
            .Must(x => x >= 1);
    }
}