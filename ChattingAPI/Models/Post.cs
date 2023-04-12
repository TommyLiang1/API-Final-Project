using System;
namespace ChattingAPI.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PostDescription { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
