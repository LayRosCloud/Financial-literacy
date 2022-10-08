using AppGramota.Frames;
using AppGramota.SaveChanges;
using System.Windows;


namespace AppGramota
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AppFrame.frame = frameHub;
            AppFrame.grid = gridHub;

            AppHuman.text = nameProfile;
            AppHuman.LevelText = levelProfile;
            AppHuman.MoneyText = numMoney;
            AppHuman.Money = default;
            AppHuman.Level = default;

            AppBoxs.Dialogue.dialogue = dialogueBox;
            AppBoxs.Dialogue.NameHuman = nameHuman;
            AppBoxs.Dialogue.sentenceTextBlock = sentence;
            AppBoxs.Dialogue.continueButton = ContinueButton;
            AppBoxs.Dialogue.image = imageHuman;

            frameHub.Navigate(new LessonFrame("opening/opening.txt"));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frameHub.Navigate(new LessonFrame());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frameHub.Navigate(new ShopFrame());
        }

    }
}
