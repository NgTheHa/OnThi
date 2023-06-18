using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShopManage.Entities
{
    [Table("Provider")]
    public class Provider
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public List<Shop> Shops { get; set; }
        public List<ShopProvider> ShopProviders { get; set; }
    }
}
