using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiTO.Models
{
    [Table("payments")]
    public class Payments
    {
        [Key]
        public int PaymentId { get; set; }

        [Required(ErrorMessage = "order_id is required" )]
        [JsonProperty("order_id")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "payment_type is required" ) ]
        [JsonProperty("payment_type")]
        public string PaymentType { get; set; }

        [Required(ErrorMessage = "gross_amount is required" )]
        [JsonProperty("gross_amount")]
        public string Gross_amount { get; set; }

        [Required(ErrorMessage = "transaction_time is required") ]
        [JsonProperty("transaction_time")]
        public string TransactionTime { get; set; }

        [Required(ErrorMessage = "transaction_status is required")]
        [JsonProperty("transaction_status")]
        public string TransactionStatus { get; set; }


        public virtual Orders Order { get; set; }
    }
}
