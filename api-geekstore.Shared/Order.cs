
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_geekstore.Shared
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("order_number")]
        public int OrderNumber { get; set; }

        [Column ("client_id")]
        public int ClientId { get; set; }

        [Column("order_date")]
        public DateTime OrderDate { get; set; }

        [Column("delivery_date")]
        public DateTime DeliveryDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
