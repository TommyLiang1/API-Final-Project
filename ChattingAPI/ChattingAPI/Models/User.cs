using System;
namespace ChattingAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Bio { get; set; }
        public string? City { get; set; }
        public string? Education { get; set; }
        public string? ImgUrl { get; set; }
    }
}
