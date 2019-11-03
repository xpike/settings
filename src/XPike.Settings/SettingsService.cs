using System.Collections.Generic;
using XPike.Configuration;
using XPike.Settings.Providers;

namespace XPike.Settings.Basic
{
    /// <summary>
    /// The default implementation of ISettingsService which retrieves its values from the
    /// DI-registered collection of ISettingsProvider instances.
    /// 
    /// This shares a common base class with Configuration Service, and only really differs
    /// where necessary (a different object type held in the collection, and a few overloads
    /// specific to the concept of loading strongly-typed settings allowing simple customization.
    /// </summary>
    public class SettingsService
        : ConfigurationServiceBase<ISettingsProvider>,
          ISettingsService
    {
        public SettingsService(IEnumerable<ISettingsProvider> providers)
            : base(providers)
        {
        }

        public virtual ISettings<TSettings> WrapSettings<TSettings>(string key, TSettings settings)
            where TSettings : class =>
            new Settings<TSettings>(key, settings);

        public virtual ISettings<TSettings> GetSettingsOrDefault<TSettings>(string key, TSettings defaultValue = default)
            where TSettings : class =>
            WrapSettings(key, GetValueOrDefault(key, defaultValue));

        public virtual ISettings<TSettings> GetSettings<TSettings>(string key)
            where TSettings : class =>
            WrapSettings(key, GetValue<TSettings>(key));
    }
}