using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    public class EmailAttachment
    {
        public byte[] ByteArray { get; set; }
        public string Format { get; set; }
    }

    public class EmailPara
    {
        public string Body { get; set; }
        public string Subject { get; set; }
        public List<EmailAttachment> mailAttachment { get; set; }
        public string FileName { get; set; }
        public string ToEmailId { get; set; }
        public string FromEmailId { get; set; }
        public string AgentId { get; set; }
        public string MailType { get; set; }
        public string ServiceName { get; set; }
        public string Url { get; set; }
        public string WebsiteType { get; set; }
        public string WebsiteName { get; set; }
    }
}
