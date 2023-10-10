using Identity.DAL.Entities;
using Identity.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.DAL.Interfaces
{
    public interface ISupplierServiceEmail
    {
        Task<Result> SaveSupplierServiceEmail(SupplierServiceEmailModel supplierServiceEmailModel);
        Task<Result> SaveSupplierServiceMapping(SupplierServiceMappingModel supplierServiceMappingModel);
        
    }
}
