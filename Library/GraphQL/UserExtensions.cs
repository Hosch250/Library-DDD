using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using Library.ApiContracts;
using Library.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.GraphQL
{
    [ExtendObjectType(typeof(User))]
    public class UserExtensions
    {
        private readonly IBookApplication bookApplication;

        public UserExtensions(IBookApplication bookApplication)
        {
            this.bookApplication = bookApplication;
        }

        [BindMember(nameof(User.Books))]
        public async Task<IReadOnlyList<CheckedOutBookDetails>> GetBooks([Parent] User user, IResolverContext context)
        {
            var books = await context.BatchDataLoader<Guid, Book>(
                async (keys, ct) =>
                {
                    var books = await bookApplication.GetBooks(keys);
                    return books.ToDictionary(x => x.Id);
                })
            .LoadAsync(user.Books.Select(s => s.BookId).ToList());

            return books.Select(s => {
                var book = user.Books.Single(t => t.BookId == s.Id);
                return new CheckedOutBookDetails(s.Id, s.Isbn, s.Name, s.PublishedOn, s.Publisher, s.Authors, book.CheckedOutOn, book.ReturnBy);
            }).ToList();
        }
    }
}
