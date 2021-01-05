using Library.Domain.Entities.User;
using Library.Domain.Entities.User.Factories;
using Library.Infrastructure.Storage;
using System;
using System.Threading.Tasks;

namespace Library.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly LibraryRepository libraryRepository;
        private readonly UserFactory userFactory;

        public UserApplication(LibraryRepository libraryRepository, UserFactory userFactory)
        {
            this.libraryRepository = libraryRepository;
            this.userFactory = userFactory;
        }

        public async Task CheckoutBook(Guid userId, Guid bookId)
        {
            var user = await libraryRepository.GetUserAsync(userId);
            if (user is null)
            {
                throw new ArgumentException("");
            }

            await user.CheckoutBook(new Domain.Commands.CheckoutBookCommand(userId, bookId));

            await libraryRepository.Update(user);
        }

        public async Task ReturnBook(Guid userId, Guid bookId)
        {
            var user = await libraryRepository.GetUserAsync(userId);
            if (user is null)
            {
                throw new ArgumentException("");
            }

            await user.ReturnBook(new Domain.Commands.ReturnBookCommand(userId, bookId));

            await libraryRepository.Update(user);
        }

        public async Task<User> CreateUser(string name)
        {
            var user = await userFactory.CreateUserAsync(name);

            await libraryRepository.Insert(user);

            return user;
        }
    }
}
