namespace ticketsTest.Permissions
{
    public static class ticketsTestPermissions
    {
        public const string GroupName = "ticketsTest";

        public static class Dashboard
        {
            public const string DashboardGroup = GroupName + ".Dashboard";
            public const string Host = DashboardGroup + ".Host";
            public const string Tenant = DashboardGroup + ".Tenant";
        }

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public class LineaDeProductos
        {
            public const string Default = GroupName + ".LineaDeProductos";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}