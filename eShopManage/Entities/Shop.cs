using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShopManage.Entities
{
    [Table("Shop")]
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public List<Provider> Provider { get; set; }
        public List<ShopProvider> ShopProviders { get; set; }

    }
}
