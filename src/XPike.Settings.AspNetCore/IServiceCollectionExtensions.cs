using Microsoft.Extensions.DependencyInjection;
using System;

namespace XPike.Settings.AspNetCore
{
    /// <summary>
    /// Extension methods for IServiceCollection which allows XPike Settings to be used to
    /// provide values for the Microsoft.Extensions.Options.IOptions pattern.
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Coonfigures XPike Settings to use the specified key to retrieve Settngs of TSettings.
        /// </summary>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="services"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureXPikeSettings<TSettings>(this IServiceCollection services, string key)
            where TSettings : class =>
            services.AddSingleton<ISettingsManager<TSettings>>(provider =>
                new SettingsManager<TSettings>(provider.GetRequiredService<ISettingsService>(), key));

        /// <summary>
        /// Coonfigures XPike Settings to retrieve Settngs of TSettings from the default configuration key.
        /// and allowing you to specify an action which will occur after the value is loaded to
        /// perform some additional post-processing before the settings are returned to the caller.
        /// </summary>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="services"></param>
        /// <param name="postConfigureAction"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureXPikeSettings<TSettings>(this IServiceCollection services, Action<TSettings> postConfigureAction)
            where TSettings : class =>
            services.AddSingleton<ISettingsManager<TSettings>>(provider =>
                new SettingsManager<TSettings>(provider.GetRequiredService<ISettingsService>(), postConfigureAction));

        /// <summary>
        /// Coonfigures XPike Settings to use the specified key to retrieve Settngs of TSettings,
        /// and allowing you to specify an action which will occur after the value is loaded to
        /// perform some additional post-processing before the settings are returned to the caller.
        /// </summary>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="services"></param>
        /// <param name="key"></param>
        /// <param name="postConfigureAction"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureXPikeSettings<TSettings>(this IServiceCollection services, string key, Action<TSettings> postConfigureAction)
            where TSettings : class =>
            services.AddSingleton<ISettingsManager<TSettings>>(provider =>
                new SettingsManager<TSettings>(provider.GetRequiredService<ISettingsService>(), key, postConfigureAction));

        /// <summary>
        /// Configures XPike Settings to retrieve Settings of TSettings using the specified Settings Manager.
        /// </summary>
        /// <typeparam name="TSettings"></typeparam>
        /// <typeparam name="TManager"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureXPikeSettings<TSettings, TManager>(this IServiceCollection services)
            where TSettings : class
            where TManager : ISettingsManager<TSettings> =>
            services.AddSingleton<ISettingsManager<TSettings>>();
    }
}