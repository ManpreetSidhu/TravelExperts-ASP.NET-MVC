using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelExpertsData
{
    public partial class Package
    {
        public Package()
        {
            Bookings = new HashSet<Booking>();
            PackagesProductsSuppliers = new HashSet<PackagesProductsSupplier>();
        }

        public int PackageId { get; set; }
        [Display(Name = "Package Name")]
        public string PkgName { get; set; } = null!;
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? PkgStartDate { get; set; }
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? PkgEndDate { get; set; }
        [Display(Name = "Description")]
        public string? PkgDesc { get; set; }
        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal PkgBasePrice { get; set; }
        public decimal? PkgAgencyCommission { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<PackagesProductsSupplier> PackagesProductsSuppliers { get; set; }
    }
}
