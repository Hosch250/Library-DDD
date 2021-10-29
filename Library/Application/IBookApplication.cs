using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Application
{
    public interface IBookApplication
    {
        Task<List<ApiContracts.Book>> GetAll();
        Task<IReadOnlyList<ApiContracts.Book>> GetBooks(IReadOnlyList<Guid> ids);
    }
}
