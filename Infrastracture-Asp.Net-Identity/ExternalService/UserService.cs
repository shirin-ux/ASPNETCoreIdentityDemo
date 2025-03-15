using ASPNETCoreIdentityDemo_Application.Dto;
using ASPNETCoreIdentityDemo_Application.IServices;
using Domain_AspNet_Identity.IRepository;
using Infrastracture_Asp.Net_Identity.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastracture_Asp.Net_Identity.ExternalService
{
    public class UserService(IUserRepository userRepository,
        
        IPasswordHasher<ApplicationUser> passwordHasher,
         IOtpService otpService ) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IOtpService _otpService= otpService;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher= passwordHasher;


        public async Task<Result> CreateUserAsync(RegisterRequestDto request)
        {

            var exetinguser =await _userRepository.GetByPhoneNumberAsync(request.PhoneNumber);
            if(exetinguser == true)
            {
               ///todo fro login
                await _otpService.GenerateOtpAsync(newUser.PhoneNumber,newUser.Id);
            }
            var newUser = new ApplicationUser
            {
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PasswordHash = _passwordHasher.HashPassword(null, request.Password),
                Email=request.Email
            };
            await _userRepository.CreateUser(newUser);
            await _otpService.GenerateOtpAsync(newUser.PhoneNumber,newUser.Id);
            return new Result
            {
                Message = "user already",
                Success = true
            };
        }

        //public async Task<Result> DeleteUserAsync(ApplicationUser user)
        //{
        //    var result = await _userManager.DeleteAsync(user);
        //    return new Result
        //    {
        //        Message = "Ok",
        //        Success = true
        //    };

        //}

        //public async Task<Result> DeleteUserAsync(string userId)
        //{
        //    var user = await _userManager.FindByIdAsync(userId);
        //    return user != null ? await DeleteUserAsync(user) : null;
        //}

        //public async Task<string?> GetUserNameAsync(string userId)
        //{
        //    var user = await _userManager.FindByIdAsync(userId);
        //    return user?.UserName;
        //}

        //public async Task<bool> IsInRoleAsync(string userId, string role)
        //{
        //    var user = await _userManager.FindByIdAsync(userId);
        //    return user != null && await _userManager.IsInRoleAsync(user, role);

        //}
    }
}
