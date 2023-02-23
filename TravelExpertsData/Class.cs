using System;
using System.Collections.Generic;

namespace TravelExpertsData
{
    public partial class Class
    {
        public Class()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public string ClassId { get; set; } = null!;
        public string ClassName { get; set; } = null!;
        public string? ClassDesc { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
