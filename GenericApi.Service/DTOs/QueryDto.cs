using System.Collections.Generic;

namespace GenericAPI.DTOs
{
    public class QueryDto
    {
        public string Entity { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public string OrderBy { get; set; }
        public string OrderByDescending { get; set; }
        public IEnumerable<QueryCriteriaDto> Criterias { get; set; }

        public QueryDto()
        {
            Criterias = new List<QueryCriteriaDto>();
        }
    }
}
