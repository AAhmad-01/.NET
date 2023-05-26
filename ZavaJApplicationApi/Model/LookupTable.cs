using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace ZavaJApplicationApi.Model
{

    public class ArtsCultureLookupTable
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ImgUrl { get; set; } = string.Empty;
        public DateTime? CreateDateTime { get; set; } = DateTime.Now;

        public DateTime? Modified { get; set; }

        public bool? IsActive { get; set; } = false;
    }

    public class CommunityLookupTable
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ImgUrl { get; set; } = string.Empty;
        public DateTime? CreateDateTime { get; set; } = DateTime.Now;

        public DateTime? Modified { get; set; }

        public bool? IsActive { get; set; } = false;
    }
    public class LanguageLookupTable
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime? CreateDateTime { get; set; } = DateTime.Now;

        public DateTime? Modified { get; set; }

        public bool? IsActive { get; set; } = false;
    }
    public class UserPersonailityTable
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public int PersonailityId { get; set; }

        [ForeignKey(nameof(PersonailityId))]
        public PersonailityLookupTable? Personaility { get; set; }

        public DateTime? CreateDateTime { get; set; } = DateTime.Now;

        public DateTime? Modified { get; set; }

        public bool? IsActive { get; set; } = false;
    }
    public class FoodDrinkLookupTable
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ImgUrl { get; set; } = string.Empty;
        public DateTime? CreateDateTime { get; set; } = DateTime.Now;

        public DateTime? Modified { get; set; }

        public bool? IsActive { get; set; } = false;
    }
    public class PersonailityLookupTable
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ImgUrl { get; set; } = string.Empty;

        public DateTime? CreateDateTime { get; set; } = DateTime.Now;

        public DateTime? Modified { get; set; }

        public bool? IsActive { get; set; } = false;
    }


    public class UserArtsCultureLookUpTable{

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public int ArtsCultureId { get; set; }

        [ForeignKey(nameof(ArtsCultureId))]
        public ArtsCultureLookupTable? ArtsCultureLookup { get; set; }

        public DateTime? CreateDateTime { get; set; } = DateTime.Now;

        public DateTime? Modified { get; set; }

        public bool? IsActive { get; set; } = false;

    }
    public class UserFoodDrinkLookUpTable
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public int FoodDrinkId { get; set; }

        [ForeignKey(nameof(FoodDrinkId))]
        public FoodDrinkLookupTable? FoodDrinkLookup { get; set; }

        public DateTime? CreateDateTime { get; set; } = DateTime.Now;

        public DateTime? Modified { get; set; }

        public bool? IsActive { get; set; } = false;


    }

    public class ProfessionLookupTable
    {
        [Key]
        public int Id { get; set; }

        public int Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }


        public bool IsActive { get; set; } = false;
    }

    public class EthnicityLookupTable
    {
        [Key]
        public int Id { get; set; }

        public int Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; } = false;
    }

    public class EducationLookupTable
    {
        [Key]
        public int Id { get; set; }

        public int Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; } = false;
    }

    public class SectLookupTable
    {
        [Key]
        public int Id { get; set; }

        public int Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }


        public bool IsActive { get; set; } = false;
    }

    public class MeritalLookupTable
    {
        [Key]
        public int Id { get; set; }

        public int Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; } = false;
    }
    public class HeightLookupTable
    {
        [Key]
        public int Id { get; set; }

        public int Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; } = false;
    }

    public class PrayLookupTable
    {
        [Key]
        public int Id { get; set; }

        public int Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; } = false;
    }

    public class FutureChildrenStatusLookupTable
    {
        [Key]
        public int Id { get; set; }

        public int Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; } = false;
    }
}
