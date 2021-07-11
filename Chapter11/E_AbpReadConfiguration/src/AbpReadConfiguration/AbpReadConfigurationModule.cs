using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp.Autofac;
using Volo.Abp.Json;
using Volo.Abp.Modularity;

namespace AbpReadConfiguration
{

    [DependsOn(
        typeof(AbpJsonModule),
        typeof(AbpAutofacModule)
    )]
    public class AbpReadConfigurationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var hostEnvironment = context.Services.GetSingletonInstance<IHostEnvironment>();

            context.Services.AddHostedService<AbpReadConfigurationHostedService>();
            
        }
    }
}
