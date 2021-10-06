using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using ticketsTest.EntityFrameworkCore;

namespace ticketsTest.LineaDeProductos
{
    public class EfCoreLineaDeProductoRepository : EfCoreRepository<ticketsTestDbContext, LineaDeProducto, Guid>, ILineaDeProductoRepository
    {
        public EfCoreLineaDeProductoRepository(IDbContextProvider<ticketsTestDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<LineaDeProducto>> GetListAsync(
            string filterText = null,
            string descripcion = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, descripcion);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? LineaDeProductoConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string descripcion = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, descripcion);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<LineaDeProducto> ApplyFilter(
            IQueryable<LineaDeProducto> query,
            string filterText,
            string descripcion = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Descripcion.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(descripcion), e => e.Descripcion.Contains(descripcion));
        }
    }
}