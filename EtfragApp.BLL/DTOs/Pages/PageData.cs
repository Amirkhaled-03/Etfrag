using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.DTOs.Pages
{
    public class PageData<T>
    {
        public ICollection<T> Data { get; set; }
        public int? TotalRecords { get; set; }

      //  public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);
    }
}
