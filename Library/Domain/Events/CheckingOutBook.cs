using MediatR;

namespace Library.Domain.Commands.Events.Events
{
    public class CheckingOutBook : INotification
    {
        public CheckoutBookCommand Command { get; }

        public CheckingOutBook(CheckoutBookCommand command) => Command = command;
    }
}
