using Supplier.Commands;
using Supplier.Model;
using Supplier.Model.Rabbit;
using Product_OrderLibrary.DataDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Supplier.ViewModel
{
    internal class AddMessageViewModel : BaseViewModel
    {

        internal AddMessageViewModel() 
        {
            SendMessageCommand = new RelayCommand(SendMessage);
        }

        private void SendMessage(object obj)
        {
            try
            {
                DateTime date = DateTime.Now;
                Message message = new Message(TextBoxText, date);

                MessageService service = new MessageService();
                service.Add(message);

                ConnectToSend connect = new ConnectToSend();
                connect.Send(null, message);

                var window = obj as Window;
                window.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        #region ICommand
        public ICommand SendMessageCommand { get; set; }
        #endregion


        #region TextBox Service

        private string _textBoxText;
        public string TextBoxText
        {
            get { return _textBoxText; }
            set
            {
                _textBoxText = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
