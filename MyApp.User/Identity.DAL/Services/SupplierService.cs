
using Identity.DAL.Entities;
using Identity.DAL.Interfaces;
using Identity.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Identity.DAL.Services
{
    public class SupplierService:BaseRepo,ISupplierService
    {
       public async Task<Result> SaveSupplier(RegisterModel registerModel)
        {
            try
            {
                var objSupplier = new
                {
                    UserId = registerModel.UserId,
                    SupplierCode = registerModel.SupplierCode,
                    SupplierName = registerModel.SupplierName,
                    CityId = registerModel.CityId,
                    CountryId = registerModel.CountryId,
                    CompanyName = registerModel.CompanyName,
                    Website = registerModel.Website,
                    Address = registerModel.Address,
                    TelephoneNo = registerModel.TelephoneNo,
                    MobileNumber = registerModel.MobileNumber,
                    SkypeId = registerModel.SkypeId,
                    LoginEmailId = registerModel.Email,
                    Designation = registerModel.Designation,
                    CurrencyId = registerModel.CurrencyId,
                    BookingEmailId = registerModel.BookingEmailId,
                    IsApproved = false,
                    CreatedBy= registerModel.UserId,
                    UpdatedBy= registerModel.UserId
                };
                return await QueryFirstOrDefaultAsync<Result>("SP_SaveSupplier", objSupplier);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Result> ApproveSupplier(string UserId, bool IsApproved)
        {
            return await QueryFirstOrDefaultAsync<Result>("SP_ApproveSupplier", new { UserId = UserId, IsApproved = IsApproved });
        }
    }
}
