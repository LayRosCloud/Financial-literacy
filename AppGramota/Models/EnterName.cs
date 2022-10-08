using AppGramota.SaveChanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace AppGramota.Models
{
    internal class EnterName
    {
        Grid gridHub;
        TextBox textName;
        
        public void GenerateBox()
        {
            Grid grid = new Grid();
            Border back = new Border();
            back.Background = Brushes.Black;
            back.Opacity = 0.5;
            StackPanel stackVert = new StackPanel();
            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Представьтесь, пожалуйста!";
            textBlock.FontSize = 20;
            textBlock.Background = new SolidColorBrush(Color.FromRgb(28, 103, 88));
            textBlock.Foreground = new SolidColorBrush(Color.FromRgb(238, 242, 230));

            stackVert.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            stackVert.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            stackVert.Children.Add(textBlock);

            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Horizontal;
            TextBox text = new TextBox();
            text.Name = "yourName";
            text.Width = 200;
            text.Height = 40;
            text.FontSize = 18;
            text.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
            textName = text;
            stack.Children.Add(text);
            Button button = new Button();
            button.Content = "Подтвердить";
            button.Height = 40;
            button.Click += Button_Click;
            stack.Children.Add(button);
            stackVert.Children.Add(stack);
            gridHub = grid;
            grid.Children.Add(back);
            grid.Children.Add(stackVert);
            
            Grid.SetColumn(grid, 1);
            AppFrame.grid.Children.Add(grid);
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AppHuman.Name = textName.Text;
            AppHuman.text.Text = textName.Text;
            AppFrame.grid.Children.Remove(gridHub);

            List<string> sentences = new List<string>()
            {
                $"Приятно познакомиться, {AppHuman.Name}",
                "Меня Гоша, хотя я уже представлялся, ну ладно.",
                "Давай приступим к зарабатыванию на машинку."
            };
            DialogueSystem dialogue = new DialogueSystem(sentences.ToArray());
        }
    }
}
