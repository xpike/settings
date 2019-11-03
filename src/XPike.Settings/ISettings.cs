using System;

namespace XPike.Settings
{
    /// <summary>
    /// Defines an instance of strongly-typed and managed application-oriented settings.
    /// </summary>
    /// <typeparam name="TSettings"></typeparam>
    public interface ISettings<TSettings>
        where TSettings : class
    {
        /// <summary>
        /// The Configuration Key which these settings were retrieved from.
        /// </summary>
        string ConfigurationKey { get; }

        /// <summary>
        /// The actual Settings object that was retrieved.
        /// </summary>
        TSettings Value { get; }

        /// <summary>
        /// The timestamp of when this value was last refreshed.
        /// </summary>
        DateTime LastRetrievedUtc { get; }
    }
}