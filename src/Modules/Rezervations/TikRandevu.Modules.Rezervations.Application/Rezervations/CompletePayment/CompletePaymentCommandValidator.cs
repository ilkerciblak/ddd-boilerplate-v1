using FluentValidation;

namespace TikRandevu.Modules.Rezervations.Application.Rezervations.CompletePayment;

public sealed class CompletePaymentCommandValidator : AbstractValidator<CompletePaymentCommand>
{
    public CompletePaymentCommandValidator()
    {
        RuleFor(x => x.RezervationId).NotEmpty().NotNull();
    }
}