using System;
using System.Collections.Generic;
using System.Linq;
using FastFoodRobo.Models.Abstractions;
using FastFoodRobo.Models.Enums;
using FastFoodRobo.Models.Interfaces;

namespace FastFoodRobo.Models.Products
{
    public class Cappuccino : Espresso
    {
        public Cappuccino(int price, ProductGroup.ProductsGroups productsClassifications, List<Supplement> supplements = null) : base(price, productsClassifications, supplements)
        {
            Name = "Капучино";

            Supplements.Add(new Milk(10) { IsNotRequrement = false });
            Supplements.Add(new MilkyFoam(15) { IsNotRequrement = false });
        }
    }
}