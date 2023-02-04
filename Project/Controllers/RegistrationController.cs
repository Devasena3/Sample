using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Models;
using Project.Models;

namespace Project.Controllers
{
  public class RegistrationController : Controller
  {
        private readonly AppDBContext _db;
        public RegistrationController(AppDBContext app1)
        {
            _db = app1;
        }

        public IActionResult Add()
        {
            ViewBag.Id = 0;
            return View("Registration");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View("Registration");
        }
        public IActionResult Index()
        {
            return View("Registration");
        }
        [HttpPost]
        public Response SetDetails(Domain.Models.Registration obj)
        {
            Response ObjReturn = new Response();
            try
            {
                if (obj.Id == 0)
                {
                    obj.DeleteFlag = false;
                    _db.Add(obj);
                    _db.SaveChanges();
                    ObjReturn.Status = "Success";
                    ObjReturn.Message = "Saved Sucessfully";
                    ObjReturn.Result = obj.Id;
                }
                else
                {
                    var result = _db.Registrations.Find(obj.Id);
                    if (result != null)
                    {
                        result.StudentName = obj.StudentName;
                        result.ClassName = obj.ClassName;
                        result.ParentName = obj.ParentName;
                        result.Address = obj.Address;
                        result.ContactNo = obj.ContactNo;
                        result.RollNo = obj.RollNo;

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
                var result = _db.Registrations.Where(D => D.DeleteFlag == false).ToList();
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
                var Result1 = _db.Registrations.Find(Id);
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

                var Result1 = _db.Registrations.Find(id);
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
