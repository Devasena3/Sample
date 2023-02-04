using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
  public class MappingController : Controller
  {
    // GET: MappingController
    public ActionResult Index()
    {
      return View();
    }

    // GET: MappingController/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: MappingController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: MappingController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: MappingController/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: MappingController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: MappingController/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: MappingController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }
  }
}
