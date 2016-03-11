using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korean_Flash_Cards
{
    public class flashCard
    {
        public string firstLanguage { get; set; }
        public string secondLanguage { get; set; }
        public bool completed { get; set; } = false;

        public flashCard(string firstLanguage, string secondLanguage)
        {
            this.firstLanguage = firstLanguage;
            this.secondLanguage = secondLanguage;
        }

        public void setComplete()
        {
            completed = true;
        }

        public void setIncomplete()
        {
            completed = false;
        }
    }
}
