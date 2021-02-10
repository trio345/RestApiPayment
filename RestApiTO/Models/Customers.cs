using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiTO.Models
{
    [Table("customers")]
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "full_name is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "phone_number is required")]
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        public virtual Orders Orders { get; set; }

    }
}
