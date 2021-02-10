using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiTO.Models
{
    [Table("orders")]
    public class Orders
    {
        public Orders()
        {
            OrderItem = new HashSet<Order_items>();
        }

        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "user_id is required")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "order_status is required")]
        public string OrderStatus { get; set; }

        public virtual Customers Customer { get; set; }

        public virtual Payments Payment { get; set; }

        public virtual ICollection<Order_items> OrderItem { get; set; }
    }
}
