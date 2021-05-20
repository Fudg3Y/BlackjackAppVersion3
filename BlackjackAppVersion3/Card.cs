using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlackjackAppVersion3
{
    public class Card :INotifyPropertyChanged
    {

        private string _image;
        private string _face;
        private string _suit;
        private int _value;
        private bool _faceUp;

        public string Face
        {
            get { return _face; }
            set
            {
                _face = value;
                RaisePropertyChanged("face");
            }
        }
        public string Suit
        {
            get { return _suit; }
            set
            {
                _suit = value;
                RaisePropertyChanged("suit");
            }
        }
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                RaisePropertyChanged("value");
            }
        }
        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
                RaisePropertyChanged("image");
            }

        }
        public bool FaceUp
        {
            get { return _faceUp; }
            set
            {
                _faceUp = value;
                RaisePropertyChanged("faceUp");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public Card(string cardFace, string cardSuit)
        {
            Face = cardFace;
            Suit = cardSuit;
            Value = GetValue();
            Image = GetImage();
        }

        public Card DefaultCard()
        {
            Card defaultCard = new Card("0", "0");
            return defaultCard;
        }

        public override string ToString()
        {
            string cardName = Face + " of " + Suit + " value: " + GetValue() + " image path = " + GetImage();
            return cardName;
        }

        public int GetValue()
        {
            int cardValue;

            switch(Face)
            {
                case "K":
                case "Q":
                case "J":
                    cardValue = 10;
                    break;
                case "A":
                    cardValue = 11;
                    break;
                default:
                    cardValue = Convert.ToInt32(Face);
                    break;
            }
            return cardValue;
        }

        public string GetImage()
        {
            string cardImage = "Assets/JPEG/"+Face + Suit + ".jpg";
            return cardImage;
        }

        
    }
}
