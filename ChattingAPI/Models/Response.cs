namespace ChattingAPI.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public List<User?> User { get; set; }
        public List<Post?> Post { get; set; }
    }
}
