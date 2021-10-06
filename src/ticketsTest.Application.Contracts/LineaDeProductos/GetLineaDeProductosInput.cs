using Volo.Abp.Application.Dtos;
using System;

namespace ticketsTest.LineaDeProductos
{
    public class GetLineaDeProductosInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Descripcion { get; set; }

        public GetLineaDeProductosInput()
        {

        }
    }
}