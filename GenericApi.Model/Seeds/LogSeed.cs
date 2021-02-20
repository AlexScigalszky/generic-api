using GenericApi.Model.Models;
using System;

namespace GenericApi.Model.Seeds
{
    public class LogSeed
    {
        public static Log[] GetData()
        {
            return new Log[]
            {
                new Log()
                {
                    Id = 1,
                    Date = DateTime.UtcNow,
                    Detail = "a detail for example",
                    Module = "Users",
                    ShortMessage = "example",
                    UserID = 1
                }
            };
        }
    }
}
