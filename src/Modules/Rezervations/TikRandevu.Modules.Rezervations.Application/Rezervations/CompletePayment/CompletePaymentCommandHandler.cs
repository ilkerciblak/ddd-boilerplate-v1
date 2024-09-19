using TikRandevu.Modules.Rezervations.Application.Abstractions.Data;
using TikRandevu.Modules.Rezervations.Domain.Rezervations;
using TikRandevu.Shared.Application.RequestBase;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Rezervations.Application.Rezervations.CompletePayment;

public sealed class CompletePaymentCommandHandler(IRezervationRepository rezervationRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CompletePaymentCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CompletePaymentCommand request, CancellationToken cancellationToken)
    {
        var rezervation = await rezervationRepository.GetAsync(request.RezervationId, cancellationToken);

        if (rezervation is null)
        {
            return Result<Guid>.Failure<Guid>(new NotFound<Rezervation>(request.RezervationId));
        }

        var result = rezervation.PayForRezervation();

        if (result.IsFailure)
        {
            return Result<Guid>.Failure<Guid>(result.Error);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return rezervation.Identifier;
    }
}