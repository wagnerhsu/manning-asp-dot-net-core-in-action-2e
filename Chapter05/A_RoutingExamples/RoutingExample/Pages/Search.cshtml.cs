using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace RoutingExample.Pages
{
    public class SearchModel : PageModel
    {
        private readonly ILogger<SearchModel> _logger;
        private readonly ProductService _productService;
        private readonly LinkGenerator _link;

        public SearchModel(ILogger<SearchModel> logger, ProductService productService, LinkGenerator link)
        {
            _logger = logger;
            _productService = productService;
            _link = link;
        }

        [BindProperty, Required]
        public string SearchTerm { get; set; }
        public List<Product> Results { get; private set; }

        public void OnGet()
        {
            // Demonstrates link generation 
            var url1 = Url.Page("ProductDetails/Index", new { name = "big-widget" });
            var url2= _link.GetPathByPage("/ProductDetails/Index", values: new { name = "big-widget" });
            var url3 = _link.GetPathByPage(HttpContext, "/ProductDetails/Index", values: new { name = "big-widget" });
            var url4 = _link.GetUriByPage(
                page: "/ProductDetails/Index",
                handler: null,
                values: new { name = "big-widget" },
                scheme: "https",
                host: new HostString("example.com"));
            _logger.LogDebug($"url1:{url1}");
            _logger.LogDebug($"url2:{url2}");
            _logger.LogDebug($"url3:{url3}");
            _logger.LogDebug($"url4:{url4}");
            
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Results = _productService.Search(SearchTerm, StringComparison.Ordinal);
            }

        }
        public void OnPostIgnoreCase()
        {
            if (ModelState.IsValid)
            {
                Results = _productService.Search(SearchTerm, StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}