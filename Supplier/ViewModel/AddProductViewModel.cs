using Supplier.Commands;
using Supplier.Model;
using Product_OrderLibrary.DataDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Client.ViewModel;

namespace Supplier.ViewModel
{
    internal class AddProductViewModel : MainViewModel
    {
        public event EventHandler ProductAdded;
        internal AddProductViewModel() 
        {
            AcceptFormsCommand = new RelayCommand(AcceptForms);
        }

        #region buttons
        private void AcceptForms(object obj)
        {
            try
            {
                Product product = new Product(TextBoxName, TextBoxQuantity, TextBoxPrice);

                ProductService service = new ProductService();
                service.Add(product);

                var window = obj as Window;
                window.Close();
                ProductAdded?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {

            }

        }
        #endregion

        #region ICommand
        public ICommand AcceptFormsCommand { get; set; }

        #endregion

        #region TextBoxs Service

        private decimal _textBoxPrice;
        public decimal TextBoxPrice
        {
            get { return _textBoxPrice; }
            set
            {
                _textBoxPrice = value;
                OnPropertyChanged();
            }
        }

        private int _textBoxQuantity;
        public int TextBoxQuantity
        {
            get { return _textBoxQuantity; }
            set
            {
                _textBoxQuantity = value;
                OnPropertyChanged();
            }
        }

        private string _textBoxName;
        public string TextBoxName
        {
            get { return _textBoxName; }
            set
            {
                _textBoxName = value;
                OnPropertyChanged();
            }
        }

        #endregion

    }
}
