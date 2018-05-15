using FastFoodRobo.Models.Interfaces;
using FastFoodRobo.Models.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using static FastFoodRobo.Models.Enums.ProductGroup;
using static FastFoodRobo.Models.Enums.ProductName;

namespace FastFoodRobo.Models.Abstractions
{
    public abstract class Product : BaseClass, IProduct
    {
        public List<Supplement> Supplements { get; set; } = new List<Supplement>();

        public ProductsGroups ClassProduct { get; }

        public abstract string PreparingProduct { get; }

        public Product(int price, ProductsGroups productsClassifications, List<Supplement> supplements = null)
        {
            Price = price;
            ClassProduct = productsClassifications;

            if (supplements != null)
                Supplements = supplements;
        }

        public static Product CreateProduct(ProductsNames productType)
        {
            switch (productType)
            {
                case ProductsNames.Water:
                    return new Water(20, ProductsGroups.Drink, new List<Supplement> { new Suggar(10) });
                case ProductsNames.Espresso:
                    return new Espresso(50, ProductsGroups.Drink, new List<Supplement> { new Syrup(10), new Milk(15), new Suggar(10) });
                case ProductsNames.Latte:
                    return new Latte(70, ProductsGroups.Drink, new List<Supplement> { new Syrup(10), new Suggar(10) });
                case ProductsNames.Cappuccino:
                    return new Cappuccino(80, ProductsGroups.Drink, new List<Supplement> { new Syrup(10), new Suggar(10) });
                case ProductsNames.BlackTea:
                    return new BlackTea(25, ProductsGroups.Drink, new List<Supplement> { new Milk(15), new Suggar(10) });
                case ProductsNames.GreenTea:
                    return new GreenTea(25, ProductsGroups.Drink, new List<Supplement> { new Milk(15), new Suggar(10) });
                case ProductsNames.Bread:
                    return new Bread(10, ProductsGroups.Food, new List<Supplement> { new Cheese(18), new Ham(25), new Jam(10) });
                case ProductsNames.Bun:
                    return new Bun(10, ProductsGroups.Food, new List<Supplement> { new Cheese(18), new Ham(25), new Jam(10) });
                case ProductsNames.Chips:
                    return new Chips(45, ProductsGroups.Food);
                case ProductsNames.Cookies:
                    return new Cookies(29, ProductsGroups.Food, new List<Supplement> { new Jam(10) });
                default:
                    throw new ArgumentException("This is unknown product type.");
            }
        }

        public int CalculateCost() => Price + Supplements?.Where(a => a.IsChecked).Sum(a => a.Price) ?? 0;
    }
}