using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entites
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public int ProductCategoryId { get; set; }
        public string ProductColor { get; set; } = null!;
        public int ProductPrice { get; set; }
        public string ProductImageUrl { get; set; } = null!;
        public virtual Category? ProductCategory { get; set; } = null!;
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}
