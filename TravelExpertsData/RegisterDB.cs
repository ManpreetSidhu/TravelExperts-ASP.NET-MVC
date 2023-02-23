using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public static  class RegisterDB
    {
        // function to register user to the the database.
        // created by Aaron
        public static void registerCustomer(string firstname, string lastname, string address, string city, string prov, string postal, string? country, string? homephone, string busphone, string email, string? user, string? password)
        {
            Customer cust = new Customer();
            cust.CustFirstName = firstname;
            cust.CustLastName = lastname;
            cust.CustAddress = address;
            cust.CustCity = city;
            cust.CustProv = prov;
            cust.CustPostal = postal;
            cust.CustCountry = country;
            cust.CustHomePhone = homephone;
            cust.CustBusPhone = busphone;
            cust.CustEmail = email;
            cust.Username = user;
            cust.Password = password;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                // add data o the database
                db.Customers.Add(cust);
                // save the changes
                db.SaveChanges();
            }
        }
        
        // get the details of customer by ID
        // created by Manpreet 
        public static Customer GetDetails(int? id)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                Customer cust = db.Customers.Find(id);
                return cust;
            }
        }

        // function to the update the customer data 
        // created by Manpreet
        public static void UpdateDetails(Customer customer, int cust_id)
        {
            // create a objcet of customer class and pass the values
            Customer cust = new Customer();
            cust.CustomerId = cust_id;
            cust.CustFirstName = customer.CustFirstName;
            cust.CustLastName = customer.CustLastName;
            cust.CustAddress = customer.CustAddress;
            cust.CustCity = customer.CustCity;
            cust.CustCountry = customer.CustCountry;
            cust.CustProv = customer.CustProv;
            cust.CustPostal = customer.CustPostal;
            cust.CustHomePhone = customer.CustHomePhone;
            cust.CustBusPhone  = customer.CustBusPhone;
            cust.CustEmail = customer.CustEmail;
            cust.Username  = customer.Username;
            cust.Password = customer.Password;
            cust.AgentId = customer.AgentId;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                // update the data
                db.Customers.Update(cust);
                // save the changes    
                db.SaveChanges();
                
            }
        }

        // code by Aaron Reid to check if username exist
        public static bool IsUsernameValid(string username)
        {
            using (var context = new TravelExpertsContext())
            {
                //check if any customer already has the username
                var customerWithUsername = context.Customers
                    .Where(cust => cust.Username == username).ToList();

                //if no customers have the username, its valid
                if (customerWithUsername.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
