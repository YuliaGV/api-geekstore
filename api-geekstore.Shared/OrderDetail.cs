using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_geekstore.Shared
{
    [Table("order-details")]
    public class OrderDetail
    {
    
        [Column("order_id")]
        public int OrderId { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }
       
        [Column("quantity")]
        public int Quantity { get; set; }

    }
}
