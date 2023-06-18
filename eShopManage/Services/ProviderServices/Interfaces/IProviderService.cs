using eShopManage.Dtos.Common;
using eShopManage.Dtos.ProviderDto;

namespace eShopManage.Services.ProviderServices.Interfaces
{
    public interface IProviderService
    {
        public PageResultDto<ProviderDto> getAll(FilterDto input);
        public ProviderDto getById(int id);
        public void Create(CreateProviderDto provider);
        public void Update(UpdateProviderDto provider);
        public void Delete(int id);
    }
}
