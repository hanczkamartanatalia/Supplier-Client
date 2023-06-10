
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

using System.Windows.Controls;
using System.Security.Policy;
using System.Reflection.Metadata;
using System.Windows;

using QueueRabbitMQ.MessageService;

using Supplier.Commands;
using Supplier.Model.Rabbit;
using Supplier.Model;
using Supplier.View;
using Supplier.ViewModel;

namespace Client.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        internal MainViewModel()
        {
            LoadMessagesAsync();
            LoadDataAsync();

            OpenAddProductViewCommand = new RelayCommand(OpenAddProductView);
            CloseViewCommand = new RelayCommand(CloseView);
            SendOrderCommand = new RelayCommand(SendOrder);
            MakeOdrerCommand = new RelayCommand(MakeOdrer);
            AddMessageCommand = new RelayCommand(AddMessage);
        }

        #region Buttons

        private void AddMessage(object obj)
        {
            AddMessageView view = new AddMessageView();
            view.ShowDialog();
        }


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
        public ICommand AddMessageCommand { get; }
        public ICommand OpenAddProductViewCommand { get; set; }

        #endregion


        #region MessagesList

        private ObservableCollection<Message> _messageItems;
        public ObservableCollection<Message> MessageItems
        {
            get { return _messageItems; }
            set
            {
                _messageItems = value;
                OnPropertyChanged(nameof(MessageItems));
            }
        }

        private async Task LoadMessagesAsync()
        {

            ObservableCollection<Message> messageItem = new ObservableCollection<Message>();

            ConnectToReceive connectToReceive = new ConnectToReceive();
            List<Message> MessagesLis = connectToReceive.Receive<Message>();

            foreach (Message message in MessagesLis)
            {
                messageItem.Add(message);

            }

            Application.Current.Dispatcher.Invoke(() =>
            {
                MessageItems = messageItem;
            });


        }


        #endregion

        #region DataGrid

        private ObservableCollection<Product> _dataItems;
        public ObservableCollection<Product> DataItems
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
                try
                {
                    List<Product> products = service.GetAllToList<Product>();
                    foreach (var product in products)
                    {
                        dataItems.Add(product);
                    }

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        DataItems = dataItems;
                    });
                }
                catch(Exception ex)
                {

                }
                               
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
