using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VelaAngel_AplicacionWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using VelaAngel_AplicacionWebMVC.Data;


namespace VelaAngel_AplicacionWebMVC.Controllers
{
	public class EquipoController : Controller
	{
		private readonly Data.AppDbContext _context;

		public EquipoController(Data.AppDbContext context)
		{
			_context = context;
		}

		// Listar Equipos
		public async Task<IActionResult> Index()
		{
			return View(await _context.Equipos.ToListAsync());
		}

		// Crear Equipo (GET)
		public IActionResult Create()
		{
			return View();
		}

		// Crear Equipo (POST)
		[HttpPost]
		public async Task<IActionResult> Create(Equipo equipo)
		{
			if (ModelState.IsValid)
			{
				_context.Add(equipo);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(equipo);
		}

		// Editar Equipo
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null) return NotFound();

			var equipo = await _context.Equipos.FindAsync(id);
			if (equipo == null) return NotFound();

			return View(equipo);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, Equipo equipo)
		{
			if (id != equipo.Id) return NotFound();

			if (ModelState.IsValid)
			{
				_context.Update(equipo);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(equipo);
		}

		// Eliminar Equipo
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null) return NotFound();

			var equipo = await _context.Equipos.FindAsync(id);
			if (equipo == null) return NotFound();

			_context.Equipos.Remove(equipo);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}
