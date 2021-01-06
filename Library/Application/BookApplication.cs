using Library.Domain.Entities.Book;
using Library.Infrastructure.Storage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Application
{
    public class BookApplication : IBookApplication
    {
        private readonly ILibraryRepository libraryRepository;

        public BookApplication(ILibraryRepository libraryRepository)
        {
            this.libraryRepository = libraryRepository;
        }

        public async Task<List<Book>> GetAll()
        {
            return await libraryRepository.GetAllBooksAsync();
        }
    }
}
