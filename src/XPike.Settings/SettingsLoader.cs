using System;

namespace XPike.Settings.Managers
{
    /// <summary>
    /// The default implementation of ISettingsLoader which retrieves its settings using an ISettingsManager<TSettings>.
    /// This also implements ISettings to provide a single injectable which can retrieve the settings object and proxy to it.
    /// </summary>
    /// <typeparam name="TSettings"></typeparam>
    public class SettingsLoader<TSettings>
        : ISettingsLoader<TSettings>
          where TSettings : class
    {
        private readonly ISettings<TSettings> _settings;

        public SettingsLoader(ISettingsManager<TSettings> settingsManager)
        {
            _settings = settingsManager.GetSettings();
        }

        public string ConfigurationKey =>
            _settings.ConfigurationKey;

        public TSettings Value =>
            _settings.Value;

        public DateTime LastRetrievedUtc =>
            _settings.LastRetrievedUtc;
    }
}