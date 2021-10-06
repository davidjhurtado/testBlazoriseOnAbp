using ticketsTest.LineaDeProductos;
using AutoMapper;

namespace ticketsTest.Blazor
{
    public class ticketsTestBlazorAutoMapperProfile : Profile
    {
        public ticketsTestBlazorAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Blazor project.

            CreateMap<LineaDeProductoDto, LineaDeProductoUpdateDto>();
        }
    }
}