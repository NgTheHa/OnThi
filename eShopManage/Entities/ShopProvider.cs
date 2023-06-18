using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShopManage.Entities
{
    [Table("ShopProvider")]
    public class ShopProvider
    {
        [Key]
        public int Id { get; set; }
        public int IdShop { get; set; }
        public Shop Shop { get; set; }
        public int IdProvider { get; set; }
        public Provider Provider { get; set; }
        [Range(0, 100)]
        public double FriendlyPoint { get; set; }
    }
}
