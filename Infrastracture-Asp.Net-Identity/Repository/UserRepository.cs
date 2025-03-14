using Domain_AspNet_Identity;
using Domain_AspNet_Identity.IRepository;
using Infrastracture_Asp.Net_Identity.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture_Asp.Net_Identity.Repository
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task CreateUser(IUser user)
        {
            await _context.Users.AddAsync(new Microsoft.AspNetCore.Identity.IdentityUser
            {
                Email=user.email,
                PhoneNumber=user.phoneNumer,
               UserName=user.userName,
               PasswordHash=user.hasPssword
            });
          await  _context.SaveChangesAsync();
        }

        public async Task<bool> GetByPhoneNumberAsync(string phoneNumber)
        {
            var user = await _context.Users.Where(x => x.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
            if (user == null)
                return false;
            return true;
        }
    }
}
