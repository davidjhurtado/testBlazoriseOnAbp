using System;
using System.ComponentModel.DataAnnotations;

namespace ticketsTest.LineaDeProductos
{
    public class LineaDeProductoCreateDto
    {
        [Required]
        [StringLength(LineaDeProductoConsts.DescripcionMaxLength, MinimumLength = LineaDeProductoConsts.DescripcionMinLength)]
        public string Descripcion { get; set; }
    }
}