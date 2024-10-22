using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VelaAngel_AplicacionWebMVC.Models
{
	public class Equipo
	{
		public int Id { get; set; }

		public required string Nombre  { get; set; }

		public required string Ciudad { get; set; }

		public int Títulos { get; set; }

		public bool AceptaExtranjeros { get; set; }

		public virtual required ICollection<Jugador> Jugadores { get; set; }
	}
}
