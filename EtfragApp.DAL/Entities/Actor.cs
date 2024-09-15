using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.DAL.Entities
{
	public class Actor : BaseEntity
	{
		public int ActorId { get; set; }

		[Required]
		public string FirstName { get; set; } = "";

		[Required]
		public string LastName { get; set; } = "";

		[Required]
		[Url(ErrorMessage = "Invalid URL format for Profile Picture")]
		public string ProfilePictureUrl { get; set; } = "";

		[Required]
		public string Nationality { get; set; }


		public ICollection<MovieActor> MovieActors { get; set; }
		public ICollection<TVSeriesActor> TvSeriesActors { get; set; }

	}
}
