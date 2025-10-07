using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Pages.Assessments
{
    public class CreateModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public CreateModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public AssessmentCreateModel Input { get; set; } = new AssessmentCreateModel();

        public string ApiBaseUrl => _configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7020";

        public void OnGet(int? courseId)
        {
            if (courseId.HasValue)
            {
                Input.CourseId = courseId.Value;
            }
        }

        public class AssessmentCreateModel
        {
            [Required(ErrorMessage = "Please select a course")]
            [Display(Name = "Course")]
            public int CourseId { get; set; }

            [Required(ErrorMessage = "Please enter an assessment title")]
            [Display(Name = "Assessment Title")]
            [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
            public string Title { get; set; } = "";

            [Display(Name = "Description")]
            public string? Description { get; set; }

            [Required(ErrorMessage = "Please select an assessment type")]
            [Display(Name = "Assessment Type")]
            public string AssessmentType { get; set; } = "Assignment";

            [Display(Name = "Category")]
            public string? Category { get; set; }

            [Required(ErrorMessage = "Please enter maximum marks")]
            [Display(Name = "Max Marks")]
            [Range(1, 1000, ErrorMessage = "Maximum marks must be between 1 and 1000")]
            public int TotalPoints { get; set; } = 100;

            [Display(Name = "Duration (minutes)")]
            [Range(1, 600, ErrorMessage = "Duration must be between 1 and 600 minutes")]
            public int? DurationMinutes { get; set; }

            [Display(Name = "Attempts Allowed")]
            [Range(1, 10, ErrorMessage = "Attempts must be between 1 and 10")]
            public int AttemptsAllowed { get; set; } = 1;

            [Required(ErrorMessage = "Please enter weighting percentage")]
            [Display(Name = "Weighting Percentage")]
            [Range(0, 100, ErrorMessage = "Weighting must be between 0 and 100")]
            public decimal WeightingPercentage { get; set; } = 0;

            [Display(Name = "Open Date")]
            public DateTime? OpenDate { get; set; }

            [Display(Name = "Due Date")]
            public DateTime? DueDate { get; set; }

            [Display(Name = "Close Date")]
            public DateTime? CloseDate { get; set; }

            [Display(Name = "Requires Moderation")]
            public bool RequiresModeration { get; set; } = false;

            [Display(Name = "Requires External Moderation")]
            public bool RequiresExternalModeration { get; set; } = false;

            [Display(Name = "Moderation Percentage")]
            [Range(0, 100, ErrorMessage = "Moderation percentage must be between 0 and 100")]
            public decimal? ModerationPercentage { get; set; }

            [Display(Name = "Status")]
            public string Status { get; set; } = "Draft";

            [Display(Name = "Instructions/Additional Info")]
            public string? Instructions { get; set; }

            [Display(Name = "Is Published")]
            public bool IsPublished { get; set; } = false;
        }
    }
}