using AppGramota.Models;
using AppGramota.SaveChanges;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AppGramota.Frames
{
    public partial class ShopFrame : Page
    {
        List<Product> products = new List<Product>();
        public ShopFrame()
        {
            InitializeComponent();
            listProducts.ItemsSource = Product.GetProducts;
            products.AddRange(Product.GetProducts);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StackPanel stack =  null;
            Grid grid = (sender as Button).Parent as Grid;

            foreach (UIElement ui in grid.Children.Cast<UIElement>())
            {
                if (ui is StackPanel stackPanel)
                    stack = stackPanel;
            }
            if (stack != null)
            {
                Image img = stack.Children[0] as Image;
                string source = img.Source.ToString().Replace("pack://application:,,,", "");
                
                Product product = products.Find(x => x.SourceImage == source);
                
                if (product.IsPurchased)
                    AppHuman.Source = product.SourceImage;
                
                else if (product.Price <= AppHuman.Money)
                {
                    AppHuman.Source = product.SourceImage;
                    AppHuman.Money -= product.Price;
                    
                    (sender as Button).Content = "Приобритен";
                    listProducts.ItemsSource = Product.GetProducts;

                    product.IsPurchased = true;
                }
            }

        }
    }
}
