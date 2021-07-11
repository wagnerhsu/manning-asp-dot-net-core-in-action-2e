using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace StoreViewerApplication.Pages
{
    public class IndexModel : PageModel
    {
        public List<Store> Stores { get; }
        public MapSettings MapSettings { get; }
        public AppDisplaySettings AppSettings { get; }

        public IndexModel(
            IOptions<List<Store>> stores,
            IOptions<MapSettings> mapSettings,
            IOptionsSnapshot<AppDisplaySettings> appSettings
            )
        {
            Stores = stores.Value;
            MapSettings = mapSettings.Value;
            AppSettings = appSettings.Value;
        }

        public void OnGet()
        {
        }
    }
}