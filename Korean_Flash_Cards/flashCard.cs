namespace Korean_Flash_Cards
{
    public class FlashCard
    {
        public string firstLanguage { get; set; }
        public string secondLanguage { get; set; }
        public string firstLanguageOptional { get; set; }
        public string secondLanguageOptional { get; set; }
        public bool completed { get; set; } = false;

        public FlashCard(string firstLanguage, string secondLanguage)
        {
            this.firstLanguage = firstLanguage;
            this.secondLanguage = secondLanguage;
            this.firstLanguageOptional = "";
            this.secondLanguageOptional = "";
        }
        public FlashCard(string firstLanguage, string secondLanguage, string firstLanguageOptional, string secondLanguageOptional)
        {
            this.firstLanguage = firstLanguage;
            this.secondLanguage = secondLanguage;
            this.firstLanguageOptional = firstLanguageOptional;
            this.secondLanguageOptional = secondLanguageOptional;
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
