using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helmes.Entities
{
    [Table("Sector")]
    public class Sector
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? Pid { get; set; }     
    }
}