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
        public List<LeftListObject> listItemsInterective;
        public List<TextBlock> rightTextBlocks = new List<TextBlock>();
        public FirstLevel()
        {
            InitializeComponent();
            DialogueSystem dialogue = new DialogueSystem(new LoaderTextDialogue("firstLevel/firstLevelOpening.txt"));
            dialogue.VisibleDialogueBox();
            listItemsInterective = new List<LeftListObject>()
            {
                new LeftListObject("Подработка: 20"),
                new LeftListObject("Помощь другу: 20"),
                new LeftListObject("Покупка сникерса: -10"),
            };
            foreach (LeftListObject str in listItemsInterective)
            {
                list.Items.Add(str);

            }
            /*foreach (UIElement ui in leftListStackPanel.Children.Cast<UIElement>())
            {
                if (ui is TextBlock text)
                    leftTextBlocks.Add(text);
            }*/
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

        private void progress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (progress.Value > 0)
            {
                progress.Foreground = Brushes.Green;
                if (!greenActive)
                {
                    DialogueSystem dialogue = new DialogueSystem(new LoaderTextDialogue("firstLevel/takeGreenZone.txt"));
                    dialogue.VisibleDialogueBox();
                    greenActive = true;
                }
            }

            else if (progress.Value == 0)
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

        }

        private void TextBlock_Drop(object sender, DragEventArgs e)
        {
            ((TextBlock)sender).Text = (string)e.Data.GetData(DataFormats.Text);

            progress.Value = 0;

            List<string> texts = new List<string>();

            foreach (TextBlock text in rightTextBlocks)
                texts.Add(text.Text);
            
            //симуляция переносимости объектов.
            foreach (LeftListObject left in listItemsInterective)
            {
                if (list.Items.Contains(left)||texts.Contains(left.Item)) 
                    continue;

                list.Items.Add(left);
            }

            list.Items.Remove(listItemsInterective.Find(x => ((TextBlock)sender).Text == x.Item));
            
            //Перерасчет шкалы.
            foreach (TextBlock right in rightTextBlocks)
            {
                string[] sentence = right.Text.Split(':');
                if (sentence.Length == 2)
                {
                    progress.Value += Convert.ToInt32(sentence[1]);
                    
                }
            }

            progressTextBlock.Text = "Бюджет: " + progress.Value.ToString();

            //завершение уровня
            if (progress.Value >= 100)
            {
                AppHuman.Level += 1;
                AppFrame.frame.Navigate(new LessonFrame("firstLevel/winFirstLevel.txt"));
            }
            else if (progress.Value <= -100)
                AppFrame.frame.Navigate(new LessonFrame("firstLevel/loseFirstLevel.txt"));
            

        }
    }
}
