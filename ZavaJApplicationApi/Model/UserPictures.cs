using System.ComponentModel.DataAnnotations.Schema;

namespace ZavaJApplicationApi.Model
{
    public class UserPictures
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public byte[]? ProfilePicture { get; set; }

    }
}
