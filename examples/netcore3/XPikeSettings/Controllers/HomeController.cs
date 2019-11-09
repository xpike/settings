using System;
using Example.Library;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using XPike.Settings;

namespace XPikeSettings.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISettingsService _settingsService;
        private readonly ISettings<SomeConfig> _someSettings;
        private readonly ISettings<AnotherConfig> _otherSettings;

        public HomeController(ISettingsService settingsService, ISettings<SomeConfig> someSettings, ISettings<AnotherConfig> otherSettings)
        {
            _settingsService = settingsService;
            _someSettings = someSettings;
            _otherSettings = otherSettings;
        }

        public IActionResult Index()
        {
            ViewData["config"] = JsonConvert.SerializeObject(_settingsService.GetValue<SomeConfig>("Example.Library.SomeConfig"));

            // NOTE: Test not entirely applicable - since IConfiguration does not support de-serialization from an individual key which stores a JSON string.
            //ViewData["config2"] = JsonConvert.SerializeObject(_config.GetSection("Example:Library:SomeConfig").Get<SomeConfig>());

            ViewData["config2"] = "N/A - ISettingsService does not return raw values.";

            ViewData["config3"] = "N/A - IConfiguration can't access properties of a JSON string.";
            ViewData["config4"] = "N/A - IConfigurationService can't access properties of a JSON string.";

            ViewData["config2-1"] = JsonConvert.SerializeObject(_settingsService.GetValue<AnotherConfig>("Example.Library.AnotherConfig"));
            ViewData["config2-2"] = "N/A - ISettingsService does not return raw values.";
            ViewData["config2-3"] = _settingsService.GetValue<string>("Example.Library.AnotherConfig::Name");
            ViewData["config2-4"] = "N/A - ISettingsService does not return raw values.";

            ViewData["value1"] = _settingsService.GetValue<DateTime>("Example.Library.SomeConfig::SomeDate");
            ViewData["value2"] = "N/A - ISettingsService does not return raw values.";

            ViewData["value2-1"] = _settingsService.GetValue<DateTime>("Example.Library.AnotherConfig::AnotherDate");
            ViewData["value2-2"] = "N/A - ISettingsService does not return raw values.";

            ViewData["someconfig"] = JsonConvert.SerializeObject(_someSettings);
            ViewData["anotherconfig"] = JsonConvert.SerializeObject(_otherSettings);

            return View();
        }
    }
}
