using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ticketsTest.LineaDeProductos
{
    public interface ILineaDeProductosAppService : IApplicationService
    {
        Task<PagedResultDto<LineaDeProductoDto>> GetListAsync(GetLineaDeProductosInput input);

        Task<LineaDeProductoDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<LineaDeProductoDto> CreateAsync(LineaDeProductoCreateDto input);

        Task<LineaDeProductoDto> UpdateAsync(Guid id, LineaDeProductoUpdateDto input);
    }
}