using eTickets.Data.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {

        //inject the appdbcontext
        private readonly AppDbContext _context;

        public ProducersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers =await _context.Producers.ToListAsync();
            return View(allProducers);
        }
    }
}
