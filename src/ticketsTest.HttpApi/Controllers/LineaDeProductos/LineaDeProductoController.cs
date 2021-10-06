using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using ticketsTest.LineaDeProductos;

namespace ticketsTest.Controllers.LineaDeProductos
{
    [RemoteService]
    [Area("app")]
    [ControllerName("LineaDeProducto")]
    [Route("api/app/linea-de-productos")]

    public class LineaDeProductoController : AbpController, ILineaDeProductosAppService
    {
        private readonly ILineaDeProductosAppService _lineaDeProductosAppService;

        public LineaDeProductoController(ILineaDeProductosAppService lineaDeProductosAppService)
        {
            _lineaDeProductosAppService = lineaDeProductosAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<LineaDeProductoDto>> GetListAsync(GetLineaDeProductosInput input)
        {
            return _lineaDeProductosAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<LineaDeProductoDto> GetAsync(Guid id)
        {
            return _lineaDeProductosAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<LineaDeProductoDto> CreateAsync(LineaDeProductoCreateDto input)
        {
            return _lineaDeProductosAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<LineaDeProductoDto> UpdateAsync(Guid id, LineaDeProductoUpdateDto input)
        {
            return _lineaDeProductosAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _lineaDeProductosAppService.DeleteAsync(id);
        }
    }
}