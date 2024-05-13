using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;
        }

        // GET: Cinemas
        public async Task<IActionResult> Index()
        {
            var cinemas = await _service.GetAllAsync();
            return View(cinemas);
        }

        // GET: Cinemas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var cinema = await _service.GetByIdAsync(id);
            if (cinema == null)
            {
                return View("NotFound");
            }
            return View(cinema);
        }

        // GET: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cinemas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Location")] Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(cinema);
                return RedirectToAction(nameof(Index));
            }
            return View(cinema);
        }

        // GET: Cinemas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _service.GetByIdAsync(id);
            if (cinema == null)
            {
                return View("NotFound");
            }
            return View(cinema);
        }

        // POST: Cinemas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Location")] Cinema cinema)
        {
            if (id != cinema.Id)
            {
                return View("NotFound");
            }

            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, cinema);
                return RedirectToAction(nameof(Index));
            }
            return View(cinema);
        }

        // GET: Cinemas/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await _service.GetByIdAsync(id);
            if (cinema == null)
            {
                return View("NotFound");
            }
            return View(cinema);
        }

        // POST: Cinemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
