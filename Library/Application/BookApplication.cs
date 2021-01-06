using AutoMapper;
using Library.Domain.Entities.Book;
using Library.Infrastructure.Storage;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application
{
    public class BookApplication : IBookApplication
    {
        private readonly ILibraryRepository libraryRepository;
        private readonly IMapper mapper;

        public BookApplication(ILibraryRepository libraryRepository, IMapper mapper)
        {
            this.libraryRepository = libraryRepository;
            this.mapper = mapper;
        }

        public async Task<List<ApiContracts.Book>> GetAll()
        {
            var books = await libraryRepository.GetAllBooksAsync();
            return books.Select(mapper.Map<Book, ApiContracts.Book>).ToList();
        }
    }
}
