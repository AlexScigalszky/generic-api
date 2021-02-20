using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GenericApi.Service.Services
{
    public class PropertiesService
    {
        public IEnumerable<string> GetPropertiesOf(string entity)
        {
            try
            {
                var clazz = Type.GetType(Constants.NAMESPACE_FOR_ENTITIES + entity + Constants.BINARY_FOR_ENTITIES);

                PropertyInfo[] propertyInfos;
                propertyInfos = Activator
                    .CreateInstance(clazz)
                    .GetType()
                    .GetProperties();

                Array.Sort(propertyInfos, delegate (PropertyInfo propertyInfo1, PropertyInfo propertyInfo2)
                 {
                     return propertyInfo1.Name.CompareTo(propertyInfo2.Name);
                 });

                return propertyInfos
                    .Select(p => p.Name)
                    .ToArray();
            }
            catch
            {
                return new List<string>();
            }

        }
    }
}
