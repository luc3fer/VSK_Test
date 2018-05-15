using FastFoodRobo.Models.Abstractions;
using FastFoodRobo.Models.Enums;
using FastFoodRobo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFoodRobo.Models.Products
{
    public class Bread : Product
    {
        public Bread(int price, ProductGroup.ProductsGroups productsClassifications, List<Supplement> supplements = null) : base(price, productsClassifications, supplements)
        {
            Name = "Хлеб";
        }

        public override string PreparingProduct => Supplements.Any(a => a.IsChecked) ? "Готовим бутерброд" : "Нарезаем хлебушек";
    }
}