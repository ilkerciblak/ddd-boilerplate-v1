using TikRandevu.Modules.Provisions.Domain;
using TikRandevu.Shared.Application.RequestBase;

namespace TikRandevu.Modules.Provisions.Application.Provisions.GetAllProvisions;

public sealed record GetAllProvisionQuery(int? PageNumber = 1, int? PageSize = 100) : IQuery<IReadOnlyCollection<Provision>>;
