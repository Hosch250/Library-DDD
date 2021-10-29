using AutoMapper;
using Library.Domain.Entities.User;
using Library.Domain.Entities.User.Factories;
using Library.Infrastructure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly ILibraryRepository libraryRepository;
        private readonly UserFactory userFactory;
        private readonly IMapper mapper;

        public UserApplication(ILibraryRepository libraryRepository, UserFactory userFactory, IMapper mapper)
        {
            this.libraryRepository = libraryRepository;
            this.userFactory = userFactory;
            this.mapper = mapper;
        }

        public async Task<ApiContracts.User?> GetUser(Guid id)
        {
            var user = await libraryRepository.GetUserAsync(id);
            if (user is null)
            {
                return null;
            }

            return mapper.Map<User, ApiContracts.User>(user);
        }

        public async Task<IReadOnlyList<ApiContracts.User>> GetUsers(IReadOnlyList<Guid> ids)
        {
            var users = await libraryRepository.GetUsersAsync(ids);
            return users.Select(mapper.Map<User, ApiContracts.User>).ToList();
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

        public async Task<ApiContracts.User> CreateUser(string name)
        {
            var user = await userFactory.CreateUserAsync(name);

            await libraryRepository.Insert(user);

            return mapper.Map<User, ApiContracts.User>(user);
        }
    }
}
