namespace SupplierMaster.Models.Common
{
    public interface IException
    {
        void LogException(string strMethod, string exception);
    }
}