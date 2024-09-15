namespace EtfragApp.PL.Models.Page
{
    public class PageDataVM<T>
    {
        public ICollection<T> Data { get; set; }
        public int? TotalRecords { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
