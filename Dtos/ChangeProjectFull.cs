using System.ComponentModel.DataAnnotations;

namespace ManagmentSystemApi.Dtos
{
    public class ChangeProjectFull
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Number of workers must be greater than 0.")]
        public int WorkerCount { get; set; }
        [RegularExpression("^(Easy|Medium|Hard)$", ErrorMessage = "Difficulty must be 'Easy', 'Medium', or 'Hard'.")]
        public string Difficulty { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
