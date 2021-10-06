using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using ticketsTest.LineaDeProductos;
using ticketsTest.EntityFrameworkCore;
using Xunit;

namespace ticketsTest.LineaDeProductos
{
    public class LineaDeProductoRepositoryTests : ticketsTestEntityFrameworkCoreTestBase
    {
        private readonly ILineaDeProductoRepository _lineaDeProductoRepository;

        public LineaDeProductoRepositoryTests()
        {
            _lineaDeProductoRepository = GetRequiredService<ILineaDeProductoRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _lineaDeProductoRepository.GetListAsync(
                    descripcion: "7b019c4d819343a39bdee57453f6b435c2861e568f7b4cd1993c4470d5eb1d4f12a8ef91a6704fc09fb3f3d59885267b48cb"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("8025ddad-1e1e-49cf-8550-0aa90a6d0527"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _lineaDeProductoRepository.GetCountAsync(
                    descripcion: "e786ed727a5949dfa9437cff1177ff57cca887dd8fd64e3f98ecb8940c89ce004756be56f97a4a929c0f1d08db21d91a5def"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}