using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZavaJApplicationApi.Model
{
    public class MatchTable
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public int MatchUserId { get; set; }

        [ForeignKey(nameof(MatchUserId))]
        public User? MatchUser { get; set; }

        public int MatchLevelId { get; set; }

    }
}
