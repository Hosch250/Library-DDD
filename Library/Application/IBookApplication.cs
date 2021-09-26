using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Application
{
    public interface IBookApplication
    {
        Task<List<ApiContracts.Book>> GetAll();
        Task<ApiContracts.Book?> Get(Guid bookId);
    }
}
