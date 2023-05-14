using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ZavaJApplicationApi.Model
{
    public class SubscriptionTable
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public int VipPlanId { get; set; }

        [ForeignKey(nameof(VipPlanId))]
        public ZavajVipPlansTabls? ZavajVipPlans { get; set; }   [
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }


    }
}
