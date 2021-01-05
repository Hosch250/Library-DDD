using Library.Domain.Entities.Book;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Application
{
    public interface IBookApplication
    {
        Task<List<Book>> GetAll();
    }
}
