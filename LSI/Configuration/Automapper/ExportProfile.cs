using AutoMapper;
using LSI.BusinessLogic.Dtos;
using LSI.Data.Models;

namespace LSI.Configuration.Automapper
{
    public class ExportProfile : Profile
    {
        public ExportProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Export, ExportDto>().ReverseMap();
            CreateMap<Local, LocalDto>().ReverseMap();


        }
    }
}