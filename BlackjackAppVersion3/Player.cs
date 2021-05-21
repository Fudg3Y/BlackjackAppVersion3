using System.Collections.ObjectModel;
using System.ComponentModel;


namespace BlackjackAppVersion3
{
    public class Player : INotifyPropertyChanged
    {
        private int _score;
        private ObservableCollection<Card> _hand;

        public ObservableCollection<Card> Hand
        {
            get { return _hand; }
            set
            {
                _hand = value;
                RaisePropertyChanged("hand");
            }
        }


        public int Score 
        {
            get { return _score; }
            set
            {
                _score = value;
                RaisePropertyChanged("Score");
            }
        }

        public int cardLocation; //for dealing to the correct location in list
        public int hitCount;//used for 5 card rule

        //Used to display card back and fill list to prevent binding error

        public Card cardDefault;
        public int iter;
        string[] cardBacks = { "0", "1", "2", "3", "4", "5", "6", "7","8","9" };

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /**
         * Default constructor for player
         */
        public Player()
        {
            Hand = new ObservableCollection<Card>();
            Init();
        }

        /**
         * Used to set reset the game state
         */
        public void ResetPlayer()
        {
            Init();
        }

        /**
         * Fills the hand with default cards to be replaced later in the program, sets default values
         */
        public void Init()
        {
            cardDefault = new Card("0", cardBacks[iter]);
            Hand.Insert(0,cardDefault);
            Hand.Insert(1,cardDefault);
            Hand.Insert(2,cardDefault);
            Hand.Insert(3,cardDefault);
            Hand.Insert(4,cardDefault);
            Score = 0;
            cardLocation = 0;
        }
    }
}
