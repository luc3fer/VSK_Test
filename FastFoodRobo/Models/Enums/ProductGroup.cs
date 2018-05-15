using FastFoodRobo.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FastFoodRobo.Models.Enums
{
    public static class ProductGroup
    {
        public enum ProductsGroups
        {
            [Description("Еда")]
            Food,
            [Description("Напитки")]
            Drink
        }
    }
}