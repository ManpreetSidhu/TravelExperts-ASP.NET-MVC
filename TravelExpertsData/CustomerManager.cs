using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class CustomerManager
    {
        public static Customer Authenticate(string username, string password)
        {
            TravelExpertsContext db = new TravelExpertsContext();

            var customer = db.Customers.SingleOrDefault(cust => cust.Username == username
                                                        && cust.Password == password);
            return customer; //this will either be null or an object
        }
    }
}
