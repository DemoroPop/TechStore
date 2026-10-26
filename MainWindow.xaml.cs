using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DiplomaWPF.Models;
using System.Linq;

 namespace DiplomaWPF
{
    public partial class MainWindow : Window
    {
        private List<CartItem> cart = new List<CartItem>();

        public MainWindow()
        {
            InitializeComponent();

            ProductRepository db = new ProductRepository();
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
            CartItem existingItem = cart.Find(item => item.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += 1;
            }
            else
            {
                CartItem cartItem = new CartItem();
                cartItem.Quantity = 1;
                cartItem.Product = product;
                cart.Add(cartItem);
            }
            UpdateCartUI();
        }
        

        private decimal GetCartTotal()
        {
            decimal total = 0;

            foreach (CartItem c in cart)
            {
                total += c.Product.Price * c.Quantity;
            }

            return total;
        }

        private void UpdateCartUI()
        {
            CartCountText.Text = $"Товарів: {cart.Sum(item => item.Quantity)}";
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
