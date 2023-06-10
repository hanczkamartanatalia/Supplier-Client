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
using Client.Model;

namespace Client.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        internal MainViewModel() 
        {
            LoadDataAsync();

            OpenAddProductViewCommand = new RelayCommand(OpenAddProductView);
            CloseViewCommand = new RelayCommand(CloseView);
            SendOrderCommand = new RelayCommand(SendOrder);
            MakeOdrerCommand = new RelayCommand(MakeOdrer);
        }

        #region Buttons

        private void OpenAddProductView(object obj)
        {
            AddProductView view = new AddProductView();
            AddProductViewModel addProductViewModel = new AddProductViewModel();

            addProductViewModel.ProductAdded += AddProductViewModel_ProductAdded;
            view.DataContext = addProductViewModel;

            view.ShowDialog();

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

        #endregion


        #region ICommand

        public ICommand CloseViewCommand { get; private set; }
        public ICommand SendOrderCommand { get; }
        public ICommand MakeOdrerCommand { get; }
        public ICommand OpenAddProductViewCommand{get; set;}

        #endregion


        #region DataGrid

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

        private async Task LoadDataAsync()
        {
            await Task.Run(() =>
            {
                ObservableCollection<Product> dataItems = new ObservableCollection<Product>();

                ProductService service = new ProductService();

                List<Product> products = service.GetAllToList<Product>();
                
                foreach (var product in products)
                {
                    dataItems.Add(product);
                }

                Application.Current.Dispatcher.Invoke(() =>
                {
                    DataItems = dataItems;
                });
            });
        }

        #endregion


        #region EventsHandler

        private void AddProductViewModel_ProductAdded(object sender, EventArgs e) 
        {
            LoadDataAsync();
        }

        #endregion
    }
}
