using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackAppVersion3
{
    public class Player : INotifyPropertyChanged
    {
        //private Card[] _hand;
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

        //public Card[] hand
        //{
        //    get { return _hand; }
        //    set { _hand = value;
        //        RaisePropertyChanged("hand");
        //    }
        //}

        public int Score 
        {
            get { return _score; }
            set
            {
                _score = value;
                RaisePropertyChanged("score");
            }
        }
        public int cardLocation; //for dealing to the correct location in array
        public string name;
        public bool dealer;
        public int hitCount;
        readonly Card cardDefault = new Card("0", "0");



        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public Player()
        {
            Hand = new ObservableCollection<Card>();
            Init();
        }

        public void ResetPlayer()
        {
            Init();
        }

        public void Init()
        {
            Hand.Insert(0,cardDefault);
            Hand.Insert(1,cardDefault);
            Hand.Insert(2,cardDefault);
            Hand.Insert(3,cardDefault);
            Hand.Insert(4,cardDefault);
            //hand = new Card[6];
            Score = 0;
            cardLocation = 0;
            name = "";
            dealer = false;
        }
        public void DisplayHand()
        {
            for (int i = 0; i < Hand.Count; i++)
            {
                Debug.WriteLine(Hand[i]);    
            }
        }


        public void IsDealer()
        {
            dealer = true;
        }

        
        

    }
}
