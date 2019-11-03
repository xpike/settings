namespace XPike.Settings
{
    public class DefaultSettingsManager<TSettings>
        : SettingsManager<TSettings>
        where TSettings : class
    {
        public DefaultSettingsManager(ISettingsService settingsService)
            : base(settingsService)
        {
            // NOTE: Intentional no-op.
        }
    }
}