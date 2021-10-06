using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace ticketsTest.LineaDeProductos
{
    public class LineaDeProductosAppServiceTests : ticketsTestApplicationTestBase
    {
        private readonly ILineaDeProductosAppService _lineaDeProductosAppService;
        private readonly IRepository<LineaDeProducto, Guid> _lineaDeProductoRepository;

        public LineaDeProductosAppServiceTests()
        {
            _lineaDeProductosAppService = GetRequiredService<ILineaDeProductosAppService>();
            _lineaDeProductoRepository = GetRequiredService<IRepository<LineaDeProducto, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _lineaDeProductosAppService.GetListAsync(new GetLineaDeProductosInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("8025ddad-1e1e-49cf-8550-0aa90a6d0527")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("69a8d8a3-dd17-4dc6-a71a-444072f1a1ad")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _lineaDeProductosAppService.GetAsync(Guid.Parse("8025ddad-1e1e-49cf-8550-0aa90a6d0527"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("8025ddad-1e1e-49cf-8550-0aa90a6d0527"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new LineaDeProductoCreateDto
            {
                Descripcion = "8b4d01b8cd4543de81e6555e0e2fe4d8535f396b2a07427ea1e235b8457ff9663608318126a948be9a987b58dc1ca8d8adce"
            };

            // Act
            var serviceResult = await _lineaDeProductosAppService.CreateAsync(input);

            // Assert
            var result = await _lineaDeProductoRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Descripcion.ShouldBe("8b4d01b8cd4543de81e6555e0e2fe4d8535f396b2a07427ea1e235b8457ff9663608318126a948be9a987b58dc1ca8d8adce");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new LineaDeProductoUpdateDto()
            {
                Descripcion = "1ed793e5945644e999272400378ac3ee132e643bc8ec4962b50d9a43155295c856ae6c4ec7ea456caf443203175505216aeb"
            };

            // Act
            var serviceResult = await _lineaDeProductosAppService.UpdateAsync(Guid.Parse("8025ddad-1e1e-49cf-8550-0aa90a6d0527"), input);

            // Assert
            var result = await _lineaDeProductoRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Descripcion.ShouldBe("1ed793e5945644e999272400378ac3ee132e643bc8ec4962b50d9a43155295c856ae6c4ec7ea456caf443203175505216aeb");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _lineaDeProductosAppService.DeleteAsync(Guid.Parse("8025ddad-1e1e-49cf-8550-0aa90a6d0527"));

            // Assert
            var result = await _lineaDeProductoRepository.FindAsync(c => c.Id == Guid.Parse("8025ddad-1e1e-49cf-8550-0aa90a6d0527"));

            result.ShouldBeNull();
        }
    }
}