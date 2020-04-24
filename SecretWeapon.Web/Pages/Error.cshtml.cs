using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SecretWeapon.Web.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        private readonly ILogger<ErrorModel> _logger;

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public string DeRequestId { get; set; }

        public bool DeShowRequestId => !string.IsNullOrEmpty(DeRequestId);

        public void OnGet()
        {
            DeRequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
