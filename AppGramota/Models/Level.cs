using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGramota.Models
{
    internal class Level
    {
        public string SourceImage { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public bool Comlete { get; set; }
        public Level()
        {

        }
        public Level(string sourceImage, string name, string description, int number)
        {
            SourceImage = sourceImage;
            Name = name;
            Description = description;
            Number = number;
        }
        
        public Level[] GetDefaultData()
        {
            Level[] levels = {
                new Level("/Images/addMinus.png", "Доход/расход", "Анализ доходов\\расходов способен вас контролировать свои желания и многое другое", 1),
                new Level("/Images/addDigit.png", "Подушка безопасности", "Не всегда наша жизнь идет по плану, особенно в финансах, поэтому, чтобы не подвергать себя особой опасности, деньги необходимо откладывать на черный день.", 2),
                new Level("/Images/blueBack.jpg", "Кредит", "Уровень заблокирован", 3),
            };
            return levels;
        }

    }
}
