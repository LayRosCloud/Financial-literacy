using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AppGramota.SaveChanges
{
    internal class AppBoxs
    {
        
        internal struct Dialogue
        {
            public static Grid dialogue;
            public static TextBlock NameHuman;
            public static TextBlock sentenceTextBlock;
            public static Image image;
            public static Button continueButton;
            public static List<string> sentences = new List<string>();
        }
        internal struct EnterNameBox
        {
            public static Grid grid;
        }
    }
}
