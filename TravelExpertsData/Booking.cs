using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelExpertsData
{
    public partial class Booking
    {
        public Booking()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int BookingId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? BookingDate { get; set; }
        public string? BookingNo { get; set; }
        [Range(1,10)]
        public double? TravelerCount { get; set; }
        public int? CustomerId { get; set; }
        public string? TripTypeId { get; set; }
        public int? PackageId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Package? Package { get; set; }
        public virtual TripType? TripType { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
