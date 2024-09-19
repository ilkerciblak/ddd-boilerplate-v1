using FluentValidation;

namespace TikRandevu.Modules.Provisions.Application.Provisions.StoreProvisions;

public sealed class StoreProvisionCommandValidator : AbstractValidator<StoreProvisionCommand>
{
    public StoreProvisionCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .NotNull()
            .Must(x => x.Length > 2);
    }
}