using FluentValidation;
using Library.Domain.Commands.Events.Events;
using Library.Domain.Validators;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Domain.Entities.User.Handlers
{
    public class CheckingOutBookValidationHandler : INotificationHandler<CheckingOutBook>
    {
        private readonly CheckingOutBookValidator validator;

        public CheckingOutBookValidationHandler(CheckingOutBookValidator validator) => this.validator = validator;

        public Task Handle(CheckingOutBook @event, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(@event.Command);

            return Task.CompletedTask;
        }
    }
}
