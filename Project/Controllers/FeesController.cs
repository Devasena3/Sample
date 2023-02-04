using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
  public class FeesController : Controller
  {
    // GET: FeesController
    public ActionResult Index()
    {
      return View();
    }

    // GET: FeesController/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: FeesController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: FeesController/Create
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

    // GET: FeesController/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: FeesController/Edit/5
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

    // GET: FeesController/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: FeesController/Delete/5
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
