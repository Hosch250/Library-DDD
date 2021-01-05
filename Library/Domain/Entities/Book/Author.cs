using System;

namespace Library.Domain.Entities.Book
{
    public class Author
    {
        public Author(string name, DateTime? birthDate, DateTime? deathDate)
        {
            Name = name;
            BirthDate = birthDate;
            DeathDate = deathDate;
        }

        public string Name { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public DateTime? DeathDate { get; private set; }
    }
}
