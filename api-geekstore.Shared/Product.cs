using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_geekstore.Shared
{
    [Table("products")]
    public class Product
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [MaxLength(50)]
        [Column("name")]
        public string Name { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [ForeignKey("ProductCategory")]
        [Column("category_id")]
        public int ProductCategoryId { get; set; }

        [NotMapped]
        public ProductCategory ProductCategory { get; set; }  

        public List<OrderDetail> OrderDetails { get; set; }

    }
}
