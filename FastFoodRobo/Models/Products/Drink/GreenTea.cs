using FastFoodRobo.Models.Abstractions;
using FastFoodRobo.Models.Enums;
using FastFoodRobo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFoodRobo.Models.Products
{
    public class GreenTea : Product
    {
        public GreenTea(int price, ProductGroup.ProductsGroups productsClassifications, List<Supplement> supplements = null) : base(price, productsClassifications, supplements)
        {
            Name = "Зелёный чай";
        }

        public override string PreparingProduct => "Завариваем зелёный чай";
    }
}