﻿using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.DAL.Entities
{
	public class Email
	{
		public int Id { get; set; }
		public string? To{ get; set; }
		public string? Subject{ get; set; }
		public string? Body{ get; set; }
	}
}
