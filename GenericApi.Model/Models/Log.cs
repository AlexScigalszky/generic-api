using GenericApi.Model.Models.Base;
using System;

namespace GenericApi.Model.Models
{
    public class Log : BaseModel
    {
        public string Module { get; set; }
        public string ShortMessage { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public long UserID { get; set; }
    }
}
