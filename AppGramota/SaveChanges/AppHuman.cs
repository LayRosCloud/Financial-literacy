using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AppGramota.SaveChanges
{
    internal class AppHuman
    {
        public static string Source { get; set; } = "Images/hero.png";
        public static string Name { get; set; }
        private static int level = default;
        private static double money = default;
        public static int Level { get => level;
            set
            {
                level = value;
                levelText.Text = value.ToString() + " Уровень";
            }
        }
        public static double Money
        {
            get => money;
            set
            {
                money = value;
                moneyText.Text = value.ToString() + " Монет";
            }
        }
        private static TextBlock levelText;
        private static TextBlock moneyText;
        public static TextBlock text { get; set; }
        public static TextBlock LevelText { 
            get => levelText; 
            set 
            {
                levelText = value;
            } 
        }
        public static TextBlock MoneyText { 
            get => moneyText; 
            set { 
                moneyText = value;
            } 
        }
    }
}
