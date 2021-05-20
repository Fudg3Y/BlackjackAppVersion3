using System;
using System.ComponentModel;


namespace BlackjackAppVersion3
{
    public class Card :INotifyPropertyChanged
    {

        private string _image;
        private string _face;
        private string _suit;
        private int _value;

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

        /**
         * Assigns default values to the cards depending on their face
         */
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
                    cardValue = 1;
                    break;
                default:
                    cardValue = Convert.ToInt32(Face);
                    break;
            }
            return cardValue;
        }



        /**
         * Creates the string for the image path in XAML based on the face and suit of card
         */
        public string GetImage()
        {
            string cardImage = "Assets/JPEG/"+Face + Suit + ".jpg";
            return cardImage;
        }

        
    }
}
