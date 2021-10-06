using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ticketsTest.LineaDeProductos
{
    public interface ILineaDeProductoRepository : IRepository<LineaDeProducto, Guid>
    {
        Task<List<LineaDeProducto>> GetListAsync(
            string filterText = null,
            string descripcion = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string descripcion = null,
            CancellationToken cancellationToken = default);
    }
}