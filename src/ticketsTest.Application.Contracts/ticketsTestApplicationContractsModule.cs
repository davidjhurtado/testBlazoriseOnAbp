﻿using Volo.Abp.Account;
using Volo.Abp.AuditLogging;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.LanguageManagement;
using Volo.Abp.LeptonTheme.Management;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TextTemplateManagement;
using Volo.Saas.Host;

namespace ticketsTest
{
    [DependsOn(
        typeof(ticketsTestDomainSharedModule),
        typeof(AbpFeatureManagementApplicationContractsModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpPermissionManagementApplicationContractsModule),
        typeof(AbpSettingManagementApplicationContractsModule),
        typeof(SaasHostApplicationContractsModule),
        typeof(AbpAuditLoggingApplicationContractsModule),
        typeof(AbpIdentityServerApplicationContractsModule),
        typeof(AbpAccountPublicApplicationContractsModule),
        typeof(AbpAccountAdminApplicationContractsModule),
        typeof(LanguageManagementApplicationContractsModule),
        typeof(LeptonThemeManagementApplicationContractsModule),
        typeof(TextTemplateManagementApplicationContractsModule)
    )]
    public class ticketsTestApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            ticketsTestDtoExtensions.Configure();
        }
    }
}
