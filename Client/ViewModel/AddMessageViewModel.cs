using Client.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    internal class AddMessageViewModel : BaseViewModel
    {
        internal AddMessageViewModel() 
        {
            SendMessageCommand = new RelayCommand(SendMessage);
        }

        private void SendMessage(object obj)
        {
            
        }


        #region ICommand
        public RelayCommand SendMessageCommand { get; }
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
