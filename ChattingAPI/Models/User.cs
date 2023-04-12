namespace ChattingAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
