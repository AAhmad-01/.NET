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
    }

    public class CommunityLookupTable
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ImgUrl { get; set; } = string.Empty;
    }
    public class LanguageLookupTable
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
    public class UserPersonailityTable
    {

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public int PersonailityId { get; set; }

        [ForeignKey(nameof(PersonailityId))]
        public PersonailityLookupTable? Personaility { get; set; }
    }
    public class FoodDrinkLookupTable
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ImgUrl { get; set; } = string.Empty;
    }
    public class PersonailityLookupTable
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ImgUrl { get; set; } = string.Empty;
    }


    public class UserArtsCultureLookUpTable{

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public int ArtsCultureId { get; set; }

        [ForeignKey(nameof(ArtsCultureId))]
        public ArtsCultureLookupTable? ArtsCultureLookup { get; set; }


    }
    public class UserFoodDrinkLookUpTable
    {

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public int FoodDrinkId { get; set; }

        [ForeignKey(nameof(FoodDrinkId))]
        public FoodDrinkLookupTable? FoodDrinkLookup { get; set; }


    }


}
