using System.ComponentModel.DataAnnotations;

namespace Identity.DAL.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public string? UserId { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }        
        public string CompanyName { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string TelephoneNo { get; set; }
        public string MobileNumber { get; set; }
        public int CurrencyId { get; set; }
        public string Designation { get; set; }
        public string LoginEmailId { get; set; }
        public string BookingEmailId { get; set; }
        public string SkypeId { get; set; }
        public bool IsApproved { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }

}
