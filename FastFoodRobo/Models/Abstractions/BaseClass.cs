using FastFoodRobo.Common;
using FastFoodRobo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodRobo.Models.Abstractions
{
    public abstract class BaseClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<CheckingEventArgs> IsCheckedChanging;
        public event Action IsCheckedChanged;

        public string Name
        {
            get;
            set;
        }

        public int Price { get; set; }

        private bool _isChecked;
        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                var checkingEventArgs = new CheckingEventArgs { CheckedValue = value };
                IsCheckedChanging?.Invoke(this, checkingEventArgs);

                if (checkingEventArgs.Approved)
                {
                    _isChecked = value;
                    IsCheckedChanged?.Invoke();
                }
            }
        }

    }
}
