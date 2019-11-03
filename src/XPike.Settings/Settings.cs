using System;

namespace XPike.Settings.Basic
{
    /// <summary>
    /// The default implementation of ISettings, which simply wraps a Settings object while also
    /// tracking its Configuration Key and Last Retrieved Timestamp in UTC.
    /// </summary>
    /// <typeparam name="TSettings"></typeparam>
    public class Settings<TSettings>
        : ISettings<TSettings>
          where TSettings : class
    {
        public TSettings Value { get; }

        public string ConfigurationKey { get; }

        public DateTime LastRetrievedUtc { get; }

        public Settings(string configKey, TSettings settings)
        {
            ConfigurationKey = configKey;
            Value = settings;
            LastRetrievedUtc = DateTime.UtcNow;
        }
    }
}