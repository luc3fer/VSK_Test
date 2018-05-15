using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodRobo.Common
{
    public class CheckingEventArgs : EventArgs
    {
        public bool CheckedValue { get; set; }

        public bool Approved { get; set; } = true;
    }
}
