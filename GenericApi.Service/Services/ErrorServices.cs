using System.Collections.Generic;

namespace GenericApi.Service.Services
{
    public class ErrorServices
    {
        public IEnumerable<string> GetErrorList()
        {
            return new string[]
            {
                ErrorMessages.INTERNAL_ERROR
            };
        }
    }
}
