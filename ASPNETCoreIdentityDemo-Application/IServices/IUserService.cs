using ASPNETCoreIdentityDemo_Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCoreIdentityDemo_Application.IServices
{
    public interface IUserService
    {

        Task<Result> CreateUserAsync(RegisterRequestDto request);
      //  Task<Result> DeleteUserAsync(string userId);

    }
}
