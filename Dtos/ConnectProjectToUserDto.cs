namespace ManagmentSystemApi.Dtos
{
    public class ConnectProjectToUserDto
    {
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
    }
}
