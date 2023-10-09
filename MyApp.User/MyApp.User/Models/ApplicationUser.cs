using Microsoft.AspNetCore.Identity;

namespace MyApp.User.Models
{
 

    public class ApplicationUser : IdentityUser
    {
        
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string CompanyName { get; set; }
        public string WebsiteName { get; set; }
        public string PermanantAddress { get; set; }
        public string ISD_MobileNo { get; set; }
        
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MobileNumber { get; set; }
        public string SkypeId { get; set; }
        public string EmailId { get; set; }
        public string Designation { get; set; }
        public int CurrencyId { get; set; }
        public string BookingEmailId { get; set; }
        public bool? IsTour { get; set; }
        public bool? IsHotel { get; set; }
        public bool? IsResturant { get; set; }
        public bool? IsTransfer { get; set; }
        public bool? IsSpa { get; set; }
        public bool? IsFreelancers { get; set; }
        public bool? IsHoliday { get; set; }
        public bool? IsSafariGuide { get; set; }
        public bool? IsTourGuide { get; set; }
        public bool? IsLimoDriver { get; set; }
        public string Password { get; set; }
    }

}
