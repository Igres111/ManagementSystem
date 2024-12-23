namespace ManagmentSystemApi.Services
{
    public class RefreshTokenRequest
    {
        public RefreshToken RefreshToken { get; set; }
        public RefreshTokenRequest(RefreshToken RefreshToken)
        {
            this.RefreshToken = RefreshToken;
        }
    }
}
