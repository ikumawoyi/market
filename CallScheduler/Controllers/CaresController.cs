using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CallScheduler.Data;
using CallScheduler.Models;

namespace CallScheduler.Controllers
{
	[Route("api/cares")]
	public class CaresController : Controller
	{
		private readonly CallSchedulerDbContext _context;

		public CaresController(CallSchedulerDbContext context)
		{
			_context = context;
		}

		// GET: Cares
		public async Task<IActionResult> Index()
		{
			return View(await _context.Care.ToListAsync());
		}

		// GET: Cares/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var care = await _context.Care
				.FirstOrDefaultAsync(m => m.CareId == id);
			if (care == null)
			{
				return NotFound();
			}

			return View(care);
		}

		// GET: Cares/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Cares/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("CareId,CareCode,FirstName,OtherName,LastName,Name,Phone,DateCreated,DateUpdated,Passport")] Care care)
		{
			if (ModelState.IsValid)
			{
				_context.Add(care);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(care);
		}

		// GET: Cares/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var care = await _context.Care.FindAsync(id);
			if (care == null)
			{
				return NotFound();
			}
			return View(care);
		}

		// POST: Cares/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("CareId,CareCode,FirstName,OtherName,LastName,Name,Phone,DateCreated,DateUpdated,Passport")] Care care)
		{
			if (id != care.CareId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(care);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CareExists(care.CareId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(care);
		}

		// GET: Cares/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var care = await _context.Care
				.FirstOrDefaultAsync(m => m.CareId == id);
			if (care == null)
			{
				return NotFound();
			}

			return View(care);
		}

		// POST: Cares/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var care = await _context.Care.FindAsync(id);
			_context.Care.Remove(care);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool CareExists(int id)
		{
			return _context.Care.Any(e => e.CareId == id);
		}
	}
}
