using AppGramota.Frames;
using AppGramota.Models;
using AppGramota.SaveChanges;
using System.Windows;


namespace AppGramota
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            InitializeFrame();
            InitializeHuman();
            InitializeDialogueBox();
            InitializeEnterName();

            frameHub.Navigate(new LessonFrame("opening/opening.txt"));
        }
        //Ининициализация статических классов;
        private void InitializeFrame() //Главный фрейм
        {
            AppFrame.frame = frameHub;
        }
        private void InitializeHuman() //Инициализация главного профиля игрока. При добавлении сохранения изменить.
        {
            AppHuman.text = nameProfile;
            AppHuman.LevelText = levelProfile;
            AppHuman.MoneyText = numMoney;
            AppHuman.Money = default;
            AppHuman.Level = default;
        }
        
        private void InitializeDialogueBox() //Инициализация компонентов dialogueBox
        {
            AppBoxs.Dialogue.dialogue = dialogueBox;
            AppBoxs.Dialogue.NameHuman = nameHuman;
            AppBoxs.Dialogue.sentenceTextBlock = sentence;
            AppBoxs.Dialogue.continueButton = ContinueButton;
            AppBoxs.Dialogue.image = imageHuman;
        }
        private void InitializeEnterName() //Инициализация ввода текста
        {
            AppBoxs.EnterNameBox.grid = enterNameBox;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frameHub.Navigate(new LessonFrame());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frameHub.Navigate(new ShopFrame());
        }

        private void completeButton_Click(object sender, RoutedEventArgs e)
        {
            AppHuman.text.Text = AppHuman.Name = enterNameTextBox.Text;
            
            DialogueSystem dialogue = new DialogueSystem(new LoaderTextDialogue("opening/enterName.txt"));
            dialogue.VisibleDialogueBox();

            AppBoxs.EnterNameBox.grid.Visibility = Visibility.Collapsed;
        }
    }
}
