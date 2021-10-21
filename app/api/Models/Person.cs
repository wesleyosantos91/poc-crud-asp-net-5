using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using app.Models.Base;

namespace app.Models
{
    [Table("person", Schema = "dev")]

    public class Person : BaseEntity
    {
        [Required]
        [Column("first_name")]
        public string FirstName { get; set; }
        
        [Required]
        [Column("last_name")]
        public string LastName { get; set; }
        
        [Required]
        [Column("address")]
        public string Address { get; set; }
        
        [Required]
        [Column("gender")]
        public string Gender { get; set; }
    }
}