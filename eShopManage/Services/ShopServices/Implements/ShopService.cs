using eShopManage.Contexts;
using eShopManage.Dtos.Common;
using eShopManage.Dtos.ShopDtos;
using eShopManage.Entities;
using eShopManage.Services.ShopServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eShopManage.Services.ShopServices.Implements
{
    public class ShopService : IShopService
    {
        private readonly AppDbContext _context;
        public ShopService(AppDbContext context)
        {
            _context = context;
        }
        public PageResultDto<ShopDto> getWithPaging(FilterDto input)
        {
            var query = _context.Shops.AsQueryable();
            query = query.Where(s => (input.Keyword == null || s.Name.ToLower().Contains(input.Keyword))
                                     && (input.Keyword == null || s.Address.ToLower().Contains(input.Keyword)))
                         .OrderBy(c => c.Id);
            var totalItem = query.Count();
            var result = query.Skip(input.GetSkip())
                .Take(input.GetTake());
            var newResult = result.Select(p => new ShopDto
            {
                Name = p.Name,
                Address = p.Address,
                PhoneNumber = p.PhoneNumber,
            });
            return new PageResultDto<ShopDto>()
            {
                Item = newResult,
                TotalItem = totalItem
            };
        }
        public void CreateShop(CreateShopDto input)
        {
            var check = _context.Shops.FirstOrDefault(c => c.Name == input.Name);
            if (check != null)
            {
                var query = _context.Shops.Add(new Shop
                {
                    Name = input.Name,
                    Address = input.Address,
                    PhoneNumber = input.PhoneNumber
                });
                _context.SaveChanges();
            }
            throw new Exception("Tên Shop đã tồn tại");
        }
        public ShopDto GetById(int id)
        {
            var result = _context.Shops.FirstOrDefault(s => s.Id == id);
            if (result is null)
            {
                throw new Exception("Shop không tồn tại!");
            }
            return new ShopDto { Name = result.Name, Address = result.Address, PhoneNumber = result.PhoneNumber };

        }

        public void UpdateShop(UpdateShopDto input)
        {
            var result = _context.Shops.FirstOrDefault(s => s.Id == input.id);
            if (result is null)
            {
                throw new Exception("Shop không tồn tại!");
            }
            result.Name = input.Name;
            result.Address = input.Address;
            result.PhoneNumber = input.PhoneNumber;
            _context.SaveChanges();
        }

        public void DeleteShop(int id)
        {
            var result = _context.Shops.FirstOrDefault(s => s.Id == id);
            if (result is null)
            {
                throw new Exception("Shop không tồn tại!");
            }
            _context.Shops.Remove(result);
            _context.SaveChanges();
        }
        public IQueryable getWithPoint(int id)
        {
            var query = (from sp in _context.ShopProviders
                             //join s in _context.Shops on sp.IdShop equals s.Id
                         where sp.IdShop == id
                         //join p in _context.Providers on sp.IdProvider equals p.Id
                         select new
                         {
                             Name = sp.Provider.Name,
                             PhoneNumber = sp.Provider.PhoneNumber,
                             Point = sp.FriendlyPoint
                         }).OrderByDescending(sp => sp.Point);
            var result = _context.ShopProviders.Include(sp => sp.Provider)
                                               .Where(p => p.IdShop == id)
                                               .OrderByDescending(c => c.FriendlyPoint)
                                               .Select(p => new
                                               {
                                                   Name = p.Provider.Name,
                                                   Address = p.Provider.Address,
                                                   Point = p.FriendlyPoint
                                               });
            return result;
        }
    }
}
