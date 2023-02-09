using MedicalClinic.DAL;
using Microsoft.AspNetCore.Mvc;

namespace MedicalClinic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


    }
}