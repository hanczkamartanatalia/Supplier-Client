using Client.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Product_OrderLibrary.DataDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Unipluss.Sign.ExternalContract.Entities;

namespace Client.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Product_OrderLibrary.DataDB.Product> _dataItems;

        public ObservableCollection<Product_OrderLibrary.DataDB.Product> DataItems
        {
            get { return _dataItems; }
            set
            {
                _dataItems = value;
                OnPropertyChanged(nameof(DataItems));
            }
        }

        internal MainViewModel() 
        {
            LoadData();
        }
        
        
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadData()
        {
            _dataItems = new ObservableCollection<Product_OrderLibrary.DataDB.Product>();

            ContextClient context = new ContextClient();
            List<Product_OrderLibrary.DataDB.Product> products = Product_OrderLibrary.Service.ContextService.Products(() => context, "Products");
            foreach (var product in products)
            {
                DataItems.Add(product);
            }

            OnPropertyChanged();
        }

    }
}
