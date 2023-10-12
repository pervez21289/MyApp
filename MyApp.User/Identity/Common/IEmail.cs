namespace SupplierMaster.Models.Common
{
    public interface IEmail
    {
        Task<string> SendEmail(
       string to,
       string cc,
       string subject,
       int[] attachment_bpids,
       bool return_receipt, string UserType, string templateName);
    }
}