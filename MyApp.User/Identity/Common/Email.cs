using Identity.DAL.Entities;
using Identity.DAL.Interfaces;
using Identity.Models;
using SupplierMaster.Models.Common;
using System.Data;

public class Email : IEmail
{
    private readonly IConfiguration _config;
    private readonly ICommonService _commonService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public Email( IConfiguration configuration, IHttpContextAccessor httpContextAccessor, ICommonService commonService)
    {
        _config = configuration;
        _httpContextAccessor = httpContextAccessor;
        _commonService = commonService;
    }
    public async Task<string> SendEmail(
        string to,
        string cc,
        string subject,
        int[] attachment_bpids,
        bool return_receipt, string UserType, string templateName)
    {
        DataTable dt = new DataTable();
        dt = await _commonService.GetEmailSettingsBySystemId(1); //HttpContext.Current.Session["SystemId"]) -- todo

        string smtp_server = "-";
                 
        smtp_server = Convert.ToString(dt.Rows[0]["Host"].ToString());

        System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
        System.Net.Mail.MailMessage mailmsg = new System.Net.Mail.MailMessage();
        System.Net.Mail.SmtpClient mailer = new System.Net.Mail.SmtpClient();
        System.Net.Mail.MailAddress mailaddr = new System.Net.Mail.MailAddress("supplier@raynab2b.com", dt.Rows[0]["FromEmailIdName"].ToString());                        //comment for test
        System.Net.NetworkCredential creds = new System.Net.NetworkCredential(dt.Rows[0]["FromEmailId"].ToString(), dt.Rows[0]["FromEmailIdPass"].ToString());
        string body = await _commonService.GetEmailtemplate(UserType, templateName);

        mailmsg.IsBodyHtml = true;
        mailmsg.Subject = subject;
        mailmsg.To.Add(to);
        if (cc.Trim() != "")
        {
            mailmsg.CC.Add(cc);
        }
        mailmsg.Body = body;
        mailmsg.From = mailaddr;
        mailer.Host = smtp_server;
        mailer.Port = Convert.ToInt32(dt.Rows[0]["Port"].ToString());
        mailer.UseDefaultCredentials = false;
        mailer.Credentials = creds;
        mailer.Send(mailmsg);
        return "";       
    }
   
} 

