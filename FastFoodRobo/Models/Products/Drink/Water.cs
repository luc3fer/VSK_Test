using FastFoodRobo.Models.Abstractions;
using FastFoodRobo.Models.Enums;
using FastFoodRobo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using static FastFoodRobo.Models.Enums.ProductGroup;

namespace FastFoodRobo.Models.Products
{
    public class Water : Product
    {
        public Water(int price, ProductsGroups productsClassifications, List<Supplement> supplements = null) : base(price, productsClassifications, supplements)
        {
            Name = "Вода";
        }

        public override string PreparingProduct => "Подогреваем воду";
    }
}