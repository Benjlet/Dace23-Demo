using Dace23Demo.Models.Users;

namespace Dace23Demo.Abstractions
{
    public interface IUserClient
    {
        Task<User> Generate();
    }
}