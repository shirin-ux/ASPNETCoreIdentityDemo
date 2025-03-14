using ASPNETCoreIdentityDemo_Application.IServices;
using Domain_AspNet_Identity.Entities;
using Domain_AspNet_Identity.IRepository;

namespace Infrastracture_Asp.Net_Identity.ExternalService
{
    public class OtpService(IOtpRepository otpRepository,ISmsService smsService) : IOtpService
    {
        private readonly IOtpRepository _otpRepository = otpRepository;
        private readonly ISmsService _smsService = smsService;
        private readonly Random random = new();
        public async Task<string> GenerateOtpAsync(string phoneNumber,string userId)
        {
            //var existingOtp = await _otpRepository.GetLastedOtpCode(userId);
            //if (existingOtp.IsUsed)
            //    return existingOtp.Code;

            var code = random.Next(0, 100000).ToString();
            var otp = new OtpCode
            {
                Code = code,
                ExpirationTime = DateTime.Now,
                IsUsed = false,
                UserId = userId
            };
            await _otpRepository.AddOtpAsync(otp);
            await _otpRepository.SaveChangesAsync();

            await _smsService.SendSmsAsync(phoneNumber, otp.Code);
            return code;
        }

        public async Task<bool> VerfiyOtpAsync(string userId, string code)
        {
            var otp = await _otpRepository.GetValidOtpCode(userId, code);
            if (otp == null)
                return false;

            return true;
        }
    }
}
