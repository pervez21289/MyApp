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
        public long? Id { get; set; }
    }
}
