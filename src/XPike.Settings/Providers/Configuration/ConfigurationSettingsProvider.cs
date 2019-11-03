using System.Collections.Generic;
using XPike.Configuration;

namespace XPike.Settings.Providers.Configuration
{
    /// <summary>
    /// Settings Provider which retrieves its values from XPike Configuration
    /// through the IConfigurationService.
    /// </summary>
    public class ConfigurationSettingsProvider
        : IConfigurationSettingsProvider
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationSettingsProvider(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public string GetValue(string key) =>
            _configurationService.GetValue(key);

        public T GetValue<T>(string key) =>
            _configurationService.GetValue<T>(key);

        public string GetValueOrDefault(string key, string defaultValue = null) =>
            _configurationService.GetValueOrDefault(key, defaultValue);

        public T GetValueOrDefault<T>(string key, T defaultValue = default) =>
            _configurationService.GetValueOrDefault(key, defaultValue);

        public IDictionary<string, string> Load() =>
            _configurationService.Load();
    }
}