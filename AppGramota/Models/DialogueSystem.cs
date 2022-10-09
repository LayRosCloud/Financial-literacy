using System;
using System.Collections.Generic;
using AppGramota.SaveChanges;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Threading;

namespace AppGramota.Models
{
    internal class DialogueSystem
    {

        LoaderTextDialogue load;
        static bool hasEventButton = false;
        public DialogueSystem()
        {

        }
        public DialogueSystem(LoaderTextDialogue loader)
        {
            load = loader;
            AddEventButton();
        }
        private void AddEventButton()
        {
            if(hasEventButton) return;
            
            hasEventButton = true;
            AppBoxs.Dialogue.continueButton.Click += ContinueButton_Click;
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            Continue();
        }

        public void VisibleDialogueBox()
        {
            AppBoxs.Dialogue.dialogue.Visibility = Visibility.Visible;
            AppBoxs.Dialogue.NameHuman.Text = load.GetNameHuman;
            AppBoxs.Dialogue.sentenceTextBlock.Text = AppBoxs.Dialogue.sentences[0];
            AppBoxs.Dialogue.image.Source = new BitmapImage(new Uri(AppHuman.Source, UriKind.Relative));
            AppBoxs.Dialogue.continueButton.Content = "Далее";
        }



        private void Continue()
        {
            if (AppBoxs.Dialogue.sentences.Count <= 1)
            {
                AppBoxs.Dialogue.dialogue.Visibility = Visibility.Collapsed;
                if (AppHuman.Name == null)
                {
                    AppBoxs.EnterNameBox.grid.Visibility = Visibility.Visible;
                }
                if (AppFrame.timer != null)
                {
                    AppFrame.timer.Start();
                    AppFrame.timer = null;
                }
            }
            else
                AppBoxs.Dialogue.sentences.RemoveAt(0);

            if (AppBoxs.Dialogue.sentences.Count > 0)
                AppBoxs.Dialogue.sentenceTextBlock.Text = AppBoxs.Dialogue.sentences[0];

            if (AppBoxs.Dialogue.sentences.Count == 1)
                AppBoxs.Dialogue.continueButton.Content = "Завершить диалог";

        }
    }
}
