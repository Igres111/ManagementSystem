namespace ManagmentSystemApi.Models
{
    public class ProjectForUser
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
    }
}
