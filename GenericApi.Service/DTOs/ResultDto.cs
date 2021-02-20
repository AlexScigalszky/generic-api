using GenericApi.Model.Models.Base;

namespace GenericAPI.DTOs
{
    public class ResultDto<T> 
    {
        public T Data { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
