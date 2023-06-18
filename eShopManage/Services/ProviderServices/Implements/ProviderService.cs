using eShopManage.Contexts;
using eShopManage.Dtos.Common;
using eShopManage.Dtos.ProviderDto;
using eShopManage.Services.ProviderServices.Interfaces;

namespace eShopManage.Services.ProviderServices.Implements
{
    public class ProviderService : IProviderService
    {
        private readonly AppDbContext _context;

        public ProviderService(AppDbContext context)
        {
            _context = context;
        }
        public void Create(CreateProviderDto provider)
        {
            var check = _context.Providers.FirstOrDefault(c => c.Name == provider.Name);
            if (check != null)
            {
                throw new Exception("Tên nhà cung cấp đã tồn tại");
            }
            _context.Providers.Add(new Entities.Provider
            {
                Name = provider.Name,
                Address = provider.Address,
                PhoneNumber = provider.PhoneNumber
            });
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var check = _context.Providers.FirstOrDefault(p => p.Id == id);
            if (check != null)
            {
                _context.Providers.Remove(check);
                _context.SaveChanges();
            }
            throw new Exception("Nhà cung cấp không tồn tại!");
        }

        public PageResultDto<ProviderDto> getAll(FilterDto input)
        {
            var query = _context.Providers.AsQueryable();
            query = query.Where(c => (input.Keyword == null || c.Name.ToLower().Contains(input.Keyword))
                                && (input.Keyword == null || c.Address.ToLower().Contains(input.Keyword)))
                         .OrderBy(c => c.Id);
            var totalItem = query.Count();
            var output = query.Skip(input.GetSkip()).Take(input.GetTake());
            var result = output.Select(c => new ProviderDto
            {
                Name = c.Name,
                Address = c.Address,
                PhoneNumber = c.PhoneNumber
            });
            return new PageResultDto<ProviderDto>()
            {
                Item = result,
                TotalItem = totalItem
            };
        }

        public ProviderDto getById(int id)
        {
            var check = _context.Providers.FirstOrDefault(p => p.Id == id);
            if (check != null)
            {
                return new ProviderDto
                {
                    Name = check.Name,
                    Address = check.Address,
                    PhoneNumber = check.PhoneNumber
                };
            }
            throw new Exception("Nhà cung cấp không tồn tại!");
        }

        public void Update(UpdateProviderDto provider)
        {
            var check = _context.Providers.FirstOrDefault(p => p.Id == provider.id);
            if (check != null)
            {
                check.Name = provider.Name;
                check.Address = provider.Address;
                check.PhoneNumber = provider.PhoneNumber;
                _context.SaveChanges();
            }
            throw new Exception("Nhà cung cấp không tồn tại!");
        }
    }
}
