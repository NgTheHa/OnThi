namespace eShopManage.Dtos.Common
{
    public class PageResultDto<T>
    {
        public IEnumerable<T> Item { get; set; }
        public int TotalItem { get; set; }
    }
}
