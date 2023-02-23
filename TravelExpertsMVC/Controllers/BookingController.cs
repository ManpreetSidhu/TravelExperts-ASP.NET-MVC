using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelExpertsData;


// Manpreet Sidhu and Meet Kamal Grewal 
namespace TravelExpertsMVC.Controllers
{
    public class BookingController : Controller
    {


        // code by Meet Kamal Grewal to get a list of booking 
        public IActionResult Bookings()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            // get a customer id
            int? currentCustomerId = HttpContext.Session.GetInt32("CurrentCustomer");
            // if customerid is not null
            if (currentCustomerId != null)
            {// call the function to get the booking
                List<Booking> bookings = PackageBookingDB.GetBookings(currentCustomerId);
                // call the function to get a total cost owing
                decimal price = PackageBookingDB.GetTotalCost(currentCustomerId);
                // assign value to viewbag
                ViewBag.Price = price.ToString("C");
                return View(bookings);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Request.Path });
            }
          
        }


        // GET: BookingController/Delete/ by id
        // code by Manpreet sidhu 
        public ActionResult Delete(int id)
        {// to delete the booking 
            try
            {
                // assign booking id and call the function DeleteBooking
                int booking_id = id;
                PackageBookingDB.DeleteBooking(booking_id);
                TempData["Message"] = "Deleted succesfully ";
            }
            // if error occur
            catch (Exception ex)
            {
                TempData["Message"] = "Booking Not Deleted" + ex.Message + ex.GetType().ToString();
            }
            // return to the booking page
            return RedirectToAction("Bookings", "Booking");
       }

        // get thr profile of loggedin user
        // code by Manpreet Sidhu 
        public ActionResult MyProfile()
        {
            // get the customer id from session
            int? customer_id = HttpContext.Session.GetInt32("CurrentCustomer");
            // if customerid is not null
            if (customer_id != null)
            {
                // call the function to get details by id 
                Customer cust = RegisterDB.GetDetails(customer_id);
                //pass to the view
                return View(cust);
            }
            else
            { // return to login page
                return RedirectToAction("Logout", "Account");
            }

        }


        // GET: BookingController/Edit
        // code by Manpreet Sidhu 
        public ActionResult Edit(int id)
        {
            // get the customer id from session
            int customer_id = (int)HttpContext.Session.GetInt32("CurrentCustomer");
            // call the function to get details 
            Customer cust = RegisterDB.GetDetails(customer_id);
            return View(cust);
        }






        // POST: BookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                int cust_id = id;
                RegisterDB.UpdateDetails(customer, cust_id);

                return RedirectToAction("MyProfile");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BookingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingController/Create
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

      







        // POST: BookingController/Delete/5
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
