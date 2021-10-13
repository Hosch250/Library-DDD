using System;

namespace Library.Domain.Entities.Book
{
    public class Author
    {
        //internal Author()
        //{
        //}

        public Author(string name, DateTime? birthDate, DateTime? deathDate)
        {
            Name = name;
            BirthDate = birthDate;
            DeathDate = deathDate;
        }

        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
    }
}
