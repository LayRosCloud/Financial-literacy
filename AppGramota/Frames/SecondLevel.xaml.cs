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
            AppFrame.timer = timer;

            DialogueSystem dialogue = new DialogueSystem(new LoaderTextDialogue("secondLevel/secondLevelOpening.txt"));
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

        private void Timer_Tick(object sender, EventArgs e) // Счет до происшествия у главного героя
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

                moneyValue += -moneyValue + 10;
                money.Text = "Заработанных денег: " + moneyValue.ToString();

                timerEnd.Interval = new TimeSpan(0, 0, 1);
                timerEnd.Tick += Timer_Tick1;

                AppFrame.timer = timerEnd;

                DialogueSystem dialogueSystem = new DialogueSystem(new LoaderTextDialogue("secondLevel/throwLevel.txt"));
                dialogueSystem.VisibleDialogueBox();

                rightListStackPanel.Children.Remove(rightTextBlocks.Find(x => x.Name == "Подработка: 20"));

                TextBlock text = rightTextBlocks.Find(x => x.Name == null || x.Name == "");

                text.Text = "Помощь маме (ежедневная): -35";
                text = rightTextBlocks.Find(x => x.Name == null || x.Name == "");
                text.Text = "Ваза: -100";

                RefreshScale();
            }
        }

        private void Timer_Tick1(object sender, EventArgs e) //Обратный счет после происшествия у главного героя.
        {
            value -= 1;
            timeOfEnd.Text = value + "/" + maxDate;
            scoreValue -= 3;
            score.Text = "Подушка безопасности: " + scoreValue;

            if (scoreValue < 0)
            {
                timerEnd.Stop();
                
                AppFrame.frame.Navigate(new LessonFrame("secondLevel/loseLevel.txt"));
            }
            if(value == 0)
            {
                timerEnd.Stop();

                AppHuman.Level += 1;
                AppHuman.Money += moneyValue;

                AppFrame.frame.Navigate(new LessonFrame("secondLevel/winLevel.txt"));
            }

        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock text = sender as TextBlock;
            DragDrop.DoDragDrop(text, text.Text, DragDropEffects.Copy);
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
            
        }
        private void RefreshScale()
        {
            foreach (TextBlock right in rightTextBlocks)
            {
                string[] sentence = right.Text.Split(':');
                if (sentence.Length == 2)
                    progress.Value += Convert.ToInt32(sentence[1]);
                if (AppFrame.timer != null)
                {

                }
            }
            //Инициалзиация шкалы по цвету. Расходы>Доходов. Расходы == Доходы. Доходы > Расходы
            if (progress.Value > 50)
                progress.Foreground = Brushes.Green;
            else if (progress.Value == 50)
                progress.Foreground = Brushes.Blue;
            else
                progress.Foreground = Brushes.Red;

        }
    }
}
