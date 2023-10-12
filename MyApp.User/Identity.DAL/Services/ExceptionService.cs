
using Identity.DAL.Entities;
using Identity.DAL.Interfaces;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace Identity.DAL.Services
{
    public class ExceptionService:BaseRepo,IExceptionService
    {
        public async Task<Result> SaveExceptionDetails(ErrorInfo obj)
        {
            return await QueryFirstOrDefaultAsync<Result>("LogException_Employee", obj);
        }
    }
}
