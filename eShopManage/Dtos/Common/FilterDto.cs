using Microsoft.AspNetCore.Mvc;

namespace eShopManage.Dtos.Common
{
    public class FilterDto
    {
        [FromQuery(Name = "pageSize")]
        public int PageSize { get; set; }
        [FromQuery(Name = "pageIndex")]
        public int PageIndex { get; set; }
        private string _keyword;
        [FromQuery(Name = "keyword")]
        public string Keyword
        {
            get { return _keyword; }
            set
            {
                _keyword = value?.Trim();
            }
        }
        public int GetSkip()
        {
            return (PageIndex - 1) * PageSize;
        }
        public int GetTake()
        {
            return PageSize;
        }
    }
}
