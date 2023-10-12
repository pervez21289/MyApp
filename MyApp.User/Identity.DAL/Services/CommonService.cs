using Identity.DAL.Entities;
using Identity.DAL.Interfaces;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace Identity.DAL.Services
{
    public class CommonService : BaseRepo, ICommonService
    {
        public async Task<DataTable> GetEmailSettingsBySystemId(int SystemId)
        {
            return await QueryFirstOrDefaultAsync<DataTable>("GetEmailByMail", SystemId);
        }
        public async Task<string> GetEmailtemplate( string UserType, string templateName)
        {
            return await QueryFirstOrDefaultAsync<string>("GetEmailTemplate", new { userType = "", @TemplateName = templateName });
        }
    }
}
