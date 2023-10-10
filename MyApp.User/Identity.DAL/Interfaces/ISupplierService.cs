using Identity.DAL.Entities;
using Identity.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.DAL.Interfaces
{
    public interface ISupplierService
    {
        Task<Result> SaveSupplier(RegisterModel registerModel);
    }
}
