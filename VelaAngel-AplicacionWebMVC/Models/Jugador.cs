using System.ComponentModel.DataAnnotations;

namespace VelaAngel_AplicacionWebMVC.Models
{
	public class Jugador
	{
		public int Id { get; set; }

		public required string Nombre { get; set; }

		public required string Posición { get; set; }

		public int Edad { get; set; }

		// Relación con el Equipo
		public int EquipoId { get; set; }
		public virtual required Equipo Equipo { get; set; }
	}
}
