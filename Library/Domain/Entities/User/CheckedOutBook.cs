using System;

namespace Library.Domain.Entities.User
{
    public class CheckedOutBook
    {
        public CheckedOutBook(Guid bookId, DateTime checkedOutOn, DateTime returnBy)
        {
            BookId = bookId;
            CheckedOutOn = checkedOutOn;
            ReturnBy = returnBy;
        }

        public Guid BookId { get; private set; }
        public DateTime CheckedOutOn { get; private set; }
        public DateTime ReturnBy { get; private set; }
    }
}
