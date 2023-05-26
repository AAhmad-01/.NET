using Microsoft.EntityFrameworkCore;
using ZavaJApplicationApi.Model;

namespace ZavaJApplicationApi.DAL
{
    public class IdentityDBContext : DbContext
    {
        public IdentityDBContext(DbContextOptions<IdentityDBContext> options) : base(options)
        {

        }


        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<OtpTable> OtpTable { get; set; }
        public virtual DbSet<ArtsCultureLookupTable> ArtsCultureLookupTable { get; set; }

        public virtual DbSet<PersonailityLookupTable> PersonailityLookupTable{ get; set; }


        public virtual DbSet<CommunityLookupTable> CommunityLookupTable { get; set; }
        public virtual DbSet<UserPersonailityTable> UserPersonailityTable { get; set; }
        public virtual DbSet<FoodDrinkLookupTable> FoodDrinkLookupTable { get; set; }
        public virtual DbSet<LanguageLookupTable> LanguageLookupTable { get; set; }
        public virtual DbSet<UserArtsCultureLookUpTable> UserArtsCultureLookUpTable { get; set; }

        public virtual DbSet<UserFoodDrinkLookUpTable> UserFoodDrinkLookUpTable { get; set; }

        public virtual DbSet<ProfessionLookupTable> ProfessionLookupTable { get; set; }
        public virtual DbSet<EthnicityLookupTable> EthnicityLookupTable { get; set; }
        public virtual DbSet<EducationLookupTable> EducationLookupTable { get; set; }
        public virtual DbSet<SectLookupTable> SectLookupTable { get; set; }
        public virtual DbSet<MeritalLookupTable> MeritalLookupTable { get; set; }
        public virtual DbSet<HeightLookupTable> HeightLookupTable { get; set; }
        public virtual DbSet<PrayLookupTable> PrayLookupTable { get; set; }
        public virtual DbSet<UserPictures> UserPictures { get; set; }
        public virtual DbSet<FutureChildrenStatusLookupTable> FutureChildrenStatusLookupTable { get; set; }

    }


}
