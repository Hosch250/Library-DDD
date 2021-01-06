using AutoMapper;

namespace Library.ApiContracts
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Domain.Entities.Book.Book, Book>();
            CreateMap<Domain.Entities.Book.PublishingHouse, PublishingHouse>();
            CreateMap<Domain.Entities.Book.Author, Author>();

            CreateMap<Domain.Entities.User.User, User>();
            CreateMap<Domain.Entities.User.CheckedOutBook, CheckedOutBook>();
        }
    }
}
