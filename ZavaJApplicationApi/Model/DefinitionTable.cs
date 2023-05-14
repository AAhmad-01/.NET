using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZavaJApplicationApi.Model
{

    [Table("ProfessionDefinitionTable")]
    public class ProfessionList
    {
        [Key]
        public int Id { get; set; }

        public int Name { get; set; }
    }

    [Table("EthniCityDefinitionTable")]
    public class EthniCityList
    {
        [Key]
        public int Id { get; set; }

        public int Name { get; set; }
    }

    [Table("EducationDefinitionTable")]
    public class EducationList
    {
        [Key]
        public int Id { get; set; }

        public int Name { get; set; }
    }

    [Table("SectDefinitionTable")]
    public class SectList
    {
        [Key]
        public int Id { get; set; }

        public int Name { get; set; }
    }
    [Table("MeritalStatusDefinitionTable")]
    public class MeritalStatusList
    {
        [Key]
        public int Id { get; set; }

        public int Name { get; set; }
    }
    [Table("HeightDefinitionTable")]
    public class HeightList
    {
        [Key]
        public int Id { get; set; }

        public int Name { get; set; }
    }

    [Table("PrayDefinitionTable")]
    public class PrayList
    {
        [Key]
        public int Id { get; set; }

        public int Name { get; set; }
    }
    [Table("FutureChildrenDefinition")]
    public class FutureChildrenList
    {
        [Key]
        public int Id { get; set; }

        public int Name { get; set; }
    }

}
