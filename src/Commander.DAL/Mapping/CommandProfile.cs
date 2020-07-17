using AutoMapper;
using Commander.DAL.DTO;
using Commander.DAL.Models;

namespace Commander.BLL.Mapping
{
    public class CommandProfile : Profile
    {
        public CommandProfile()
        {
            CreateMap<Command, CommandReadDto>();

            CreateMap<CommandCreateDto, Command>();
        }
    }
}
