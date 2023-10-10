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

namespace Identity.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierServiceEmail _context;

        public SupplierController(ISupplierServiceEmail context)
        {
            _context = context;
        }

      

        [HttpPost]
        [Route("SaveSupplierServiceEmail")]
        public async Task<Result> SaveSupplierServiceEmail(SupplierServiceEmailModel supplierServiceEmailModel)
        {
            try
            {
                return await _context.SaveSupplierServiceEmail(supplierServiceEmailModel);
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
                return await _context.SaveSupplierServiceMapping(supplierServiceMappingModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
