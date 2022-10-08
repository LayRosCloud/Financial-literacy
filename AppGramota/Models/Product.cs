using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGramota.Models
{
    internal class Product
    {
        public static Product[] products ={
                    new Product("Стандартный", 0, "/Images/hero.png", true),
                    new Product("Стандартный (Синий)", 10, "/Images/heroBlue.png", false),
                    new Product("Стандартный (Черный)", 10, "/Images/heroBlack.png", false)
                };
        public string Title { get; set; }
        public int Price { get; set; }
        public string SourceImage { get; set; }
        public bool IsPurchased { get; set; }
        public string NameButton { get; set; }

        public Product(string title, int price, string sourceImage, bool isPurchased)
        {
            Title = title;
            Price = price;
            SourceImage = sourceImage;
            IsPurchased = isPurchased;
            NameButton = isPurchased ? "Приобритен" : "Приобрести";
            
        }
        public static Product[] GetProducts { get
            {
                return products;
            }
        }
    }

}
