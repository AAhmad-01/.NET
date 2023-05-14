using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZavaJApplicationApi.Model
{
    public class NotificationTable
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public string Message { get; set; } = string.Empty;

        public DateTime DateTime { get; set; }

        public bool IsRead { get; set; }
    }
}
