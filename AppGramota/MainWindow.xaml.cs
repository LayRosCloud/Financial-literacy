using AppGramota.Frames;
using AppGramota.Models;
using AppGramota.SaveChanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace AppGramota
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppFrame.frame = frameHub;
            AppFrame.grid = gridHub;
            List<string> sentences = new List<string>() {
                "Привет!",
                "Меня зовут Гоша!",
                "Я очень хочу купить себе машину на радиоуправлению с огромными колесами, мне будут завидовать все во дворе.",
                "Но я не знаю с чего мне начать...",
                "Ты мне поможешь?",
                "В одной из книг я прочел, один из шагов успеха является умение тратить деньги.",
                "Но одному изучать так скучно..",
                "Вместе мы сможем стать богатыми и купить машинку, я буду тебя ждать на первом испытании!",
                "Пожалуйста, представься мне, чтобы я знал с кем общаюсь."
                };

            AppHuman.text = nameProfile;
            AppHuman.LevelText = levelProfile;
            AppHuman.MoneyText = numMoney;
            AppHuman.Money = default;
            AppHuman.Level = default;

            AppBoxs.Dialogue.dialogue = dialogueBox;
            AppBoxs.Dialogue.NameHuman = nameHuman;
            AppBoxs.Dialogue.Sentence = sentence;
            AppBoxs.Dialogue.ContinueButton = ContinueButton;
            AppBoxs.Dialogue.image = imageHuman;

            frameHub.Navigate(new LessonFrame(sentences));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frameHub.Navigate(new LessonFrame());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frameHub.Navigate(new ShopFrame());
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
