using Identity.DAL.Entities;

namespace Identity.DAL.Interfaces
{
    public interface ISupplierServiceMapping
    {
        Task<Result> SaveSupplierServiceEmail(SupplierServiceEmailModel supplierServiceEmailModel);
        Task<Result> SaveSupplierServiceMapping(SupplierServiceMappingModel supplierServiceMappingModel);
    }
}
