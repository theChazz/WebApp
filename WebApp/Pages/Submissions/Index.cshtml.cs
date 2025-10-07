using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Pages.Submissions
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty(SupportsGet = true)]
        public SubmissionFilterModel Filters { get; set; } = new SubmissionFilterModel();

        [BindProperty(SupportsGet = true)]
        public string ViewMode { get; set; } = "grid";

        public string ApiBaseUrl => _configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7020";

        public void OnGet()
        {
            // Page will be populated via JavaScript
        }

        public class SubmissionFilterModel
        {
            public string Search { get; set; } = "";
            public int? StudentId { get; set; }
            public int? AssessmentId { get; set; }
            public int? CourseId { get; set; }
            public string SubmissionStatus { get; set; } = "";
            public string GradingStatus { get; set; } = "";
            public string SortBy { get; set; } = "SubmittedAt";
            public string SortDirection { get; set; } = "desc";
            public int Page { get; set; } = 1;
            public int PageSize { get; set; } = 20;
            public DateTime? SubmittedAfter { get; set; }
            public DateTime? SubmittedBefore { get; set; }
            public DateTime? DueAfter { get; set; }
            public DateTime? DueBefore { get; set; }
            public bool? HasFiles { get; set; }
            public bool? IsLate { get; set; }
            public decimal? MinGrade { get; set; }
            public decimal? MaxGrade { get; set; }
        }
    }
}