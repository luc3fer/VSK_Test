using FastFoodRobo.Models.Abstractions;
using FastFoodRobo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFoodRobo.Models
{
    public class Jam : Supplement
    {
        public Jam(int price) : base(price) => Name = "Джем";
    }
}