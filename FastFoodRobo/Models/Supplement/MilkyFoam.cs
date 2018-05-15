using FastFoodRobo.Models.Abstractions;
using FastFoodRobo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFoodRobo.Models
{
    public class MilkyFoam : Supplement
    {
        public MilkyFoam(int price) : base(price) => Name = "Молочная пенка";
    }
}