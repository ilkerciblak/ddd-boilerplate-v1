using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Rezervations.Domain.Rezervations;

public static class RezervationError
{
    public static readonly Error
        AlreadyPaid = Error.Problem("Rezervations.AlreadyPaid", "Rezervation Fee Already Paid");
}