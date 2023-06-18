using System.ComponentModel.DataAnnotations;

namespace eShopManage.Dtos.ProviderDto
{
    public class CreateProviderDto
    {
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
