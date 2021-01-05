using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Library.Infrastructure.Storage
{
    public interface IRepository<TDocument>
    {
        ValueTask Add(TDocument item);
        ValueTask AddRange(IEnumerable<TDocument> items);
        ValueTask AddRange(params TDocument[] items);
        ValueTask Update(Expression<Func<TDocument, bool>> filter, TDocument value);
        ValueTask Remove(Expression<Func<TDocument, bool>> filter);
        ValueTask RemoveRange(Expression<Func<TDocument, bool>> filter);
        IQueryable<TDocument> AsQueryable();
    }
}
