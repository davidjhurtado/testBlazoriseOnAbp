using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace ticketsTest.LineaDeProductos
{
    public class LineaDeProducto : AuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Descripcion { get; set; }

        public LineaDeProducto()
        {

        }

        public LineaDeProducto(Guid id, string descripcion)
        {
            Id = id;
            Check.NotNull(descripcion, nameof(descripcion));
            Check.Length(descripcion, nameof(descripcion), LineaDeProductoConsts.DescripcionMaxLength, LineaDeProductoConsts.DescripcionMinLength);
            Descripcion = descripcion;
        }
    }
}