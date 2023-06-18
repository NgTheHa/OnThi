using System.ComponentModel.DataAnnotations;

namespace eShopManage.Dtos.ShopDtos
{
    public class CreateShopDto
    {
        [Required]
        [StringLength(500)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
