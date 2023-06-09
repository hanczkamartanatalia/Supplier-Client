using Client.Commands;
using Client.Data;
using Client.View;
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
using System.Windows.Input;
using Unipluss.Sign.ExternalContract.Entities;
using System.Windows.Controls;
using System.Security.Policy;
using System.Reflection.Metadata;
using System.Windows;

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
            OpenAddProductViewCommand = new RelayCommand(OpenAddProductView);
            CloseViewCommand = new RelayCommand(CloseView);
            SendOrderCommand = new RelayCommand(SendOrder);
            MakeOdrerCommand = new RelayCommand(MakeOdrer);

        }

        private void SendOrder(object obj)
        {
            throw new NotImplementedException();
        }

        private void MakeOdrer(object obj)
        {
            throw new NotImplementedException();
        }

        private void CloseView(object obj)
        {
            var window = obj as Window;
            window.Close();
        }

        private void OpenAddProductView(object obj)
        {
            AddProductView view = new AddProductView();
            view.ShowDialog();
        }

        public ICommand CloseViewCommand { get; private set; }

        public RelayCommand SendOrderCommand { get; }
        public RelayCommand MakeOdrerCommand { get; }
        public ICommand OpenAddProductViewCommand
        {
            get; set;
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
