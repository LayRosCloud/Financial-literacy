using AppGramota.SaveChanges;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace AppGramota.Models
{
    internal class LoaderTextDialogue
    {
        private string nameHuman;

        public string GetNameHuman { get => nameHuman;  }
        public LoaderTextDialogue(string pathFile)
        {
            StreamReader sr = new StreamReader("dialogues/"+pathFile);
            
            nameHuman = sr.ReadLine();

            AppBoxs.Dialogue.sentences.Clear();

            string[] otherLines = sr.ReadToEnd().Split('\n');
            foreach (string sentence in otherLines)
                AppBoxs.Dialogue.sentences.Add(String.Format(sentence, AppHuman.Name, AppHuman.Level, AppHuman.Money));
            
        }
    }
}
