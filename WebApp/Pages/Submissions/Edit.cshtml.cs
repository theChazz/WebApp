using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Pages.Submissions
{
    public class EditModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public EditModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public SubmissionEditModel Input { get; set; } = new SubmissionEditModel();

        public string ApiBaseUrl => _configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7020";

        public void OnGet()
        {
            // Data will be loaded via JavaScript
        }

        public class SubmissionEditModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Please select a student")]
            [Display(Name = "Student")]
            public int StudentId { get; set; }

            [Required(ErrorMessage = "Please select an assessment")]
            [Display(Name = "Assessment")]
            public int AssessmentId { get; set; }

            [Display(Name = "Submission Text")]
            public string? SubmissionText { get; set; }

            [Display(Name = "Submission Status")]
            public string SubmissionStatus { get; set; } = "Draft";

            [Display(Name = "Notes")]
            public string? Notes { get; set; }

            [Display(Name = "Additional Files")]
            public List<IFormFile>? AdditionalFiles { get; set; }

            [Display(Name = "Files to Remove")]
            public List<int>? FilesToRemove { get; set; }

            [Display(Name = "Allow Late Submission")]
            public bool AllowLateSubmission { get; set; } = false;
        }
    }
}