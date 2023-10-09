using MyApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DAL.Interfaces
{
    public interface ISupplierServiceEmail
    {
        Task<Result> SaveSupplierServiceEmail(SupplierServiceEmailModel supplierServiceEmailModel);
    }
}
