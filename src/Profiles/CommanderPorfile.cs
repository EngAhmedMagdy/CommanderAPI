using AutoMapper;
using Commander.Data;
using Commander.model;

namespace Commander.Profiles
{
    public class CommanderProfile : Profile
    {
        public CommanderProfile()
        {
            //source -> destination
            CreateMap<Command,CommanderReadDto>();
            CreateMap<CommanderUpdateDto,Command>();
            CreateMap<CommanderCreateDto,Command>();
            CreateMap<Command,CommanderUpdateDto>();
        }
    }
}