using System.Collections.Generic;

namespace GenericApi.Service.Services
{
    public class OperatorServices
    {
        public IEnumerable<string> GetErrorList()
        {
            return new string[]
            {
                Operators.EQUAL,
                Operators.GRATER_THAN_OR_EQUAL,
                Operators.LESS_THAN_OR_EQUAL,
                Operators.NOT_EQUAL,
            };
        }
    }
}
