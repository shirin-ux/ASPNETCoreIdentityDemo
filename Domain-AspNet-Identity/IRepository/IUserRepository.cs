namespace Domain_AspNet_Identity.IRepository
{
    public interface IUserRepository
    {
        Task<bool> GetByPhoneNumberAsync(string phoneNumber);
        Task CreateUser(IUser user);

    }
}
