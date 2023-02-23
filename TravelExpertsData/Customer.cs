using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExpertsData
{
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
            CreditCards = new HashSet<CreditCard>();
            CustomersRewards = new HashSet<CustomersReward>();
        }


        public int CustomerId { get; set; }


        [Required(ErrorMessage = "First Name is Required")]

        public string CustFirstName { get; set; } = null!;
        [Required(ErrorMessage = "Last Name is Required")]
        public string CustLastName { get; set; } = null!;
        [Required(ErrorMessage = "Address is Requried")]
        public string CustAddress { get; set; } = null!;
        [Required(ErrorMessage = "City is Required")]
        public string CustCity { get; set; } = null!;
        [Required(ErrorMessage = "Province is Requried")]
        public string CustProv { get; set; } = null!;
        [Required(ErrorMessage = "Postal is Required")]
        [RegularExpression("^[ABCEGHJ-NPRSTVXY]{1}[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}[ ]?[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}[0-9]{1}$", ErrorMessage = "Incorrect format, proper form is X9X9X9")]
        public string CustPostal { get; set; } = null!;
        [Required(ErrorMessage = "City is Required")]
        public string? CustCountry { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        public string? CustHomePhone { get; set; }
        public string? CustBusPhone { get; set; } = null!; 
        public string? CustEmail { get; set; } = null!; 
        public int? AgentId { get; set; }
        [Required(ErrorMessage = "Username is Requried")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Pasword is Required")]
        

        public string? Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }



        public virtual Agent? Agent { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<CreditCard> CreditCards { get; set; }
        public virtual ICollection<CustomersReward> CustomersRewards { get; set; }
    }
}
