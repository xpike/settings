namespace XPike.Settings.Managers
{
    /// <summary>
    /// Defines a Settings Loader, which is responsible for retrieving a class of strongly-typed settings.
    /// 
    /// This implements ISettings for simplicity - the Loader is what is actually injected when ISettings is requested.
    /// It is responsible for both retrieving the settings as well as acting as a proxy to that retrieved object.
    /// </summary>
    /// <typeparam name="TSettings"></typeparam>
    public interface ISettingsLoader<TSettings>
        : ISettings<TSettings>
          where TSettings : class
    {
    }
}