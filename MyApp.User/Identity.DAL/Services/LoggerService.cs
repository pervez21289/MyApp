using Identity.DAL.Entities;
using Identity.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.DAL.Services
{
    public class LogService  :BaseRepo, ILog
    {
        public async Task Log(string UserId, string LogType,string LogResponse)
        {
            try
            {
                await QueryAsync<Result>("SP_SaveLogger", new { @LogType = LogType, @LogResponse = LogResponse, @UserId = UserId });
            }
            catch
            {

            }
        }
    }
}
