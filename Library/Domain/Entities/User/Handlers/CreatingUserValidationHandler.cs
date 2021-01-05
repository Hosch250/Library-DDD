using FluentValidation;
using Library.Domain.Events;
using Library.Domain.Validators;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Domain.Entities.User.Handlers
{
    public class CreatingUserValidationHandler : INotificationHandler<CreatingUser>
    {
        private readonly CreatingUserValidator validator;

        public CreatingUserValidationHandler(CreatingUserValidator validator) => this.validator = validator;

        public Task Handle(CreatingUser @event, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(@event.Entity);

            return Task.CompletedTask;
        }
    }
}
