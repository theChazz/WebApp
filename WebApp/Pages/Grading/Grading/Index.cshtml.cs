using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Pages.Grading
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty(SupportsGet = true)]
        public GradingFilterModel Filters { get; set; } = new GradingFilterModel();

        [BindProperty(SupportsGet = true)]
        public string ViewMode { get; set; } = "list";

        public string ApiBaseUrl => _configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7020";

        public void OnGet()
        {
            // Page will be populated via JavaScript
        }

        public class GradingFilterModel
        {
            public string Search { get; set; } = "";
            public int? StudentId { get; set; }
            public int? AssessmentId { get; set; }
            public int? CourseId { get; set; }
            public int? LecturerId { get; set; }
            public string GradingStatus { get; set; } = "";
            public string SortBy { get; set; } = "GradedAt";
            public string SortDirection { get; set; } = "desc";
            public int Page { get; set; } = 1;
            public int PageSize { get; set; } = 20;
            public DateTime? GradedAfter { get; set; }
            public DateTime? GradedBefore { get; set; }
            public decimal? MinGrade { get; set; }
            public decimal? MaxGrade { get; set; }
            public bool? NeedsFeedback { get; set; }
            public bool? IsLate { get; set; }
            public string GradeLevel { get; set; } = "";
        }
    }
}