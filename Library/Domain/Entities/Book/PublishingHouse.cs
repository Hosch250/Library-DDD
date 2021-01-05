namespace Library.Domain.Entities.Book
{
    public class PublishingHouse
    {
        public PublishingHouse(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
