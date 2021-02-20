using System.Collections.Generic;

namespace GenericAPI.DTOs
{
    public class ListDto<T>
    {
        public int CountTotal { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public ICollection<T> List { get; set; }

        public ListDto()
        {
            List = new List<T>();
        }

        public ListDto(int countTotal, int pageNumber, int pageSize, string orderBy, ICollection<T> List)
        {
            CountTotal = countTotal;
            PageNumber = pageNumber;
            PageSize = pageSize;
            OrderBy = orderBy;
            this.List = List;
        }
    }
}
