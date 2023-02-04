using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Models;
using Project.Models;

namespace Project.Controllers
{
    public class PaymentController : Controller
    {
        private readonly AppDBContext _db;
        public PaymentController(AppDBContext app1)
        {
            _db = app1;
        }

        public IActionResult Add()
        {
            ViewBag.Id = 0;
            return View("Payment");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View("Payment");
        }
        public IActionResult Index()
        {
            return View("Payment");
        }
        [HttpPost]
        public Response SetDetails(Domain.Models.Payment fees)
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
                    var result = _db.Payments.Find(fees.Id);
                    if (result != null)
                    {
                        result.StudentName = fees.StudentName;
                        result.FeesCategory = fees.FeesCategory;
                        result.PaymentStaus = fees.PaymentStaus;
                        result.ClassName = fees.ClassName;
                        result.RollNo = fees.RollNo;
                        result.FeesAmount = fees.FeesAmount;

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
                var result = _db.Payments.Where(D => D.DeleteFlag == false).ToList();
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
                var Result1 = _db.Payments.Find(Id);
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

                var Result1 = _db.Payments.Find(id);
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
