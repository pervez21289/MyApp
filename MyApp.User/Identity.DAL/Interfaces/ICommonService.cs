using Identity.DAL.Entities;
using Identity.DAL.Models;
using System.Data;

namespace Identity.DAL.Interfaces
{
    public interface ICommonService
    {
        Task<DataTable> GetEmailSettingsBySystemId(int SystemId);
        Task<string> GetEmailtemplate(string userCode, string templateName);
    }
}
