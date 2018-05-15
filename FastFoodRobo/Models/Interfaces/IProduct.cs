using FastFoodRobo.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using static FastFoodRobo.Models.Enums.ProductGroup;

namespace FastFoodRobo.Models.Interfaces
{
    public interface IProduct
    {
        List<Supplement> Supplements { get; set; }

        ProductsGroups ClassProduct { get; }

        int CalculateCost();

        string PreparingProduct { get; }

        public event Action IsCheckedChanged;
    }
}