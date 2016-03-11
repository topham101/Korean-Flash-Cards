using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Korean_Flash_Cards
{
    /// <summary>
    /// 
    /// ---------------------------------------
    /// THINGS TO DO: 
    /// 
    /// 1. Change random so that it doesn't return the same card again.
    /// 
    /// 3. Think of a better way to read in new flash cards.
    /// 
    /// 4. Think of more things to do . . .
    /// 
    /// ---------------------------------------
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<flashCard> flashCardList;
        private int _UnreadCardsCount = 0;
        public int UnreadCardsCount {
            get { return _UnreadCardsCount; }
            set {
                _UnreadCardsCount = value;
                flashCardsLeftCounter.Content = value; }
        }
        private int curFlashCardIndex = -1, lastFlashCardIndex = -1;
        private string answerString;
        public MainWindow()
        {
            DataContext = this;
            flashCardList = new List<flashCard>();
            flashCardList.Add(new flashCard("Hello", "안녕하세요"));
            flashCardList.Add(new flashCard("Hello2", "안녕하세요2"));
            flashCardList.Add(new flashCard("Hello3", "안녕하세요3"));
            flashCardList.Add(new flashCard("Hello4", "안녕하세요4"));
            InitializeComponent();
            newCard(false);
        }

        private void newCard(bool complete)
        {
            // Sets the last flashCard used to completed
            if (complete)
                flashCardList[curFlashCardIndex].setComplete();

            // Checks that there are any uncompleted flashCards left. - If not the cards are reset.
            if (NoOfUnreadCardsLeft() == 0)
                resetAllFlashCards();

            //Finds a new card that has not been completed.
            lastFlashCardIndex = curFlashCardIndex;
            while (true)
                if (!flashCardList.GetRandomExc(out curFlashCardIndex, lastFlashCardIndex).completed)
                    break;

            // Sets the flashCard at the specified index to completed
            refreshFlashCardInterface(flashCardList.ElementAt(curFlashCardIndex));
        }

        /// <summary>
        /// Sets the UI and answerString for the new FlashCard.
        /// </summary>
        /// <param name="newFlashCard">The new FlashCard</param>
        private void refreshFlashCardInterface(flashCard newFlashCard)
        {
            inputTextBox.Clear();
            Random rnd = new Random();
            int EngOrKor = rnd.Next(1);
            flashCardTextBox.Content = (EngOrKor == 0 ? newFlashCard.english : newFlashCard.korean);
            answerString = (EngOrKor == 1 ? newFlashCard.english : newFlashCard.korean);

            // Sets keyboard focus to the input box
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(delegate ()
            { inputTextBox.Focus(); Keyboard.Focus(inputTextBox); }));
        }

        /// <summary>
        /// Sets all cards to completed.
        /// </summary>
        private void resetAllFlashCards()
        {
            flashCardList.All(x => { x.setIncomplete(); return true; });
            NoOfUnreadCardsLeft();
        }

        /// <summary>
        /// Check's if answer input is the same as answerString.
        /// </summary>
        private void checkInputToAnswer()
        {
            // If the answer is correct . . .
            if (inputTextBox.Text.ToLower() == answerString.ToLower())
            {
                newCard(true);
                inputTextBox.BorderBrush = Brushes.Black;
                inputTextBox.BorderThickness = new Thickness(1);
            }
            else // If the answer is incorrect . . .
            {
                inputTextBox.BorderBrush = Brushes.Red;
                inputTextBox.BorderThickness = new Thickness(2);
            }
        }
        private void checkAnswerButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            checkInputToAnswer();
        }
        private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                checkInputToAnswer();
        }
        private void skipAnswerButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            newCard(false);
        }
        private int NoOfUnreadCardsLeft()
        {
            int unreadCardsLeftCount = 0;
            foreach (flashCard item in flashCardList)
                if (!item.completed)
                    unreadCardsLeftCount++;
            UnreadCardsCount = unreadCardsLeftCount;
            return unreadCardsLeftCount;
        }
    }
}