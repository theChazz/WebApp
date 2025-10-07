using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Assessments
{
    public class EditModel : PageModel
    {
        public int Id { get; set; }

        public void OnGet(int id)
        {
            Id = id;
        }
    }
}