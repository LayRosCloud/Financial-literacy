using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGramota.Models
{
    public class LeftListObject
    {
        public string Item { get; set; }
        public LeftListObject(string item)
        {
            Item = item;
        }
    }
}
