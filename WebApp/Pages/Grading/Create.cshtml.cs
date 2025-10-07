using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Pages.Grading
{
    public class CreateModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public CreateModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public GradeCreateModel Input { get; set; } = new GradeCreateModel();

        public string ApiBaseUrl => _configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7020";

        public void OnGet(int? submissionId)
        {
            if (submissionId.HasValue)
            {
                Input.SubmissionId = submissionId.Value;
            }
        }

        public class GradeCreateModel
        {
            [Required(ErrorMessage = "Please select a submission")]
            [Display(Name = "Submission")]
            public int SubmissionId { get; set; }

            [Required(ErrorMessage = "Please enter a grade")]
            [Display(Name = "Grade")]
            [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100")]
            public decimal Grade { get; set; }

            [Display(Name = "Feedback")]
            public string? Feedback { get; set; }

            [Display(Name = "Grading Status")]
            public string GradingStatus { get; set; } = "Graded";

            [Display(Name = "Private Notes")]
            public string? PrivateNotes { get; set; }

            [Display(Name = "Rubric Scores")]
            public Dictionary<string, decimal>? RubricScores { get; set; }

            [Display(Name = "Grade Override Reason")]
            public string? GradeOverrideReason { get; set; }

            [Display(Name = "Notify Student")]
            public bool NotifyStudent { get; set; } = true;
        }
    }
}