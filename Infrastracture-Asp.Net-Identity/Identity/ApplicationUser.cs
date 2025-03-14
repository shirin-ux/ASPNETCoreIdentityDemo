using Domain_AspNet_Identity;
using Domain_AspNet_Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastracture_Asp.Net_Identity.Identity
{
    public class ApplicationUser : IdentityUser, IUser
    {
        public virtual ICollection<OtpCode> OtpCodes { get; set; } = new List<OtpCode>();

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string userName { get; set; }

        public string phoneNumer { get; set; }

        public string email { get; set; }

        public string hasPssword { get; set; }

        public string password { get; set; }
    }
}
