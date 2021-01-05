using Library.Domain.Entities.User;
using MediatR;

namespace Library.Domain.Events
{
    public class CreatingUser : INotification
    {
        public User Entity { get; }

        public CreatingUser(User entity) => Entity = entity;
    }
}
