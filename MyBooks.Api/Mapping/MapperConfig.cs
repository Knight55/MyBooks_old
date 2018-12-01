using System.Linq;
using AutoMapper;
using MyBooks.Bll.Entities;

namespace MyBooks.Api.Mapping
{
    public class MapperConfig
    {
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.AllowNullCollections = true;
                cfg.CreateMap<Book, Dtos.Book>()
                    .ForMember(dto => dto.Genre, opt => opt.MapFrom(src => src.Genre.ToString()))
                    .ForMember(dto => dto.Authors, opt => opt.Ignore())
                    .ForMember(dto => dto.CoverUrl, opt => opt.MapFrom(src => $@"http://localhost:5000/covers/{src.CoverImagePath}"))
                    .AfterMap((b, dto, ctx) =>
                    {
                        dto.Authors = b.BookAuthors.Select(ba => ctx.Mapper.Map<Dtos.Author>(ba.Author)).ToList();
                    });
                cfg.CreateMap<Dtos.Book, Book>();

                cfg.CreateMap<Author, Dtos.Author>()
                    .ForMember(dto => dto.Books, opt => opt.Ignore());
                cfg.CreateMap<Dtos.Author, Author>();

                cfg.CreateMap<Rating, Dtos.Rating>();
                cfg.CreateMap<Dtos.Rating, Rating>();

                // TODO: CreateMap for other entities and dtos as well
            });

            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}