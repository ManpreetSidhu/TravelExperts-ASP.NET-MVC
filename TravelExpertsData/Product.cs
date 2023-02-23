using System;
using System.Collections.Generic;

namespace TravelExpertsData
{
    public partial class Product
    {
        public Product()
        {
            ProductsSuppliers = new HashSet<ProductsSupplier>();
        }

        public int ProductId { get; set; }
        public string ProdName { get; set; } = null!;

        public virtual ICollection<ProductsSupplier> ProductsSuppliers { get; set; }
    }
}
