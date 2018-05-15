using FastFoodRobo.Models.Abstractions;
using FastFoodRobo.Models.Enums;
using FastFoodRobo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFoodRobo.Models.Products
{
    public class Chips : Product
    {
        public Chips(int price, ProductGroup.ProductsGroups productsClassifications, List<Supplement> supplements = null) : base(price, productsClassifications, supplements)
        {
            Name = "Чипсы";

        }

        public override string PreparingProduct => "Высыпаем чипсы";
    }
}