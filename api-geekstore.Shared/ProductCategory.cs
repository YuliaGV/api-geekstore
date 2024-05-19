using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_geekstore.Shared
{
    [Table("product_categories")]
    public class ProductCategory
    {
       
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]

        [MaxLength(50)]
        [Column("category_name")]
        public string Name { get; set; }

        public List<Product> ProductList { get; set; }

    }
}
