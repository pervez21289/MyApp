
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
    public class SupplierService:BaseRepo,ISupplierService
    {
       

        public async Task<Result> SaveSupplier(RegisterModel registerModel)
        {
            try
            {
                var anonymousObject = new
                {
                    UserId = registerModel.UserId,
                    CityId = registerModel.CityId,
                    CountryId = registerModel.CountryId,
                    CompanyName = registerModel.CompanyName,
                    WebsiteName = registerModel.WebsiteName,
                    PermanantAddress = registerModel.PermanantAddress,
                    TelephoneNo = registerModel.ISD_MobileNo,
                    Title = registerModel.Title,
                    FirstName = registerModel.FirstName,
                    MobileNumber = registerModel.MobileNumber,
                    SkypeId = registerModel.SkypeId,
                    EmailId = registerModel.EmailId,
                    Designation = registerModel.Designation,
                    CurrencyId = registerModel.CurrencyId,
                    BookingEmailId = registerModel.BookingEmailId,
                    IsApproved = false
                };
                return await QueryFirstOrDefaultAsync<Result>("SP_SaveSupplier", anonymousObject);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
