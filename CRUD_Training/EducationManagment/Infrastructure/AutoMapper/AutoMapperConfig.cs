using AutoMapper;
using Domain.Entities;
using Infrastructure.DataModel;

namespace Infrastructure.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static Mapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<School, Schools>().ReverseMap();
                cfg.CreateMap<Student, Students>().ReverseMap();
                cfg.CreateMap<Classroom, Classrooms>().ReverseMap();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
