using XPike.Configuration;

namespace XPike.Settings.Providers
{
    /// <summary>
    /// Defines an XPike Settings Provider, which shares a signature with the Configuration Service
    /// by implementing the same IConfigurationProvider and IConfigurationLoader interfaces.
    /// </summary>
    public interface ISettingsProvider
        : IConfigurationProvider,
          IConfigurationLoader
    {
    }
}