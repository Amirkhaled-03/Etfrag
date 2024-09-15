using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.DAL.Entities
{
    public class BaseEntity
    {
        public DateTime AddedAt { get; set; } = DateTime.Now;
    }
}

