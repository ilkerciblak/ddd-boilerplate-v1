using System.Reflection;

namespace TikRandevu.Modules.Provisions.Application;

public abstract class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}