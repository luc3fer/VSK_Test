using FastFoodRobo.Models.Abstractions;
using FastFoodRobo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFoodRobo.Models
{
    public class Suggar : Supplement
    {
        public Suggar(int price) : base(price) => Name = "Сахар";
    }
}