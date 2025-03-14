using Domain_AspNet_Identity.Entities;

namespace Domain_AspNet_Identity.IRepository
{
    public interface IOtpRepository
    {
        Task<OtpCode?> GetValidOtpCode(string userId, string code);
        Task<OtpCode?> GetLastedOtpCode(string userId);
        Task AddOtpAsync(OtpCode otp);
        Task SaveChangesAsync();
    }
}
