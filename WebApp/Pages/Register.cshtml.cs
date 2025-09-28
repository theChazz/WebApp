using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}