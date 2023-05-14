using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZavaJApplicationApi.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        // We can Set Gender bit for male /Female
        public int Gender { get; set; }

        public double Userlatitude { get; set; }

        public double UserLongitude { get; set; }

        public Byte[]? ProfilePicture { get; set; }

        public Byte[]? Selfie { get; set; }

        public int ProfessionId { get; set; }

        [ForeignKey(nameof(ProfessionId))]
        public ProfessionList? ProfessionList { get; set; }

        //Nationality
        public int EthnicityId { get; set; }

        [ForeignKey(nameof(EthniCityList))]
        public EthniCityList? EthniCityList { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.Now;    

        public DateTime Modified { get; set; }

        public bool isActive { get; set; } = false;

        public int SectId { get; set; }

        [ForeignKey(nameof(SectId))]
        public SectList? SectList { get; set; }

        public int MeritalStatusId { get; set; }

        [ForeignKey(nameof(MeritalStatusId))]
        public MeritalStatusList? MeritalStatusList { get; set; }

        public int EducationId { get; set; }

        [ForeignKey(nameof(EducationId))]
        public EducationList? EducationList { get; set; }

        public int PrayId { get; set; }
        [ForeignKey(nameof(PrayId))]
        public PrayList? PrayList { get; set; }

        public int heightId { get; set; }

        [ForeignKey(nameof(heightId))]
        public HeightList? Height { get; set; }

        public bool IsSmoke { get; set; } = false;

        public bool IsAlocahal { get; set; } = false;

        public bool IsHaveChildren { get; set; } = false;

        public int FutureChildrenId { get; set; }

        [ForeignKey(nameof(FutureChildrenId))]
        public FutureChildrenList? FutureChildren { get; set; }


        public string Bio { get; set; } = string.Empty;

        public bool IsWantToMoveAbroad { get; set; } = false;
    }
}
