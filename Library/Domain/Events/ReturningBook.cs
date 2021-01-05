using MediatR;

namespace Library.Domain.Commands.Events.Events
{
    public class ReturningBook : INotification
    {
        public ReturnBookCommand Command { get; }

        public ReturningBook(ReturnBookCommand command) => Command = command;
    }
}
