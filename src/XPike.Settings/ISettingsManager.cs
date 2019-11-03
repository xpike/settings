using System;

namespace XPike.Settings
{
    /// <summary>
    /// Defines a Settings Manager, which is an implementation with the logic necessary for retrieving ISettings<>.
    /// </summary>
    /// <typeparam name="TSettings"></typeparam>
    public interface ISettingsManager<TSettings>
        where TSettings : class
    {
        /// <summary>
        /// Retrieves the settings, wrapped in an ISettings interface to provide some metadata.
        /// </summary>
        /// <returns></returns>
        ISettings<TSettings> GetSettings();

        /// <summary>
        /// Retrieves the settings, wrapped in an ISettings interface to provide some metadata.
        /// </summary>
        /// <returns></returns>
        ISettings<TSettings> GetSettingsOrDefault(TSettings defaultValue);

        /// <summary>
        /// Retrieves just the settings object itself without a wrapper.
        /// </summary>
        /// <returns></returns>
        TSettings GetValue();
    }
}