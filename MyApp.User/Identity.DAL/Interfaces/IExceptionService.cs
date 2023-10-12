using Identity.DAL.Entities;
using Identity.DAL.Models;

namespace Identity.DAL.Interfaces
{
    public interface IExceptionService
    {
        Task<Result> SaveExceptionDetails(ErrorInfo obj);
    }
}
