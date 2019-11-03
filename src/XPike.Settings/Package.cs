using XPike.IoC;
using XPike.Settings.Basic;
using XPike.Settings.Managers;
using XPike.Settings.Providers;
using XPike.Settings.Providers.Configuration;

namespace XPike.Settings
{
    /// <summary>
    /// XPike Settings
    /// 
    /// Package Dependencies:
    /// - XPike.Configuration
    /// 
    /// Singleton Registrations:
    /// - IConfigurationSettingsProvider => ConfigurationSettingsProvider
    /// - ISettingsService => SettingsService
    /// - ISettingsManager<> => SettingsManager<>
    /// - ISettings<> => SettingsLoader<>
    /// 
    /// Collection Registrations:
    /// - ISettingsProvider += IConfigurationSettingsProvider
    /// </summary>
    public class Package
        : IDependencyPackage
    {
        public void RegisterPackage(IDependencyCollection dependencies)
        {
            // Load other Packages we depend on...
            dependencies.LoadPackage(new XPike.Configuration.Package());

            // Register our implementations...
            dependencies.RegisterSingleton<IConfigurationSettingsProvider, ConfigurationSettingsProvider>();
            dependencies.RegisterSingleton<ISettingsService, SettingsService>();
            dependencies.RegisterSingleton(typeof(ISettingsManager<>), typeof(DefaultSettingsManager<>));
            dependencies.RegisterTransient(typeof(ISettings<>), typeof(SettingsLoader<>));

            // Delegate mappings...

            // By default, use IConfigurationSettingsProvider, which loads Settings from the IConfigurationService.
            dependencies.AddSingletonToCollection<ISettingsProvider, IConfigurationSettingsProvider>(provider => provider.ResolveDependency<IConfigurationSettingsProvider>());
        }
    }
}