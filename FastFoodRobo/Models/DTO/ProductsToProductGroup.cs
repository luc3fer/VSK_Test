using FastFoodRobo.Common;
using FastFoodRobo.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FastFoodRobo.Models.Enums.ProductGroup;

namespace FastFoodRobo.Models.DTO
{
    public class ProductsToProductGroup
    {
        public ProductsGroups ProductGroup { get; set; }

        public List<Product> Products { get; set; }

        public string ProductGroupName { get => ProductGroup.GetDescription(); }
    }
}
