using System;
using XPike.IoC;

namespace XPike.Settings
{
    /// <summary>
    /// The default implementation of an ISettingsManager which uses the ISettingsService to retrieve values.
    /// Can also be instantiated using several constructor overloads to customize the configuration key and post-load actions.
    /// </summary>
    /// <typeparam name="TSettings"></typeparam>
    public class SettingsManager<TSettings>
        : ISettingsManager<TSettings>
          where TSettings : class
    {
        protected readonly ISettingsService _settingsService;
        protected readonly Action<TSettings> _postConfigureAction;

        protected virtual string ConfigurationKey { get; }

        public SettingsManager(ISettingsService settingsService)
            : this(settingsService, typeof(TSettings).ToString())
        {
        }

        public SettingsManager(ISettingsService settingsService, string configKey)
            : this(settingsService, configKey, null)
        {
        }

        public SettingsManager(ISettingsService settingsService, Action<TSettings> postConfigureAction)
            : this(settingsService, typeof(TSettings).ToString(), postConfigureAction)
        {
        }

        public SettingsManager(ISettingsService settingsService, string configKey, Action<TSettings> postConfigureAction)
        {
            _settingsService = settingsService;
            ConfigurationKey = configKey;
            _postConfigureAction = postConfigureAction;
        }

        public virtual TSettings PostConfigureSettings(TSettings settings)
        {
            _postConfigureAction?.Invoke(settings);

            return settings;
        }

        public virtual TSettings PostConfigureSettings(ISettings<TSettings> settings)
        {
            _postConfigureAction?.Invoke(settings.Value);

            return settings.Value;
        }

        /* SettingsManager<T> Support */

        public virtual ISettings<TSettings> GetSettings() =>
            _settingsService.GetSettings<TSettings>(ConfigurationKey);

        public virtual ISettings<TSettings> GetSettingsOrDefault(TSettings defaultValue) =>
            _settingsService.GetSettingsOrDefault<TSettings>(ConfigurationKey, defaultValue);

        public virtual TSettings GetValue() =>
            GetSettings().Value;

        /* Helper Methods for configuration value retrieval */

        protected virtual T GetValueOrDefault<T>(string key, T defaultValue = default) => 
            _settingsService.GetValueOrDefault($"{ConfigurationKey}::{key}", defaultValue);

        protected virtual T GetValue<T>(string key) =>
            _settingsService.GetValue<T>($"{ConfigurationKey}::{key}");

        protected string GetValue(string key) =>
            _settingsService.GetValue($"{ConfigurationKey}::{key}");

        protected string GetValueOrDefault(string key, string defaultValue = null) =>
            _settingsService.GetValueOrDefault($"{ConfigurationKey}::{key}", defaultValue);
    }
}