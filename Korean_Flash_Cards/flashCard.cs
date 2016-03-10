using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korean_Flash_Cards
{
    public class flashCard
    {
        public string english { get; set; }
        public string korean { get; set; }
        public bool completed { get; set; } = false;

        public flashCard(string english, string korean)
        {
            this.english = english;
            this.korean = korean;
        }

        public void setComplete()
        {
            completed = true;
        }

        public void setIncomplete()
        {
            completed = false;
        }
        public static bool operator ==(flashCard comparisonCard1, flashCard comparisonCard2)
        {
            if (comparisonCard1.english == comparisonCard2.english
                && comparisonCard1.korean == comparisonCard2.korean
                && comparisonCard1.completed == comparisonCard2.completed)
                return true;
            return false;
        }
        public static bool operator !=(flashCard comparisonCard1, flashCard comparisonCard2)
        {
            if (comparisonCard1.english == comparisonCard2.english
                && comparisonCard1.korean == comparisonCard2.korean
                && comparisonCard1.completed == comparisonCard2.completed)
                return false;
            return true;
        }
    }
}
