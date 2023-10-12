using Identity.DAL.Entities;
using Identity.DAL.Interfaces;

namespace SupplierMaster.Models.Common
{
    public class Exceptions : IException
    {
        private readonly IExceptionService _exceptionService;
        private readonly IConfiguration _configuration;

        public Exceptions(
        IExceptionService exceptionService,
        IConfiguration configuration)
        {
            _exceptionService = exceptionService;
            _configuration = configuration;
        }
        public void LogException(string strMethod, string exception)
        {
            ErrorInfo er = new ErrorInfo
            {
                ControllerName = "", // Convert.ToString(HttpContext.Current.Request.RequestContext.RouteData.Values["controller"]),
                ActionName = "", //Convert.ToString(HttpContext.Current.Request.RequestContext.RouteData.Values["action"]),
                MethodName = strMethod,
                Exception = exception
            };
            _exceptionService.SaveExceptionDetails(er);
        }

    }

}