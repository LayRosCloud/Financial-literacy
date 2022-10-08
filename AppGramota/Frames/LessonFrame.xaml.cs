using AppGramota.Models;
using AppGramota.SaveChanges;
using System;
using System.Collections.Generic;
using System.Windows.Controls;


namespace AppGramota.Frames
{
    /// <summary>
    /// Логика взаимодействия для LessonFrame.xaml
    /// </summary>
    public partial class LessonFrame : Page
    {
        public LessonFrame(string path)
        {
            InitializeComponent();

            Level level = new Level();
            listLessons.Items.Clear();
            listLessons.ItemsSource = level.GetDefaultData();

            DialogueSystem dialogue = new DialogueSystem(new LoaderTextDialogue(path));
            dialogue.VisibleDialogueBox();
        }

        public LessonFrame()
        {
            InitializeComponent();
            Level level = new Level();
            listLessons.ItemsSource = level.GetDefaultData();
        }


        private void listLessons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Level level = (Level)listLessons.SelectedItem;

            switch (level.Number)
            {
                case 1:
                    AppFrame.frame.Navigate(new FirstLevel());
                    break;
                case 2:
                    AppFrame.frame.Navigate(new SecondLevel());
                    break;
            }
        }
    }
}
