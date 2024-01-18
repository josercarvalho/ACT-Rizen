using AutoMapper;
using JC_Raizen.Domain.Entidades;
using JC_Raizen.Services.DTO;

namespace JC_Raizen.Services.Mappings
{
    public class ClienteMapping : Profile
    {
        public ClienteMapping()
        {
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
            CreateMap<ClienteDTO, Cliente>().ReverseMap();
            CreateMap<EnderecoDTO, EnderecoDTO>().ReverseMap();
        }
    }
}
