using TikRandevu.Shared.Application.RequestBase;

namespace TikRandevu.Modules.Rezervations.Application.Rezervations.CompletePayment;

public sealed record CompletePaymentCommand(Guid RezervationId) : ICommand<Guid>;