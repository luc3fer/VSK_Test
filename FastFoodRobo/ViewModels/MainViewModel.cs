using FastFoodRobo.Common;
using FastFoodRobo.Models.Abstractions;
using FastFoodRobo.Models.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static FastFoodRobo.Models.Enums.ProductName;

namespace FastFoodRobo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<ProductsToProductGroup> GroupingProducts { get; set; } = new List<ProductsToProductGroup>();

        public int Cost { get; set; }

        private bool _isComplexSet;
        public bool IsComplexSet
        {
            get => _isComplexSet;
            set
            {
                _isComplexSet = value;

                if (_isComplexSet)
                {
                    var products = GroupingProducts.SelectMany(s => s.Products).ToList();

                    products.ForEach(product =>
                    {
                        var supplements = product.Supplements.Where(a => a.IsNotRequrement && a.IsChecked).Skip(1).ToList();
                        supplements.ForEach(a => a.IsChecked = false);
                    });
                }

                Calculatecost();
            }
        }

        public bool IsPreparing { get; set; }

        public string MessageNotifyForPreparing { get; set; }

        private CommandHandler _clickCommand;
        public CommandHandler ClickCommand
        {
            get
            {
                if (_clickCommand == null)
                    _clickCommand = new CommandHandler(StartPreparingOrder);
                return _clickCommand;
            }
        }

        public MainViewModel()
        {
            var groupingProducts = new List<Product>
            {
                Product.CreateProduct(ProductsNames.Water),
                Product.CreateProduct(ProductsNames.Espresso),
                Product.CreateProduct(ProductsNames.Latte),
                Product.CreateProduct(ProductsNames.Cappuccino),
                Product.CreateProduct(ProductsNames.BlackTea),
                Product.CreateProduct(ProductsNames.GreenTea),
                Product.CreateProduct(ProductsNames.Bread),
                Product.CreateProduct(ProductsNames.Bun),
                Product.CreateProduct(ProductsNames.Chips),
                Product.CreateProduct(ProductsNames.Cookies)
            }.GroupBy(a => a.ClassProduct);

            foreach (var group in groupingProducts)
            {
                var products = group.ToList();

                products.ForEach(a => a.IsCheckedChanged += Calculatecost);

                products.SelectMany(s => s.Supplements).ToList().ForEach(a =>
                {
                    a.IsCheckedChanging += CheckComplexSet;
                    a.IsCheckedChanged += Calculatecost;
                });

                GroupingProducts.Add(new ProductsToProductGroup
                {
                    ProductGroup = group.Key,
                    Products = products
                });

                products.FirstOrDefault().IsChecked = true;
            }
        }

        public void StartPreparingOrder()
        {
            var product = GroupingProducts.SelectMany(s => s.Products.Where(a => a.IsChecked));

            var preparingProducts = product.SelectMany(s =>
            {
                var preparing = new List<string> { s.PreparingProduct };
                preparing.AddRange(s.Supplements.Where(a => a.IsChecked).Select(ss => $"Добавляем \"{ss.Name.ToLower()}\""));

                return preparing;
            }).ToList();

            preparingProducts.Add("ГОТОВО!");
            preparingProducts.Add("Приятного аппетита.");

            IsPreparing = true;
            Task.Factory.StartNew(() =>
            {
                preparingProducts.ForEach(a =>
                {
                    MessageNotifyForPreparing = a;
                    Thread.Sleep(1000);
                });
            }).ContinueWith(task =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    IsPreparing = false;
                    MessageNotifyForPreparing = string.Empty;
                });
            });
        }

        private void CheckComplexSet(object sender, CheckingEventArgs e)
        {
            if (IsComplexSet && e.CheckedValue)
            {
                var product = GroupingProducts.SelectMany(s => s.Products).Single(a => a.Supplements.Contains(sender));
                e.Approved = !product.Supplements.Where(a => a.IsChecked && a.IsNotRequrement).Any();
            }
        }

        private void Calculatecost()
        {
            if (IsComplexSet)
            {
                Cost = Constants.ComplexSetCost;
            }
            else
                Cost = GroupingProducts.SelectMany(s => s.Products.Where(a => a.IsChecked)).Sum(s => s.CalculateCost());
        }
    }
}
