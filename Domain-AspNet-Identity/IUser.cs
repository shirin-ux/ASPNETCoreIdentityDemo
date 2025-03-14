using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_AspNet_Identity
{
    public interface IUser
    {
        string LastName { get; }
        string FirstName { get; }
        string userName { get; }
        string phoneNumer { get; }
        string email { get; }
        string hasPssword { get; }
        string password { get; }
    }
}
