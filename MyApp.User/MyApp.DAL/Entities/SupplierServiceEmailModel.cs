

namespace MyApp.DAL.Entities
{
   

public class SupplierServiceEmailModel // Replace "YourTableName" with the actual name of your table
    {
        public int Id { get; set; }

        public int? SupplierId { get; set; }

        public int? ServiceId { get; set; }

        public string EmailId { get; set; }

        public int? Status { get; set; }

        public bool? IsEmailVerified { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        
    }


}
