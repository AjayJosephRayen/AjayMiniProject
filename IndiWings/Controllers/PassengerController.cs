using IndiWings.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace IndiWings.Controllers
{
    public class PassengerController : Controller
    {
        private readonly IndiWingsContext db;
        private readonly ISession session;
        

        public PassengerController(IndiWingsContext _db, IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Login(Loginpage l)
        {
            
            var result = (from i in db.Registrations
                          where i.Username == l.Username && i.Password == l.Password
                          select i).SingleOrDefault();
            if (result != null)
            {
                HttpContext.Session.SetString("name",l.Username);
                HttpContext.Session.SetInt32("id",result.Pid);
                return RedirectToAction("FlightDetails");
            }
            else
            {

                return View("Login");
            }

        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Registration r)
        {
            db.Registrations.Add(r);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        public IActionResult FlightDetails()
        {
            if (HttpContext.Session.GetString("name") != null)
            {
                ViewBag.Name = HttpContext.Session.GetString("name");   
                return View(db.Airlines.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Passenger");
            }
        }
        [HttpGet]
        public IActionResult Book(string FlightNumber)
        {
            Booking book= new Booking();
            book.FlightNumber = Convert.ToInt32(FlightNumber);
            return View(book);//create
        }
        //[HttpGet]
        //public IActionResult Payment(int id)
        //{
        //    //Payment p = db.Payments.Find(id);
        //    //var temp = db.Payments.ToList();
        //    var payment = (from p in db.Airlines
        //                   where p.Flightid == id
        //                   select p).SingleOrDefault();

        //    return View(payment);
        //    //Payment pay = db.Payments.Find(id);
        //    //return View(pay);

        //}

        //[HttpPost]
        //public IActionResult Payment(Payment p)
        //{
        //    //db.Payments.Add(p);
        //    //db.SaveChanges();
        //    return RedirectToAction("Passengerchart");
        //}

        [HttpGet]
        public IActionResult Payment(int id)
        {
            //Payment p = db.Payments.Find(id);
            //var temp = db.Payments.ToList();
            var payment = (from p in db.Airlines
                           where p.Flightid == id
                           select p).SingleOrDefault();

            return View(payment);
            //Payment pay = db.Payments.Find(id);
            //return View(pay);

        }

        [HttpPost]
        public IActionResult Payment(Payment p)
        {
            //db.Payments.Add(p);
            //db.SaveChanges();
            return RedirectToAction("PaymentProcess","passenger");
        }
        [HttpGet]
        public IActionResult PaymentProcess()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Paymentprocess()
        {
           return RedirectToAction("Pay", "Passenger");
        }

        public IActionResult Pay()
        {
            ViewBag.Name = HttpContext.Session.GetString("name");
            return View();
        }
        //[HttpPost]
        //public IActionResult pay()
        //{
        //    return RedirectToAction();
        //}

        public IActionResult Allpassengers()
        {
            return View(db.Passengercharts.ToList());
        }
        //public IActionResult Logout()
        //{
        //    HttpContext.Session.Clear();
        //    return RedirectToAction("Index");
        //}
        //public IActionResult Delete(int id)
        //{

        //    Airline e = db.Airlines.Find(id);
        //    return 
        //        View(e);
            
        //}
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    Airline e=db.Airlines.Find(id);
        //    db.Airlines.Remove(e);
        //    db.SaveChanges();
        //    return RedirectToAction("FlightDetails");
        //}
        public IActionResult About()
        { 
            return View();
        }
        public IActionResult Privacy()
        {
            return View("Privacy","Passenger");
        }
        //public IActionResult Payer(Registration l)
        //{
        //    HttpContext.Session.SetString("name",l.Username);
        //    ViewBag.Name = HttpContext.Session.GetString("name");
        //    return View(db.Registrations.ToList());
        //}

    }

}



