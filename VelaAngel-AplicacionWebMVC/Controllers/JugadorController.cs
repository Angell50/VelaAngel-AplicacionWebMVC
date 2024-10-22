using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VelaAngel_AplicacionWebMVC.Data;
using VelaAngel_AplicacionWebMVC.Models;

namespace VelaAngel_AplicacionWebMVC.Controllers
{
	public class JugadorController : Controller
	{
		private readonly Data.AppDbContext _context;

		public JugadorController(Data.AppDbContext context)
		{
			_context = context;
		}

        // Listar Jugadores con Filtro por Equipo
        public async Task<IActionResult> Index(int? equipoId)
        {
            var jugadores = _context.Jugadores.Include(j => j.Equipo).AsQueryable();

            if (equipoId.HasValue)
            {
                jugadores = jugadores.Where(j => j.EquipoId == equipoId);
            }

            try
            {
                ViewBag.Equipos = await _context.Equipos.ToListAsync();
            }
            catch (Exception ex)
            {
                // Maneja la excepción como desees, tal vez registrar el error
                ViewBag.ErrorMessage = "No se pudo cargar la lista de equipos.";
            }

            return View(await jugadores.ToListAsync());
        }

        // Crear Jugador (GET)
        public IActionResult Create()
		{
			ViewBag.Equipos = _context.Equipos.ToList();
			return View();
		}

		// Crear Jugador (POST)
		[HttpPost]
		public async Task<IActionResult> Create(Jugador jugador)
		{
			if (ModelState.IsValid)
			{
				_context.Add(jugador);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewBag.Equipos = _context.Equipos.ToList();
			return View(jugador);
		}

		// Editar Jugador
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null) return NotFound();

			var jugador = await _context.Jugadores.FindAsync(id);
			if (jugador == null) return NotFound();

			ViewBag.Equipos = _context.Equipos.ToList();
			return View(jugador);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, Jugador jugador)
		{
			if (id != jugador.Id) return NotFound();

			if (ModelState.IsValid)
			{
				_context.Update(jugador);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewBag.Equipos = _context.Equipos.ToList();
			return View(jugador);
		}

		// Eliminar Jugador
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null) return NotFound();

			var jugador = await _context.Jugadores.FindAsync(id);
			if (jugador == null) return NotFound();

			_context.Jugadores.Remove(jugador);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}
