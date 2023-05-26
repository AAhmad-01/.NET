using System.ComponentModel.DataAnnotations;

namespace ZavaJApplicationApi.Model
{
    public class ZavajVipPlansTabls
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public double Price { get; set; }

        public string Benefits { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool IsActive { get; set; } = false;
    }
}
 
