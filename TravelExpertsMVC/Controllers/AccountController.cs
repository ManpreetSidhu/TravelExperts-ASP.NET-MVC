using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TravelExpertsData;

namespace TravelExpertsMVC.Controllers
{
    public class AccountController : Controller
    {
        // code by Micah Brown
        public IActionResult Login(string returnUrl = "")
        {
            if (returnUrl != null)
            {
                TempData["ReturnUrl"] = returnUrl;
            }
            return View();
        }

        // function to Authenticate User
        // code by Micah Brown 
        [HttpPost]
        public async Task<IActionResult> LoginAsync(Customer customer) // customer comes from login form
        {
            TravelExpertsContext db = new TravelExpertsContext();
            Customer cust = CustomerManager.Authenticate(customer.Username, customer.Password);
            if (cust == null) //authentication failed
            {
                return View(); //stay on login page
            }
            //cust is not null - customer is authenticated

            //if the customer has slips, add customerid to session state

            HttpContext.Session.SetInt32("CurrentCustomer", cust.CustomerId);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, cust.Username),
                new Claim("FullName", cust.CustFirstName + " " + cust.CustLastName),
                new Claim("Password", cust.Password)
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme); //"Cookies"
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            //get authentication ticket
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            if (string.IsNullOrEmpty(TempData["ReturnUrl"].ToString()))
            {
                return RedirectToAction("Index", "Home"); //by default go to the main page
            }
            else
            {
                return Redirect(TempData["ReturnUrl"].ToString());
            }
        }

        // function for logout button 
        // code by Micah Brown
        public async Task<IActionResult> LogoutAsync()
        {
            // return the authentication ticket
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("CurrentCustomer");
            return RedirectToAction("Index", "Home"); //go to the main page after logout
        }

        // registerationcode
        // code by Aaron Reid
        public ActionResult Registeration()
        {
            return View();
        }

        //// Post method to Register 
        // code by Aaron Reid
        [HttpPost]
        public ActionResult Registeration(Customer customer)
        {
            string firstname = customer.CustFirstName;
            string lastname = customer.CustLastName;
            string Address = customer.CustAddress;
            string City = customer.CustCity;
            string prov = customer.CustProv;
            string postal = customer.CustPostal;
            string? country = customer.CustCountry;
            string? homephone = customer.CustHomePhone;
            string busphone = customer.CustBusPhone;
            string email = customer.CustEmail;
            string? user = customer.Username;
            string? password = customer.Password;
            try
            {
                // call method to verify if username exist or no 
                bool isUsernameValid = RegisterDB.IsUsernameValid(user);
                // if not exist 
                if (isUsernameValid)
                {
                    // call method to register customer
                    RegisterDB.registerCustomer(firstname, lastname, Address, City, prov, postal, country, homephone, busphone, email, user, password);
                    return View("login");

                }
                else
                {
                    // Username is not valid, add error message to model state...
                    ModelState.AddModelError("Username", "The username already exists.");
                }

            }
            catch (Exception ex)
            {
                // if in case Data not added sucessfully 
                TempData["message"] = "insert failed:" + ex.Message+ex.GetType();
                return View();
            }
            return View();
        }
    }
}
