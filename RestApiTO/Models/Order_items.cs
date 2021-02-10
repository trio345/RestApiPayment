using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiTO.Models
{
    [Table("order_items")]
    public class Order_items
    {
        [Key]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "order_id is required")]
        public int OrderId { get; set; }
        
        [Required(ErrorMessage = "product_id is required")]
        public int ProductId { get; set; }
        
        [Required(ErrorMessage = "quantity is required") ]
        public int Quantity { get; set; }

        public virtual Orders Order { get; set; }

        [ForeignKey("ProductId")]
        public virtual Products Product { get; set; }
    }
}
