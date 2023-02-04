using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
  public class ClassController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
