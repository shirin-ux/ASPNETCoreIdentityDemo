using Domain_AspNet_Identity.Entities;
using Domain_AspNet_Identity.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture_Asp.Net_Identity.Repository
{
    public class OtpRepository(ApplicationDbContext context) : IOtpRepository
    {
        private readonly ApplicationDbContext _context=context;

        public async Task AddOtpAsync(OtpCode otp)
        {
            await _context.OtpCodes.AddAsync(otp);
        }

        public async Task<OtpCode?> GetLastedOtpCode(string userId)
        {
            return await _context.OtpCodes.Where(o => o.UserId == userId && o.IsUsed && o.ExpirationTime >= DateTime.UtcNow)
                                             .OrderByDescending(o=>o.ExpirationTime)
                                             .FirstOrDefaultAsync();
        }

        public async Task<OtpCode?> GetValidOtpCode(string userId, string code)
        {
            return await _context.OtpCodes.Where(x => x.UserId == userId && x.Code == code).FirstOrDefaultAsync();
         }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();   
        }
    }
}
