using eTickets.Data.Enums;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        //inject the data 1
        //when we create the service we injected there so we remove injection from here
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            //also change here cause we use service now not _contex from dbcontext
            var data = await _service.GetAll();
            return View(data);
        }
    } 
}
