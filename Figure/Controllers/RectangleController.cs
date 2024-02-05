using Figure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Figure.Controllers
{
    public class RectangleController : Controller
    {
        private readonly IRectangleService _rectangleService;
        public RectangleController(IRectangleService rectangle) 
        {
            _rectangleService = rectangle;
        }

        public IActionResult Index()
        {
            return View(_rectangleService.FindAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Rectangle model)
        {
            if (ModelState.IsValid)
            {
                _rectangleService.Add(model);
                // Poprawne przekazanie id do akcji Result
                return RedirectToAction("Result", new { id = model.Id });
            }
            return View(model);
        }



        [HttpGet]
        public IActionResult Result(int id)
        {
            Console.WriteLine($"id - {id}");
            var rectangle = _rectangleService.FindById(id);
            if (rectangle == null)
            {
                return NotFound();
            }
            return View("Result", rectangle);
        }
    }
}
