using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCoreIdentityDemo_Application.IServices
{
    public interface IOtpService
    {
        Task<string> GenerateOtpAsync(string phoneNumber, string userId);
        Task<bool> VerfiyOtpAsync(string userId, string code);

    }
}
