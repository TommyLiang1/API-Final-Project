using System.ComponentModel.DataAnnotations;
namespace ChattingAPI.Models
{
    public class UserInfo
    {
        [Key]
        public int UserId { get; set; }
        public int UserInfoId { get; set; }
        public int Age { get; set; }
        public string? Bio { get; set; }
        public string? Location { get; set; }
        public string? Education { get; set; }
    }
}
