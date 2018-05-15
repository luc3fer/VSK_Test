using System;
using System.Collections.Generic;
using System.Linq;
using FastFoodRobo.Models.Abstractions;
using FastFoodRobo.Models.Enums;
using FastFoodRobo.Models.Interfaces;

namespace FastFoodRobo.Models.Products
{
    public class Latte : Espresso
    {
        public Latte(int price, ProductGroup.ProductsGroups productsClassifications, List<Supplement> supplements = null) : base(price, productsClassifications, supplements)
        {
            Name = "Латте";

            Supplements.Add(new Milk(10) { IsNotRequrement = false });
        }
    }
}