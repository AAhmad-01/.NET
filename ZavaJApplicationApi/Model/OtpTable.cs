using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZavaJApplicationApi.Model
{
    public class OtpTable
    {

        [Key]

        public int Id { get; set; }
      public  string? email { get; set; } = "";
        public int OtpCode { get; set; }

        public bool IsCodeVerified { get; set; }

        public DateTime  ExpirationTime { get; set; }

        public string? phoneNumber { get; set; } = "";
        public DateTime CreateDateTime { get; set; } = DateTime.Now;

    }
}
