using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Models.Base
{
    public class BaseEntity
    {
        [Key]  
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        [Column("id")]
        public long Id { get; set; }
    }
}