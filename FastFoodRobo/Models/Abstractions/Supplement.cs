using FastFoodRobo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodRobo.Models.Abstractions
{
    public abstract class Supplement : BaseClass, ISupplement
    {
        public Supplement(int price) => Price = price;

        private bool _isNotRequrement = true;
        public bool IsNotRequrement
        {
            get => _isNotRequrement;
            set
            {
                _isNotRequrement = value;
                if (!_isNotRequrement)
                    IsChecked = true;
            }
        }
    }
}
