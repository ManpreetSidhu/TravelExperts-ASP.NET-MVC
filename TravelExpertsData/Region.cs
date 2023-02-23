using System;
using System.Collections.Generic;

namespace TravelExpertsData
{
    public partial class Region
    {
        public Region()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public string RegionId { get; set; } = null!;
        public string? RegionName { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
