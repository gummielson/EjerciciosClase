using AutoMapper;
using Domain.Entities;
using Infrastructure.Data.DataModel;

namespace Presentation
{
    public class AutoMapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Configuring Employee and EmployeeDTO
                cfg.CreateMap<ITWorker, ITWorkers>()
                    .ForMember(dest => dest.IdWorker, act => act.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, act => act.MapFrom(src => $"{src.Name} {src.Surname}"))
                    .ForMember(dest => dest.RolEnum, act => act.MapFrom(src => ((int)src.WorkerRol)))
                    .ForMember(dest => dest.LevelEnum, act => act.MapFrom(src => ((int)src.ITLevel)));

                //Any Other Mapping Configuration ....
                cfg.CreateMap<Domain.Entities.Team, Infrastructure.Data.DataModel.Team>()
                    .ForMember(dest => dest.IdTeam, act => act.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                    .ForMember(dest => dest.ITWorkers, act => act.MapFrom(src => src.Technicians));
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }

}
