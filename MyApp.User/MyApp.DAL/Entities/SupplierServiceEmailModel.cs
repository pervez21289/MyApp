

namespace MyApp.DAL.Entities
{


    public class SupplierServiceMappingModel
    {

        public Guid SupplierId { get; set; }
        public string ServiceId { get; set; }
        public int Status { get; set; }

        public bool IsApproved { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }



    public class SupplierServiceEmailModel 
    {

        public Guid SupplierId { get; set; }

        public int ServiceId { get; set; }

        public string EmailId { get; set; }

        public int Status { get; set; }

        public bool IsEmailVerified { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        
    }


}
