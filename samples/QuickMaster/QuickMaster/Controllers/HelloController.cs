using Microsoft.AspNetCore.Mvc;
using QuickMaster.Models;

namespace QuickMaster.Controllers
{
    public class HelloController : Controller
    {
        private readonly MyContext _context;

        public HelloController(MyContext context)
        {
            this._context = context;
        }

        //[Route("Hoge/Foo")]
        public IActionResult Index()
        {
            return Content("こんにちは、世界！");
        }

        public IActionResult Greet()
        {
            //ViewBag.Message = "こんにちは、世界！";
            ViewBag.Message = "<h1>こんにちは、世界！</h1>";
            return View();
        }

        public IActionResult List()
        {
            return View(this._context.Book);
        }

    }
}