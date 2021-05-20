using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackAppVersion3
{
    public class Deck
    {
        readonly Card[] deck;
        int currentCard;
        const int totalCards = 52;
        readonly Random randNum;

        public Deck()
        {
            string[] faces = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            string[] suits = { "H", "D", "S", "C" };//hearts, diamonds, spades, clubs

            deck = new Card[totalCards];
            currentCard = 0;
            randNum = new Random();

            for (int i = 0; i < deck.Length; i++)
            {
                deck[i] = new Card(faces[i % 13], suits[i / 13]); 
            }
        }


        //shuffles deck
        public void Shuffle()
        {
            currentCard = 0;
            for (int first = 0; first < deck.Length; first++)
            {
                int second = randNum.Next(totalCards);
                Card temp = deck[first];
                deck[first] = deck[second];
                deck[second] = temp;
            }
        }

        public void DebugDeckDisplay()
        {
            for (int i = 0; i < deck.Length; i++)
            {
                Debug.WriteLine(deck[i]);
            }
        }

        //returns one card to the player specified
        public Card DealCard(Player p)
        {
            if (p.cardLocation < 5)
            {
                if (currentCard < deck.Length)
                {
                    
                    p.Hand.Insert(p.cardLocation,(deck[currentCard]));
                    
                    p.Score += deck[currentCard].GetValue();

                    //deals with aces causing bust
                    if(p.Score >21 && deck[currentCard].GetValue() == 11)
                    {
                        p.Score -= 11;
                        p.Score += 1;
                    }

                    p.cardLocation++;
                    currentCard++;

                    return p.Hand.ElementAtOrDefault(p.cardLocation);
                }
                
            }

            else
                Debug.WriteLine("Deck is out of cards! You shouldn't be here");
            return null;
        }

      
    }

}
