using System;
using ticketsTest.Shared;
using Volo.Abp.AutoMapper;
using ticketsTest.LineaDeProductos;
using AutoMapper;

namespace ticketsTest
{
    public class ticketsTestApplicationAutoMapperProfile : Profile
    {
        public ticketsTestApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<LineaDeProductoCreateDto, LineaDeProducto>().IgnoreAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<LineaDeProductoUpdateDto, LineaDeProducto>().IgnoreAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<LineaDeProducto, LineaDeProductoDto>();
        }
    }
}