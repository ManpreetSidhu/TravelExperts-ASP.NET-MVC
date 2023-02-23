using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    // data access for pakages and bookings.
    public static class PackageBookingDB
    {
        // get the details of Travel Packages (by Manpreet)
        public static List<Package> GetPackages()
        {
          
                using (TravelExpertsContext db = new TravelExpertsContext())
                // in a list add the data from packages where pkgstart date is greater than today 
                {
                    List<Package> packages = db.Packages.Where(p => p.PkgStartDate > DateTime.Now).ToList();
                    // return the list
                    return packages;
                }
                   
        }
        // get a package by particular id (by Manpreet)
        // pass the packageid 
        public static List<Package> GetPackagebyId(int id)
        {  
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                List<Package> packages = db.Packages.Where(p=> p.PackageId == id).ToList();
                // return the list 
                return packages;
            }
        }
        // function to get the TripTyes (by Manpreet)
        public static List<TripType> GetTrips()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                // in the list add te trip types
                List<TripType> trips = db.TripTypes.ToList();
                // return the list
                return trips;
            }
        }
        // function allow user to book a package(by Manpreet)
        public static void AddBooking(int? packageid, DateTime? bookingdate, float? travelcount,int? customer_id,string? triptype)
        {
            // create a object to booking class
            Booking booking = new Booking();
            booking.PackageId = packageid;
            booking.CustomerId = customer_id;
            booking.BookingDate = bookingdate;
            booking.TravelerCount = travelcount;
            booking.TripTypeId = triptype;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                // add the data
                db.Bookings.Add(booking);
                // save the changes
                db.SaveChanges();
            }
        }
        // function to GetBooking Data of particular customer(by Meet Kamal Grewal)
        public static List<Booking> GetBookings(int? customerid)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                // add the data in a booking list. 
                List<Booking> bookings = db.Bookings.Include(b => b.BookingDetails).Where(bk => bk.CustomerId == customerid).ToList();
                // return the list 
                return bookings;
            }
        }
          // Function to Delete the booking by booking_id
        public static void DeleteBooking(int booking_id)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                Booking booking = db.Bookings.Find(booking_id);
                // delete the booking data with particular id
                db.Bookings.Remove(booking);
                //save the changes.
                db.SaveChanges();

            }
        }
        // Function to calculate total cost owing by customer.
        public static decimal GetTotalCost(int? customerId)
        {
            using (var context = new TravelExpertsContext())
            {
                // find the booking by customerid
                var bookings = context.Bookings.Include(b => b.Package)
                .Where(b => b.CustomerId == customerId)
                .ToList();
                // define variable
                decimal totalCost = 0;
                foreach (var booking in bookings)
                {
                  // if packageid is not null
                 if (booking.PackageId != null)
                    {
                        // if only one traveler
                        if (booking.TravelerCount == 1)
                        {
                            totalCost += booking.Package.PkgBasePrice;
                        }
                        // if more the one traveler
                        else
                        {
                            totalCost += booking.Package.PkgBasePrice * Convert.ToDecimal(booking.TravelerCount);
                        }
                    }
                }
                // return thr total cost 
                return totalCost;
            }
        }


    }
}
