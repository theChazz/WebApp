using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Pages.Submissions
{
    public class CreateModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public CreateModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public SubmissionCreateModel Input { get; set; } = new SubmissionCreateModel();

        public string ApiBaseUrl => _configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7020";

        public void OnGet(int? assessmentId, int? studentId)
        {
            if (assessmentId.HasValue)
            {
                Input.AssessmentId = assessmentId.Value;
            }
            if (studentId.HasValue)
            {
                Input.StudentId = studentId.Value;
            }
        }

        public class SubmissionCreateModel
        {
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

            [Display(Name = "Files")]
            public List<IFormFile>? Files { get; set; }

            [Display(Name = "Submit Immediately")]
            public bool SubmitImmediately { get; set; } = false;

            [Display(Name = "Allow Late Submission")]
            public bool AllowLateSubmission { get; set; } = false;
        }
    }
}