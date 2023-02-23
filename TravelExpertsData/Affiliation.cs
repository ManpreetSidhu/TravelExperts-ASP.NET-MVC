using System;
using System.Collections.Generic;

namespace TravelExpertsData
{
    public partial class Affiliation
    {
        public Affiliation()
        {
            SupplierContacts = new HashSet<SupplierContact>();
        }

        public string AffilitationId { get; set; } = null!;
        public string? AffName { get; set; }
        public string? AffDesc { get; set; }

        public virtual ICollection<SupplierContact> SupplierContacts { get; set; }
    }
}
