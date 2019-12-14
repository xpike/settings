using XPike.Configuration.Pipeline;
using XPike.IoC;

namespace XPike.Settings
{
    public static class IDependencyProviderExtensions
    {
        public static IDependencyProvider AddSettingsPipe<TPipe>(this IDependencyProvider provider)
            where TPipe : class, IConfigurationPipe
        {
            provider.ResolveDependency<ISettingsService>()
                .AddToPipeline(provider.ResolveDependency<TPipe>());

            return provider;
        }
    }
}