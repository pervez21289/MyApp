
using Identity.DAL.Entities;
using Identity.DAL.Interfaces;

namespace Identity.DAL.Services
{
    public class SupplierMappingService : BaseRepo, ISupplierServiceMapping
    {
        public async Task<Result> SaveSupplierServiceEmail(SupplierServiceEmailModel supplierServiceEmailModel)
        {
            return await QueryFirstOrDefaultAsync<Result>("SP_SaveSupplierServiceEmail", supplierServiceEmailModel);
        }

        public async Task<Result> SaveSupplierServiceMapping(SupplierServiceMappingModel supplierServiceMappingModel)
        {
            return await QueryFirstOrDefaultAsync<Result>("SP_SaveSupplierServiceMapping", supplierServiceMappingModel);
        }

       
    }
}
