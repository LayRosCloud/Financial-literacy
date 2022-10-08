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
            List<string> sentences = new List<string>()
            {
                "Так мы у первой задачи...",
                "Чтобы начать зарабатывать миллионы денег",
                "Нам необходимо понять, есть ли баланс между моими деньгами",
                "Сейчас я трачу деньги и не зарабатываю, поэтому можем назвать их убывающими.",
                "Помоги мне выйти в позитивные деньги и заработать на машинку."
            };
            DialogueSystem dialogue = new DialogueSystem(sentences.ToArray());

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
                    List<string> sentences = new List<string>()
                    {
                    "Отлично, эта зона то что нам надо",
                    "Теперь я буду зарабатывать деньги",
                    "Давай доведем её до конца."
                    };
                    DialogueSystem dialogue = new DialogueSystem(sentences.ToArray());
                    greenActive = true;
                }
            }
            else if (progress.Value == 50)
            {
                progress.Foreground = Brushes.Blue;
                if (!blueActive)
                {
                    List<string> sentences = new List<string>()
                    {
                    "Ого! Ты попал в синию зону.",
                    "Эта зона мне не поможет заработать денег...",
                    "Потому что я не смогу ни заработать, ни потратить денег"
                    };
                    DialogueSystem dialogue = new DialogueSystem(sentences.ToArray());
                    blueActive = true;
                }
            }
            else
                progress.Foreground = Brushes.Red;

            //завершение уровня
            if (progress.Value >= 100)
            {
                List<string> sentences = new List<string>()
                {
                "Отлично, спасибо тебе!",
                "Благодаря тебе мы преодалели первое испытание и нас ждет ещё столько приключений, приступай ко второму уровню (он недоступен)"
                };

                AppHuman.Level += 1;
                AppFrame.frame.Navigate(new LessonFrame(sentences));
            }
            else if (progress.Value <= 0)
            {
                List<string> sentences = new List<string>()
                {
                "Это провал!",
                "Эта попытка была хорошей. Я все сотру и мы начнем сначала"
                };
                AppFrame.frame.Navigate(new LessonFrame(sentences));

            }

        }
    }
}
