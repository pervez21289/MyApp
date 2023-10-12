using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.DAL.Interfaces
{
    public interface ILog
    {
        Task Log(string UserId, string LogType, string LogResponse);


    }
}
