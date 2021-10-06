using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using ticketsTest.LineaDeProductos;

namespace ticketsTest.LineaDeProductos
{
    public class LineaDeProductosDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly ILineaDeProductoRepository _lineaDeProductoRepository;

        public LineaDeProductosDataSeedContributor(ILineaDeProductoRepository lineaDeProductoRepository)
        {
            _lineaDeProductoRepository = lineaDeProductoRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await _lineaDeProductoRepository.InsertAsync(new LineaDeProducto
            (
                id: Guid.Parse("8025ddad-1e1e-49cf-8550-0aa90a6d0527"),
                descripcion: "7b019c4d819343a39bdee57453f6b435c2861e568f7b4cd1993c4470d5eb1d4f12a8ef91a6704fc09fb3f3d59885267b48cb"
            ));

            await _lineaDeProductoRepository.InsertAsync(new LineaDeProducto
            (
                id: Guid.Parse("69a8d8a3-dd17-4dc6-a71a-444072f1a1ad"),
                descripcion: "e786ed727a5949dfa9437cff1177ff57cca887dd8fd64e3f98ecb8940c89ce004756be56f97a4a929c0f1d08db21d91a5def"
            ));
        }
    }
}