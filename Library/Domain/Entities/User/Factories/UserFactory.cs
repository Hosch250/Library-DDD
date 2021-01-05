using Library.Domain.Events;
using System.Threading.Tasks;

namespace Library.Domain.Entities.User.Factories
{
    public class UserFactory
    {
        public async Task<User> CreateUserAsync(string name)
        {
            var user = new User(name);
            await DomainEvents.Raise(new CreatingUser(user));

            return user;
        }
    }
}
