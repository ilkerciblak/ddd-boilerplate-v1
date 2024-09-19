namespace TikRandevu.Modules.Rezervations.Application.Abstractions.Payment;

public interface IPaymentService
{
    Task<bool> CompletePayment(CancellationToken cancellationToken = default);
}