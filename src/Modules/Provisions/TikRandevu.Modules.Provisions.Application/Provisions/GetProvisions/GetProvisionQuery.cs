using TikRandevu.Modules.Provisions.Domain;
using TikRandevu.Shared.Application.RequestBase;

namespace TikRandevu.Modules.Provisions.Application.Provisions.GetProvisions;

public sealed record  GetProvisionQuery(Guid Identifier) : IQuery<Provision>;