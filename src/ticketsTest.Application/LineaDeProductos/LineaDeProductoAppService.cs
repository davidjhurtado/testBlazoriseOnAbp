using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using ticketsTest.Permissions;
using ticketsTest.LineaDeProductos;

namespace ticketsTest.LineaDeProductos
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ticketsTestPermissions.LineaDeProductos.Default)]
    public class LineaDeProductosAppService : ApplicationService, ILineaDeProductosAppService
    {
        private readonly ILineaDeProductoRepository _lineaDeProductoRepository;

        public LineaDeProductosAppService(ILineaDeProductoRepository lineaDeProductoRepository)
        {
            _lineaDeProductoRepository = lineaDeProductoRepository;
        }

        public virtual async Task<PagedResultDto<LineaDeProductoDto>> GetListAsync(GetLineaDeProductosInput input)
        {
            var totalCount = await _lineaDeProductoRepository.GetCountAsync(input.FilterText, input.Descripcion);
            var items = await _lineaDeProductoRepository.GetListAsync(input.FilterText, input.Descripcion, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<LineaDeProductoDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<LineaDeProducto>, List<LineaDeProductoDto>>(items)
            };
        }

        public virtual async Task<LineaDeProductoDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<LineaDeProducto, LineaDeProductoDto>(await _lineaDeProductoRepository.GetAsync(id));
        }

        [Authorize(ticketsTestPermissions.LineaDeProductos.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _lineaDeProductoRepository.DeleteAsync(id);
        }

        [Authorize(ticketsTestPermissions.LineaDeProductos.Create)]
        public virtual async Task<LineaDeProductoDto> CreateAsync(LineaDeProductoCreateDto input)
        {

            var lineaDeProducto = ObjectMapper.Map<LineaDeProductoCreateDto, LineaDeProducto>(input);

            lineaDeProducto = await _lineaDeProductoRepository.InsertAsync(lineaDeProducto, autoSave: true);
            return ObjectMapper.Map<LineaDeProducto, LineaDeProductoDto>(lineaDeProducto);
        }

        [Authorize(ticketsTestPermissions.LineaDeProductos.Edit)]
        public virtual async Task<LineaDeProductoDto> UpdateAsync(Guid id, LineaDeProductoUpdateDto input)
        {

            var lineaDeProducto = await _lineaDeProductoRepository.GetAsync(id);
            ObjectMapper.Map(input, lineaDeProducto);
            lineaDeProducto = await _lineaDeProductoRepository.UpdateAsync(lineaDeProducto, autoSave: true);
            return ObjectMapper.Map<LineaDeProducto, LineaDeProductoDto>(lineaDeProducto);
        }
    }
}