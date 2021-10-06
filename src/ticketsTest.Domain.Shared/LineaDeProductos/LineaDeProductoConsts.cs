namespace ticketsTest.LineaDeProductos
{
    public static class LineaDeProductoConsts
    {
        private const string DefaultSorting = "{0}Descripcion asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "LineaDeProducto." : string.Empty);
        }

        public const int DescripcionMinLength = 1;
        public const int DescripcionMaxLength = 100;
    }
}