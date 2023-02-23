using System;
using System.Collections.Generic;

namespace TravelExpertsData
{
    public partial class Fee
    {
        public Fee()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public string FeeId { get; set; } = null!;
        public string FeeName { get; set; } = null!;
        public decimal FeeAmt { get; set; }
        public string? FeeDesc { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
