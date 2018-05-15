using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FastFoodRobo.Models.Abstractions;

namespace FastFoodRobo.Models
{
    public class Cheese : Supplement
    {
        public Cheese(int price):base(price) => Name = "Сыр";
    }
}