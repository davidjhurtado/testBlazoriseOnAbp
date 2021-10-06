using System;
using Volo.Abp.Application.Dtos;

namespace ticketsTest.LineaDeProductos
{
    public class LineaDeProductoDto : AuditedEntityDto<Guid>
    {
        public string Descripcion { get; set; }
    }
}