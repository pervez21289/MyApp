using Identity.DAL.Entities;
using Identity.DAL.Models;

namespace Identity.DAL.Interfaces
{
    public interface ISupplierService
    {
        Task<Result> ApproveSupplier(string UserId, bool IsApproved);
        Task<Result> SaveSupplier(RegisterModel registerModel);
    }
}
