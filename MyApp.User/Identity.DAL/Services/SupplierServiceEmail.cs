
using Identity.DAL.Entities;
using Identity.DAL.Interfaces;
using Identity.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.DAL.Services
{
    public class SupplierServiceEmail:BaseRepo,ISupplierServiceEmail
    {
        public async Task<Result> SaveSupplierServiceEmail(SupplierServiceEmailModel supplierServiceEmailModel)
        {
            return await QueryFirstOrDefaultAsync<Result>("SP_SaveSupplierServiceEmail", supplierServiceEmailModel);

        }

        public async Task<Result> SaveSupplierServiceMapping(SupplierServiceMappingModel supplierServiceMappingModel)
        {
            return await QueryFirstOrDefaultAsync<Result>("SP_SaveSupplierServiceMapping", supplierServiceMappingModel);

        }

        public async Task<Result> SP_ApproveSupplier(string UserId,bool IsApproved)
        {
            return await QueryFirstOrDefaultAsync<Result>("SP_ApproveSupplier", new {UserId=UserId,IsApproved=IsApproved});
        }
    }
}
