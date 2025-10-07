using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Pages.Submissions
{
    public class DetailsModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public DetailsModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public string ApiBaseUrl => _configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7020";

        public void OnGet()
        {
            // Data will be loaded via JavaScript
        }
    }
}