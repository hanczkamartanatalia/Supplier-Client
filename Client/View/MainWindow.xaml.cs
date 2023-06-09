using Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Product_OrderLibrary.DataDB.Product product = new Product_OrderLibrary.DataDB.Product
            {
                Name = "aaaaaaa",
                Prcie = 10,
                Quantity = 1
            };
            using (ContextClient context = new ContextClient())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }

            
        }
    }
}
