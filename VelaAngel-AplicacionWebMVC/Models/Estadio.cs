using System.ComponentModel.DataAnnotations;

namespace VelaAngel_AplicacionWebMVC.Models
{
	public class Estadio
	{
		public int Id { get; set; }

		public required string Direccion { get; set; }

		public required string Ciudad { get; set; }

		public int Capacidad { get; set; }
	}
}
