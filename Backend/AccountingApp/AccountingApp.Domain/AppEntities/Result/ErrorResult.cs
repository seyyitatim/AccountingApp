using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Domain.AppEntities.Result
{
    public class ErrorResult : ErrorStatusCode
    {
        public string Message { get; set; }
    }

    public class ErrorStatusCode
    {
        public int StatusCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ValidationErrorDetails : ErrorStatusCode
    {
        public IEnumerable<string> Errors { get; set; }
    }

}
