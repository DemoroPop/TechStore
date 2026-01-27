using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DiplomaWPF
{
    public partial class MainWindow : Window
    {
        private List<Product> cart = new List<Product>();

        public MainWindow()
        {
            InitializeComponent();

            Db db = new Db();
            List<Product> products = db.GetProductList();
            ProductsList.ItemsSource = products;

            UpdateCartUI();
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Product product = button.Tag as Product;

            if (product == null)
                return;

            cart.Add(product);
            UpdateCartUI();
        }

        private decimal GetCartTotal()
        {
            decimal total = 0;

            foreach (Product p in cart)
            {
                total += p.Price;
            }

            return total;
        }

        private void UpdateCartUI()
        {
            CartCountText.Text = $"Товарів: {cart.Count}";
            CartTotalText.Text = $"{GetCartTotal():N0} грн";

            CartItemsList.ItemsSource = null;
            CartItemsList.ItemsSource = cart;

            if (cart.Count == 0)
            {
                CartItemsList.Visibility = Visibility.Collapsed;
                EmptyCartText.Visibility = Visibility.Visible;
            }
            else
            {
                CartItemsList.Visibility = Visibility.Visible;
                EmptyCartText.Visibility = Visibility.Collapsed;
            }
        }

        private void ClearCart_Click(object sender, RoutedEventArgs e)
        {
            cart.Clear();
            UpdateCartUI();
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Кошик порожній");
                return;
            }

            int amount = (int)(GetCartTotal() * 100);
            string orderId = DateTime.Now.Ticks.ToString();

            string url =
                $"https://pay.fondy.eu/api/checkout?order_id={orderId}&amount={amount}&currency=UAH";

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });

            cart.Clear();
            UpdateCartUI();
        }
    }
}
