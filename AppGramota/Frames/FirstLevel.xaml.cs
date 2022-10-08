using AppGramota.Models;
using AppGramota.SaveChanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AppGramota.Frames
{
    /// <summary>
    /// Логика взаимодействия для FirstLevel.xaml
    /// </summary>
    public partial class FirstLevel : Page
    {
        bool blueActive = false, greenActive = false;
        public List<TextBlock> leftTextBlocks = new List<TextBlock>();
        public List<TextBlock> rightTextBlocks = new List<TextBlock>();
        public FirstLevel()
        {
            InitializeComponent();
            DialogueSystem dialogue = new DialogueSystem(new LoaderTextDialogue("firstLevel/firstLevelOpening.txt"));
            dialogue.VisibleDialogueBox();

            foreach (UIElement ui in leftListStackPanel.Children.Cast<UIElement>())
            {
                if (ui is TextBlock text)
                    leftTextBlocks.Add(text);
            }
            foreach (UIElement ui in rightListStackPanel.Children.Cast<UIElement>())
            {
                if (ui is TextBlock text)
                    rightTextBlocks.Add(text);
            }

        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock text = sender as TextBlock;
            DragDrop.DoDragDrop(text, text.Text, DragDropEffects.Copy);
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as TextBlock).Background = new SolidColorBrush(Color.FromRgb(28, 103, 88));
            (sender as TextBlock).Foreground = Brushes.White;
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as TextBlock).Background = Brushes.Transparent;
            (sender as TextBlock).Foreground = new SolidColorBrush(Color.FromRgb(28, 103, 88));

        }

        private void TextBlock_Drop(object sender, DragEventArgs e)
        {
            ((TextBlock)sender).Text = (string)e.Data.GetData(DataFormats.Text);

            progress.Value = 50;

            List<string> texts = new List<string>();

            foreach (TextBlock text in rightTextBlocks)
                texts.Add(text.Text);
            
            //симуляция переносимости объектов.
            foreach (TextBlock left in leftTextBlocks)
            {
                if (leftListStackPanel.Children.Contains(left)||texts.Contains(left.Text)) 
                    continue;

                leftListStackPanel.Children.Add(left);
            }

            leftListStackPanel.Children.Remove(leftTextBlocks.Find(x => ((TextBlock)sender).Text == x.Text));
            
            //Перерасчет шкалы.
            foreach (TextBlock right in rightTextBlocks)
            {
                string[] sentence = right.Text.Split(':');
                if (sentence.Length == 2)
                    progress.Value += Convert.ToInt32(sentence[1]);
            }

            //Выводы по шкале.
            if (progress.Value > 50)
            {
                progress.Foreground = Brushes.Green;
                if (!greenActive)
                {
                    DialogueSystem dialogue = new DialogueSystem(new LoaderTextDialogue("firstLevel/takeGreenZone.txt"));
                    dialogue.VisibleDialogueBox();
                    greenActive = true;
                }
            }

            else if (progress.Value == 50)
            {
                progress.Foreground = Brushes.Blue;
                if (!blueActive)
                {
                    DialogueSystem dialogue = new DialogueSystem(new LoaderTextDialogue("firstLevel/takeBlueZone.txt"));
                    dialogue.VisibleDialogueBox();
                    blueActive = true;
                }
            }
            else
                progress.Foreground = Brushes.Red;

            //завершение уровня
            if (progress.Value >= 100)
            {
                AppHuman.Level += 1;
                AppFrame.frame.Navigate(new LessonFrame("firstLevel/winFirstLevel.txt"));
            }
            else if (progress.Value <= 0)
                AppFrame.frame.Navigate(new LessonFrame("firstLevel/loseFirstLevel.txt"));
            

        }
    }
}
