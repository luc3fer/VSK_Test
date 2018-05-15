using FastFoodRobo.Models.Abstractions;
using FastFoodRobo.Models.Enums;
using FastFoodRobo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFoodRobo.Models.Products
{
    public class Espresso : Product
    {
        public Espresso(int price, ProductGroup.ProductsGroups productsClassifications, List<Supplement> supplements = null) : base(price, productsClassifications, supplements)
        {
            Name = "Эспрессо";
        }

        public override string PreparingProduct => "Готовим эспрессо";
    }
}