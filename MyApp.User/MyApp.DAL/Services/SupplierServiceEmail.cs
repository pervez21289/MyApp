using MyApp.DAL.Entities;
using MyApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DAL.Services
{
    public class SupplierServiceEmail:BaseRepo,ISupplierServiceEmail
    {
        public async Task<Result> SaveSupplierServiceEmail(SupplierServiceEmailModel supplierServiceEmailModel)
        {
            return await QueryFirstOrDefaultAsync<Result>("SP_SaveSupplierServiceEmail", supplierServiceEmailModel);

        }
    }
}
