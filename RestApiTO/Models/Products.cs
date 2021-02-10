using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiTO.Models
{
    [Table("products")]
    public class Products
    {
        public Products()
        {
            Order_item = new HashSet<Order_items>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        [ForeignKey("Id")]
        public ICollection<Order_items> Order_item { get; set; }
    }
}
