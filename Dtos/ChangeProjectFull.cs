namespace ManagmentSystemApi.Dtos
{
    public class ChangeProjectFull
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public int WorkerCount { get; set; }
        public string Difficulty { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
