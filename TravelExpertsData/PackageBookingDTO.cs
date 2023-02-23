using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class PackageBookingDTO
    {
        [Display(Name = "Package Name")]
        public string PackageName { get; set; }
        [Display(Name = "Package Description")]
        public string PackageDesc { get; set; }
        [Display(Name = "Start Date")]
        public DateTime? PkgStartDate { get; set; }
        [Display(Name = "End Name")]
        public DateTime? PkgEndDate { get; set; }
        [Display(Name = "Package Price")]
        [DisplayFormat(DataFormatString ="{0:c}")]
        public decimal PkgBasePrice { get; set; }

    }
}
