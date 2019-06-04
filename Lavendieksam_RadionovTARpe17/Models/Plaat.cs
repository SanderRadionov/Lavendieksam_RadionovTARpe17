using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lavendieksam_RadionovTARpe17.Models
{
	public class Plaat
	{
		public int Id { get; set; }
		public string Nimi { get; set; }
		public string Artist { get; set; }
		public string Žanr { get; set; }
		public int Hind { get; set; }
	}
}