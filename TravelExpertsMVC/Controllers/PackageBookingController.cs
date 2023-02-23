using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TravelExpertsData;

namespace TravelExpertsMVC.Controllers
{
    
    public class PackageBookingController : Controller
    {
        // GET: PackageBookingController
        // code by Manpreet Sidhu
        // display the list of packages
        public ActionResult Packages()
        {
            // call the function Get package
            List<Package> package = PackageBookingDB.GetPackages();
            // add the list to the view
            return View(package);
        }
    
        // code by Manpreet Sidhu 
        // when user click on Book get the package by id
        public ActionResult Book(int id)
        {
            // assign packageid 
            int packageid = id;
            // call the method to get data of selected package
           List<Package> packages = PackageBookingDB.GetPackagebyId(id);
            return View(packages);
        }
        // code by Manpreet Sidhu 
        
        [Authorize]
        public ActionResult Add(int id,string name)
        {
           //in the list add the trips by name 
           List<TripType> trips = PackageBookingDB.GetTrips().ToList();
            ViewBag.TripType = new SelectList(trips,"TripTypeId", "Ttname").ToList();
            // assign the value to the viewbag
            ViewBag.PkgName = name;
            // assign the value to the tempdata
            TempData["PackageId"] = id;
            ViewBag.Packageid = id;
            // get the booking date
            ViewBag.Bookingdate= DateTime.Now.ToString();
            // return to view
            return View();
        }

        // code by Manpreet Sidhu 
        [Authorize]
        [HttpPost]
        public ActionResult Add(Booking booking,string id)
        {
            // get the list of trip types in a dropdown list 
            List<TripType> trips = PackageBookingDB.GetTrips().ToList();
           var list = new SelectList(trips, "TripTypeId", "Ttname").ToList();
            foreach (var item in list)
            {
                if (item.Value == id)
                {
                    item.Selected = true;
                    break;
                }
            }
            // assign the values to the variables
            int? packageid = (int)@TempData["PackageId"];
            int? customer_id = HttpContext.Session.GetInt32("CurrentCustomer");
            DateTime? bookingdate = DateTime.Now;
            float? travelcount = (float)booking.TravelerCount;
            string? triptype = id;
            // if customerid is not null
            if(customer_id !=null)
            {
                try
                {
                    // call method to book a  package
                    PackageBookingDB.AddBooking(packageid, bookingdate, travelcount, customer_id, triptype);
                    TempData["Message"] = "Data Added sucessfully";
                    // return to Package View
                    return RedirectToAction("Packages");
                }
                catch (Exception ex)
                {
                    // error message with exception if data fail to add
                    TempData["Message"] = "Failed to Insert:" + ex.Message + ex.GetType();
                    return RedirectToAction("Packages");
                }
                // redirect to the Main Page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // if user not logged in or customerid is null return to login page
                TempData["Messagelogin"] = "Please login again to book a package.";
                return RedirectToAction("Logout", "Account");
            }
        }











        // GET: PackageBookingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PackageBookingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PackageBookingController/Create
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

        // GET: PackageBookingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PackageBookingController/Edit/5
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

        // GET: PackageBookingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PackageBookingController/Delete/5
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
