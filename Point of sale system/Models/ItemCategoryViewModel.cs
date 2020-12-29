using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Point_of_sale_system.Models
{
    public class ItemCategoryViewModel
    {
        public int categoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BrandID { get; set; }
        public string BrandName { get; set; }
    }
}