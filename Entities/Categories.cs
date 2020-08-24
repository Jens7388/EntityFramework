using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<products>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<products> Products { get; set; }
    }
}
