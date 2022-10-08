using AppGramota.Models;
using AppGramota.SaveChanges;
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

namespace AppGramota.Frames
{
    /// <summary>
    /// Логика взаимодействия для ShopFrame.xaml
    /// </summary>
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
            foreach(UIElement ui in ((sender as Button).Parent as Grid).Children.Cast<UIElement>())
            {
                if (ui is StackPanel stackPanel)
                    stack = stackPanel;
            }
            if (stack != null)
            {
                string source = (stack.Children[0] as Image).Source.ToString().Replace("pack://application:,,,", "");
                Product product = products.Find(x => x.SourceImage == source);
                if (product.IsPurchased)
                {
                    AppHuman.Source = product.SourceImage;
                }
                else if (product.Price <= AppHuman.Money)
                {
                    AppHuman.Source = product.SourceImage;
                    product.IsPurchased = true;
                    AppHuman.Money -= product.Price;
                    (sender as Button).Content = "Приобритен";
                    listProducts.ItemsSource = Product.GetProducts;

                }
            }

        }
    }
}
