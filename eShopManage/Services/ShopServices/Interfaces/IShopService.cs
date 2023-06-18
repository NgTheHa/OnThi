using eShopManage.Dtos.Common;
using eShopManage.Dtos.ShopDtos;

namespace eShopManage.Services.ShopServices.Interfaces
{
    public interface IShopService
    {
        public PageResultDto<ShopDto> getWithPaging(FilterDto input);
        public void CreateShop(CreateShopDto input);
        public ShopDto GetById(int id);
        public void UpdateShop(UpdateShopDto input);
        public void DeleteShop(int id);
        public IQueryable getWithPoint(int id);
    }
}
