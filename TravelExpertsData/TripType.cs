using System;
using System.Collections.Generic;

namespace TravelExpertsData
{
    public partial class TripType
    {
        public TripType()
        {
            Bookings = new HashSet<Booking>();
        }

        public string TripTypeId { get; set; } = null!;
        public string? Ttname { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
