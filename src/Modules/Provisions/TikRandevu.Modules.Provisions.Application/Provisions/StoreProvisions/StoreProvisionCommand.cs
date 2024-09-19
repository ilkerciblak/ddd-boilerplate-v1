using TikRandevu.Modules.Provisions.Domain;
using TikRandevu.Shared.Application.RequestBase;

namespace TikRandevu.Modules.Provisions.Application.Provisions.StoreProvisions;

public sealed record StoreProvisionCommand(string Name) : ICommand<Guid>;