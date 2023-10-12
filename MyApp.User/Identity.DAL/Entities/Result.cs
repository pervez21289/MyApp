using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.DAL.Entities
{
    public class Result
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public long Id { get; set; }
    }

    public class ErrorInfo
    {
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string MethodName { get; set; }
        public string Exception { get; set; }
    }
}
