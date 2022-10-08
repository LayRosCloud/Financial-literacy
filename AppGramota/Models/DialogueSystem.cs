using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media;
using AppGramota.SaveChanges;
using System.Windows;

namespace AppGramota.Models
{
    internal class DialogueSystem
    {
        public Uri SourceImage { get; set; }
        public List<string> sentences =new List<string>();
        public string NameHuman;

        private Grid gridPanel;

        TextBlock dialogueBlock;
        Button continueButton;
        Grid grid;
        static bool nameActive = false;
        public DialogueSystem()
        {
            SourceImage = new Uri(AppHuman.Source, UriKind.Relative);
            NameHuman = "Гоша";
            sentences.Add("Тест");
            sentences.Add("Тест2");
            grid = AppFrame.grid;
        }
        public DialogueSystem(IEnumerable<string> sentences)
        {
            SourceImage = new Uri(AppHuman.Source, UriKind.Relative);
            NameHuman = "Гоша";
            this.sentences.AddRange(sentences);
            grid = AppFrame.grid;
            this.GenerateDialogueBox();
        }
        public DialogueSystem(string[] sentences)
        {
            SourceImage = new Uri(AppHuman.Source, UriKind.Relative);
            NameHuman = "Гоша";
            this.sentences.AddRange(sentences);
            grid = AppFrame.grid;
            this.GenerateDialogueBox();
        }
        public DialogueSystem(Uri sourceImage, List<string> sentences, string nameHuman, Grid gridHub)
        {
            SourceImage = sourceImage;
            this.sentences.AddRange(sentences);
            NameHuman = nameHuman;
            grid = gridHub;
        }
        public void GenerateDialogueBox()
        {
            Grid gridBack = new Grid();
            StackPanel stack = new StackPanel();
            stack.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            stack.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            stack.Orientation = Orientation.Horizontal;
            Image image = new Image();
            
            image.Source = new BitmapImage(SourceImage);
            image.Width = 150;
            image.Height = 150;
            stack.Children.Add(image);

            Grid grid = new Grid();
            grid.Width = 500;
            grid.Height = 150;
            TextBlock nameText = new TextBlock();
            nameText.Background = new SolidColorBrush(Color.FromRgb(28, 103, 88));
            nameText.Foreground = new SolidColorBrush(Color.FromRgb(238, 242, 230));
            nameText.Text = NameHuman;
            nameText.VerticalAlignment = VerticalAlignment.Top;
            
            TextBlock dialogueText = new TextBlock();
            Border border = new Border();
            border.Background = Brushes.LightGray;

            dialogueText.Text = sentences[0];
            dialogueText.Margin = new System.Windows.Thickness(0, 15, 0, 15);
            dialogueText.TextWrapping = TextWrapping.Wrap;
            dialogueText.Foreground = new SolidColorBrush(Color.FromRgb(28, 103, 88));

            dialogueBlock = dialogueText;

            grid.Children.Add(border);
            grid.Children.Add(nameText);
            grid.Children.Add(dialogueText);

            Button button = new Button();
            button.Background = Brushes.LightCyan;
            button.BorderThickness = new System.Windows.Thickness(0);
            button.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            button.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            button.Content = "Далее";
            continueButton = button;
            button.Click += Button_Click;

            grid.Children.Add(button);

            stack.Children.Add(grid);

            Grid.SetColumn(gridBack, 1);

            Border background = new Border();
            background.Background = Brushes.Black;
            background.Opacity = 0.5;
            gridBack.Children.Add(background);
            gridBack.Children.Add(stack);

            this.grid.Children.Add(gridBack);
            gridPanel = gridBack;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Continue();
        }
        private void Continue()
        {
            if (sentences.Count <= 1)
            {
                grid.Children.Remove(gridPanel);
                if (AppHuman.Name == null)
                {
                    EnterName enterName = new EnterName();
                    enterName.GenerateBox();
                    nameActive = true;
                }
            }

            else
                sentences.RemoveAt(0);
            if (sentences.Count != 0)
                dialogueBlock.Text = sentences[0];
            
            if (sentences.Count == 1)
                continueButton.Content = "Завершить диалог";

        }
    }
}
