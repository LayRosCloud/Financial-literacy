using AppGramota.Models;
using AppGramota.SaveChanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace AppGramota.Frames
{
    /// <summary>
    /// Логика взаимодействия для SecondLevel.xaml
    /// </summary>
    public partial class SecondLevel : Page
    {
        public List<TextBlock> leftTextBlocks = new List<TextBlock>();
        public List<TextBlock> rightTextBlocks = new List<TextBlock>();
        int maxDate = 30;
        int value = 0;
        double scoreValue = 0;
        double moneyValue = 0;
        DispatcherTimer timer;
        DispatcherTimer timerEnd;
        public SecondLevel()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timerEnd = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            List<string> senteces = new List<string>()
            {
                "...",
                "Странно все это.",
                "В книжке говорится, что подушка безопасности необходима для черных дней, поэтому тратить эти деньги нельзя",
                "Откладывать все время деньги на то, что возможно никогда не произойдет, смешно",
                "Разве у людей бывают черные дни в плане денег, давай забудем про это и будем просто копить на машинку с радиоуправлением.",
                "Я тем более устроился на подработку, поэтому не будем сильно париться об этом пункте."

            };
            DialogueSystem dialogueSystem = new DialogueSystem(senteces.ToArray());
            timer.Start();
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

        private void Timer_Tick(object sender, EventArgs e)
        {
            value += 1;
            timeOfEnd.Text = value + "/" + maxDate;
            double discount = (Convert.ToInt32(progress.Value) - 50) * 0.1;
            if (GivePodushka.IsChecked == true)
            {
                scoreValue += discount;
                score.Text = "Подушка безопасности: " + scoreValue;
            }
            moneyValue += Convert.ToInt32(progress.Value) - 50 - discount;
            money.Text = "Заработанных денег: " + moneyValue.ToString();
            if (value == maxDate)
            {

                timer.Stop();
                List<string> senteces = new List<string>()
                {
                    "Эй.. мне не ловко говорить, но меня уволили с подработки...",
                    "Ну кто знал, что листовки в мусорку выкидывать нельзя",
                    $"И ещё меня попросили заплатить {moneyValue - 10} р.",
                    "Я ходил на экскурсию в музей и разбил там вазу...",
                    "И ещё появились куча новых расходов, о которых я не мог подозревать.",
                    "Моя мама попала в больницу и нам выставили крупный счет за мед. обслуживание",
                    "Иногда приходится стать взрослым пораньше.",
                    "Надеюсь, что благодаря твоему плану, у нас хороший остаток денег, чтобы покрыть, хотя бы часть расходов.",
                    "Сейчас подушка безопасности нужна как никак. Думаю за месяц я справлюсь"
                };
                moneyValue += -moneyValue + 10;
                money.Text = "Заработанных денег: " + moneyValue.ToString();
                DialogueSystem dialogueSystem = new DialogueSystem(senteces.ToArray());
                rightListStackPanel.Children.Remove(rightTextBlocks.Find(x => x.Name == "Подработка: 20"));
                TextBlock text = rightTextBlocks.Find(x => x.Name == null || x.Name == "");
                text.Text = "Помощь маме (ежедневная): -35";
                text = rightTextBlocks.Find(x => x.Name == null || x.Name == "");
                text.Text = "Ваза: -100";
                RefreshScale();
                timerEnd.Interval = new TimeSpan(0, 0, 1);
                timerEnd.Tick += Timer_Tick1;
                timerEnd.Start();
            }
        }

        private void Timer_Tick1(object sender, EventArgs e)
        {
            value -= 1;
            timeOfEnd.Text = value + "/" + maxDate;
            scoreValue -= 3;
            score.Text = "Подушка безопасности: " + scoreValue;

            if (scoreValue < 0)
            {
                timerEnd.Stop();
                List<string> sentences = new List<string>()
                {
                    "Денег на черный день не хватило...",
                    "Я все сотру, только давай попробуем снова, пожалуйста.",
                };
                AppFrame.frame.Navigate(new LessonFrame(sentences));
            }
            if(value == 0)
            {
                timerEnd.Stop();
                List<string> sentences = new List<string>()
                {
                    "У нас получилось!",
                    "Я закрыл все долги, и все благодаря тем деньгам, которые мы откладывали",
                    "Давай перейдем к следующему испытанию, чтобы узнать, как деньги могут ещё нам помочь."
                };
                AppHuman.Level += 1;
                AppHuman.Money += moneyValue;
                AppFrame.frame.Navigate(new LessonFrame(sentences));
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
                if (leftListStackPanel.Children.Contains(left) || texts.Contains(left.Text))
                    continue;
                leftListStackPanel.Children.Add(left);
            }
            leftListStackPanel.Children.Remove(leftTextBlocks.Find(x => ((TextBlock)sender).Text == x.Text));

            //Перерасчет шкалы.
            RefreshScale();
            
            //завершение уровня

        }
        private void RefreshScale()
        {
            foreach (TextBlock right in rightTextBlocks)
            {
                string[] sentence = right.Text.Split(':');
                if (sentence.Length == 2)
                    progress.Value += Convert.ToInt32(sentence[1]);
            }
            if (progress.Value > 50)
                progress.Foreground = Brushes.Green;
            else if (progress.Value == 50)
                progress.Foreground = Brushes.Blue;
            else
                progress.Foreground = Brushes.Red;

        }
    }
}
