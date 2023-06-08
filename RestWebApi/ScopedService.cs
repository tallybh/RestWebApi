using Microsoft.Extensions.Options;
using RestWebApi.Options;

namespace RestWebApi;


public class ScopedService : ITransientService
{
    private readonly UnitOptions _unitOptions;

    public ScopedService(IOptionsSnapshot<UnitOptions> unitOptions)
    {
        _unitOptions = unitOptions.Value;
    }

    public UnitOptions GetUnits()
    {
        return _unitOptions;
    }
}
