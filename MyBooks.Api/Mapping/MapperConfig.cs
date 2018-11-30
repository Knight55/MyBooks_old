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
                    .ForMember(dto => dto.Authors, opt => opt.Ignore())
                    .AfterMap((b, dto, ctx) =>
                    {
                        dto.Authors = b.Writings.Select(w => ctx.Mapper.Map<Dtos.Author>(w.Author)).ToList();
                    });
                cfg.CreateMap<Dtos.Book, Book>();

                cfg.CreateMap<Author, Dtos.Author>()
                    .ForMember(dto => dto.Books, opt => opt.Ignore());
                cfg.CreateMap<Dtos.Author, Author>();

                // TODO: CreateMap for other entities and dtos as well
            });

            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}