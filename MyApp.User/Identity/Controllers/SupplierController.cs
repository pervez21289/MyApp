using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Identity.Models;
using Identity.DAL.Interfaces;
using Identity.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Identity.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _context;
        private readonly ISupplierServiceMapping _contextMapping;
        private readonly UserManager<IdentityUser> _userManager;

        public SupplierController(ISupplierService context, ISupplierServiceMapping contextMapping, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _contextMapping = contextMapping;
            _userManager = userManager;
        }   

        [HttpPost]
        [Route("SaveSupplierServiceEmail")]
        public async Task<Result> SaveSupplierServiceEmail(SupplierServiceEmailModel supplierServiceEmailModel)
        {
            try
            {
                return await _contextMapping.SaveSupplierServiceEmail(supplierServiceEmailModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("SaveSupplierService")]
        public async Task<Result> SaveSupplierServiceMapping(SupplierServiceMappingModel supplierServiceMappingModel)
        {
            try
            {
                return await _contextMapping.SaveSupplierServiceMapping(supplierServiceMappingModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("ApproveSupplier")]
        public async Task<Result> ApproveSupplier(string UserId, bool IsApproved)
        {
            try
            {
                if (IsApproved)
                {
                    return await _context.ApproveSupplier(UserId, IsApproved);
                }
                else
                {
                    var user = await _userManager.FindByIdAsync(UserId);
                    if (user != null)
                    {
                        var result = await _userManager.DeleteAsync(user);
                        if (result.Succeeded)
                        {
                            return await _context.ApproveSupplier(UserId, IsApproved);
                        }
                        else
                        {
                            return new Result() {Message="Issue in deleting the user!" };
                        }
                    }
                    else
                    {
                        return new Result() { Message = "User not found!" };
                    }
                }

                
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
