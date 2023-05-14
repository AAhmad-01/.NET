using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZavaJApplicationApi.Model
{
    public class OtpTable
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]

        public User? User { get; set; }

        public int OtpCode { get; set; }

        public bool IsCodeVerified { get; set; }



    }
}
