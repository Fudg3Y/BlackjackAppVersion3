using Windows.UI.Popups;

namespace BlackjackAppVersion3
{
    
    public class GameController
    {
        public bool stick = false;
        public Deck Deck { get; set; }
        public Player Player { get; set; }
        public Player Dealer { get; set; }

        public GameController()
        {
            Deck = new Deck();
            Player = new Player();
            Dealer = new Player();
        }

        public void NewGame()
        {
            Player.Init();
            Dealer.Init();
            Player.Score = 0;
            Dealer.Score = 0;
            stick = false;
            Player.hitCount = 0;
            Dealer.hitCount = 0;
            Deck.Shuffle();
            InitialiseHands();       
        }

        public void InitialiseHands()
        {
            Deck.DealCard(Player);
            Deck.DealCard(Player);

            Deck.DealCard(Dealer);
            
        }

        public void Hit()
        {
            
            Player.hitCount++;
            if(Player.Score < 21)
            {
              Deck.DealCard(Player);
            }
            CheckScore();
        }

        public void Stick()
        {
            Deck.DealCard(Dealer); //shows dealers second card
            stick = true;
            while (Dealer.Score < 17 && Dealer.Score < 21) //decides whether dealer will draw another card or not
            {
                Dealer.hitCount++;
                Deck.DealCard(Dealer);
            }
            CheckScore();
        }

        public string CheckScore()
        {
            string winMessage = "You win!";
            string loseMessage = "You lose";
            string drawMessage = "It's a draw";
            string scoreMessage;
            if (Player.Score == 21 && Dealer.Score != 21)
            {
                scoreMessage = "You win with " + Player.Score + "!";
                Message(scoreMessage, winMessage);
                return scoreMessage;
            }
            else if (Player.Score > 21)
            {
                scoreMessage = "You've has gone bust with " + Player.Score;
                Message(scoreMessage, loseMessage);
                return scoreMessage;
            }
            else if (Player.Score < 22 && Player.hitCount == 3)
            {
                scoreMessage = "5 cards with a score of " + Player.Score;
                Message(scoreMessage, winMessage);
                return scoreMessage;
            }
            else if (Dealer.Score > 21)
            {
                scoreMessage = "Dealer bust with a score of " + Dealer.Score;
                Message(scoreMessage, winMessage);
                return scoreMessage;
            }
            else if (Dealer.Score < 22 && Dealer.hitCount == 3)
            {
                scoreMessage = "Dealer wins with 5 cards";
                Message(scoreMessage, loseMessage);
                return scoreMessage;
            }
            else if (Dealer.Score > Player.Score && Dealer.Score <= 21 && stick == true)
            {
                scoreMessage = "Dealer wins with " + Dealer.Score;
                Message(scoreMessage, loseMessage);
                return scoreMessage;
            }
            else if (Player.Score > Dealer.Score && stick == true)
            {
                scoreMessage = "You win with " + Player.Score + "!";
                Message(scoreMessage, winMessage);
                return scoreMessage;
            }
            else if (Player.Score == Dealer.Score)
            {
                scoreMessage = "You both had " + Player.Score + "!";
                Message(scoreMessage, drawMessage);
                return scoreMessage;
            }
            else
            {
                return winMessage;
            }
        }

        public void Message(string content, string title)
        {
            _ = new MessageDialog(content, title).ShowAsync();
        }

        
       






    }
}
