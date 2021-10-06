using ticketsTest.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace ticketsTest.Permissions
{
    public class ticketsTestPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ticketsTestPermissions.GroupName);

            myGroup.AddPermission(ticketsTestPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
            myGroup.AddPermission(ticketsTestPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(ticketsTestPermissions.MyPermission1, L("Permission:MyPermission1"));

            var lineaDeProductoPermission = myGroup.AddPermission(ticketsTestPermissions.LineaDeProductos.Default, L("Permission:LineaDeProductos"));
            lineaDeProductoPermission.AddChild(ticketsTestPermissions.LineaDeProductos.Create, L("Permission:Create"));
            lineaDeProductoPermission.AddChild(ticketsTestPermissions.LineaDeProductos.Edit, L("Permission:Edit"));
            lineaDeProductoPermission.AddChild(ticketsTestPermissions.LineaDeProductos.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ticketsTestResource>(name);
        }
    }
}