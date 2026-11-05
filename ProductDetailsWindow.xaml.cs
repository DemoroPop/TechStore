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
using System.Windows.Shapes;

namespace DiplomaWPF
{
    public partial class ProductDetailsWindow : Window
    {
        public event Action<Product> AddToCartRequested;
        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            Product product = DataContext as Product;
            if (product == null)
            {
                return;
            }
            AddToCartRequested?.Invoke(product);
            Close();
        }
        public ProductDetailsWindow(Product product)
        {
            InitializeComponent();
            DataContext = product;
        }
        
    }
}
