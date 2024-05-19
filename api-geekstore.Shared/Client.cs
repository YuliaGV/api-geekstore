

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_geekstore.Shared
{
    [Table("clients")]
    public class Client
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("last_name")]
        public string LastName { get; set; }

        [Required]
        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Column("phone_number")]
        [MaxLength(15)]
        public string Phone { get; set; }

        [Required]
        [Column("address")] 
        [MaxLength(100)]
        public string Address { get; set; }
    }
}
