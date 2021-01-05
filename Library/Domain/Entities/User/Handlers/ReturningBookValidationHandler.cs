using FluentValidation;
using Library.Domain.Commands.Events.Events;
using Library.Domain.Validators;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Domain.Entities.User.Handlers
{
    public class ReturningBookValidationHandler : INotificationHandler<ReturningBook>
    {
        private readonly ReturningBookValidator validator;

        public ReturningBookValidationHandler(ReturningBookValidator validator) => this.validator = validator;

        public Task Handle(ReturningBook @event, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(@event.Command);

            return Task.CompletedTask;
        }
    }

}
