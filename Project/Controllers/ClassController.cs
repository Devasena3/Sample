using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Models;
using Project.Models;

namespace Project.Controllers
{
  public class ClassController : Controller
  {
    private readonly AppDBContext _db;
    public ClassController(AppDBContext app1)
    {
      _db = app1;
    }
    public IActionResult Add()
    {
      ViewBag.Id = 0;
      return View("Class");
    }
    public IActionResult Edit(int id)
    {
      ViewBag.Id = id;
      return View("Class");
    }
    public IActionResult Index()
    {
      return View("Class");
    }
    [HttpPost]
    public Response SetDetails(Domain.Models.ClassName className)
    {
      Response ObjReturn = new Response();
      try
      {
        if (className.Id == 0)
        {
          className.DeleteFlag =false;
          _db.Add(className);
          _db.SaveChanges();
          ObjReturn.Status = "Success";
          ObjReturn.Message = "Saved Sucessfully";
          ObjReturn.Result = className.Id;
        }
        else
        {
          var result = _db.ClassNames.Find(className.Id);
          if (result != null)
          {
            result.ClassName1 = className.ClassName1;
            _db.Entry(result).State = EntityState.Modified;
            _db.SaveChanges();
            ObjReturn.Status = "Success";
            ObjReturn.Message = "Modified Sucessfully";
            ObjReturn.Result = null;

          }
        }
      }
      catch (Exception ex)
      {
        ObjReturn.Status = "Failure";
        ObjReturn.Message = ex.Message;
        ObjReturn.Result = null;

      }
      return ObjReturn;
    }
    [HttpGet]
    public Response GetDetails()
    {
      Response ObjReturn = new Response();
      try
      {
        var result = _db.ClassNames.Where(D => D.DeleteFlag == false).ToList();
        ObjReturn.Status = "Success";
        ObjReturn.Message = "Collected Successfully";
        ObjReturn.Result = result;
      }
      catch (Exception ex)
      {
        ObjReturn.Status = "Failure";
        ObjReturn.Message = ex.Message;
        ObjReturn.Result = null;
      }
      return ObjReturn;
    }
    [HttpPost]
    public Response DeleteDetails(int UserId)
    {
      Response ObjReturn = new Response();
      try
      {
        var Result1 = _db.ClassNames.Find(UserId);
        if (Result1 != null)
        {
          Result1.DeleteFlag = true;
          _db.Entry(Result1).State = EntityState.Modified;
          _db.SaveChanges();
          ObjReturn.Status = "Success";
          ObjReturn.Message = " Detail Deleted successfully";
          ObjReturn.Result = Result1;
        }


      }
      catch (Exception ex)
      {
        ObjReturn.Status = "Failure";
        ObjReturn.Message = ex.Message;
        ObjReturn.Result = null;
      }
      return ObjReturn;
    }
    [HttpPost]
    public Response UpdateDetails(int UserId)
    {
      Response ObjReturn = new Response();
      try
      {

        var Result1 = _db.ClassNames.Find(UserId);
        ObjReturn.Status = "Success";
        ObjReturn.Message = "Detail collected Successfully";
        ObjReturn.Result = Result1;

      }
      catch (Exception ex)
      {
        ObjReturn.Status = "Failure";
        ObjReturn.Message = ex.Message;
        ObjReturn.Result = null;
      }
      return ObjReturn;
    }
  }
}
