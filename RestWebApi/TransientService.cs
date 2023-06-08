using Microsoft.Extensions.Options;
using RestWebApi.Options;

namespace RestWebApi
{
    public interface ITransientService
    {
        UnitOptions GetUnits();
    }

    public class TransientService : ITransientService
    {
        private readonly UnitOptions _unitOptions;

        public TransientService(IOptions<UnitOptions> unitOptions)
        {
            _unitOptions = unitOptions.Value;
        }
        public UnitOptions GetUnits()
        {
            return _unitOptions;
        }
    }

}
