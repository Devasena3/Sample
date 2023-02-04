using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Models;
using Project.Models;

namespace Project.Controllers
{
  public class MappingController : Controller
  {
        private readonly AppDBContext _db;
        public MappingController(AppDBContext app1)
        {
            _db = app1;
        }

        public IActionResult Add()
        {
            ViewBag.Id = 0;
            return View("Mapping");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View("Mapping");
        }
        public IActionResult Index()
        {
            return View("Mapping");
        }
        [HttpPost]
        public Response SetDetails(ClassFeesRelation fees)
        {
            Response ObjReturn = new Response();
            try
            {
                if (fees.Id == 0)
                {
                    fees.DeleteFlag = false;
                    _db.Add(fees);
                    _db.SaveChanges();
                    ObjReturn.Status = "Success";
                    ObjReturn.Message = "Saved Sucessfully";
                    ObjReturn.Result = fees.Id;
                }
                else
                {
                    var result = _db.ClassFeesRelations.Find(fees.Id);
                    if (result != null)
                    {
                        result.ClassName = fees.ClassName;
                        result.Feescategory = fees.Feescategory;
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
                var result = _db.ClassFeesRelations.Where(D => D.DeleteFlag == false).ToList();
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
        public Response DeleteDetails(int Id)
        {
            Response ObjReturn = new Response();
            try
            {
                var Result1 = _db.ClassFeesRelations.Find(Id);
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
        public Response UpdateDetails(int id)
        {
            Response ObjReturn = new Response();
            try
            {

                var Result1 = _db.ClassFeesRelations.Find(id);
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
