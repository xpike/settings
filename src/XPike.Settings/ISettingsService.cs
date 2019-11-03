using XPike.Configuration;

namespace XPike.Settings
{
    /// <summary>
    /// Defines a Settings Service, which is the user-facting consumable which acts as a sort of
    /// orchestrator to allow retrieval of Settings from multiple Providers.
    /// 
    /// This shares a signature with IConfigurationService, as wel as adding two variants of GetSettings().
    /// </summary>
    public interface ISettingsService
        : IConfigurationService
    {
        /// <summary>
        /// Retrieves a Settings object wrapped in an ISettings interface to provide some basic metadata.
        /// If the requested key can't be found, an InvalidConfigurationException will be thrown.
        /// </summary>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        ISettings<TSettings> GetSettings<TSettings>(string key)
            where TSettings : class;

        /// <summary>
        /// Retrieves a Settings object wrapped in an ISettings interface to provide some basic metadata.
        /// If the requested key can't be found, the specified defaultValue will be returned instead.
        /// </summary>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        ISettings<TSettings> GetSettingsOrDefault<TSettings>(string key, TSettings defaultValue = default)
            where TSettings : class;
    }
}