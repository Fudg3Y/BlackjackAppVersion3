
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackjackAppVersion3;

namespace BlackjackTests
{
    [TestClass]
    public class UnitTest1
    {
        public GameController gameController_ = new GameController();
        public Player Player { get; set; }
        public Player Dealer { get; set; }
        public Deck Deck { get; set; }

        String expectedMessage;
        String actualMessage;

        [TestMethod]
        public void DealerHigherThanPlayerStickTrue()
        {
            gameController_.Dealer.Score = 21;
            gameController_.Player.Score = 20;
            
            expectedMessage = "Dealer wins with 21";

            gameController_.stick = true;
            actualMessage = gameController_.CheckScore();

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void PlayerHigherThanDealerStickTrue()
        {
            gameController_.Dealer.Score = 19;
            gameController_.Player.Score = 20;

            expectedMessage = "You win with 20!";

            gameController_.stick = true;
            actualMessage = gameController_.CheckScore();

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void PlayerWinsWith21()
        {
            gameController_.Dealer.Score = 19;
            gameController_.Player.Score = 21;

            expectedMessage = "You win with 21!";

            gameController_.stick = true;
            actualMessage = gameController_.CheckScore();

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void PlayerAndDealerDraw()
        {
            gameController_.Dealer.Score = 20;
            gameController_.Player.Score = 20;

            expectedMessage = "You both had 20!";

            gameController_.stick = true;
            actualMessage = gameController_.CheckScore();

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void AceScoreTest()
        {
            
            
            gameController_.Player.Init();

            gameController_.Deck.DealSpecificCard(gameController_.Player, "A", "H");
            gameController_.Deck.DealSpecificCard(gameController_.Player, "2", "H");
            gameController_.Deck.DealSpecificCard(gameController_.Player, "3", "H");
            gameController_.Deck.DealSpecificCard(gameController_.Player, "4", "H");
            gameController_.Deck.DealSpecificCard(gameController_.Player, "5", "H");

            int expectedScore = 15;

            Assert.AreEqual(gameController_.Player.Score,expectedScore);
        }

        [TestMethod]
        public void AceScoreTestIncreaseValue()
        {

            gameController_.Player.Init();

            gameController_.Deck.DealSpecificCard(gameController_.Player, "A", "H");
            gameController_.Deck.DealSpecificCard(gameController_.Player, "K", "H");

            int expectedScore = 21;

            Assert.AreEqual(gameController_.Player.Score, expectedScore);
        }

        [TestMethod]
        public void FourAcesCardTest()
        {

            gameController_.Player.Init();

            gameController_.Deck.DealSpecificCard(gameController_.Player, "A", "H");
            gameController_.Deck.DealSpecificCard(gameController_.Player, "A", "S");
            gameController_.Deck.DealSpecificCard(gameController_.Player, "A", "C");
            gameController_.Deck.DealSpecificCard(gameController_.Player, "A", "D");

            int expectedScore = 4;

            Assert.AreEqual(gameController_.Player.Score, expectedScore);
        }

        [TestMethod]
        public void Ace4Card21Test()
        {

            gameController_.Player.Init();

            gameController_.Deck.DealSpecificCard(gameController_.Player, "A", "H");
            gameController_.Deck.DealSpecificCard(gameController_.Player, "A", "S");
            gameController_.Deck.DealSpecificCard(gameController_.Player, "A", "C");
            gameController_.Deck.DealSpecificCard(gameController_.Player, "8", "C");

            int expectedScore = 21;

            Assert.AreEqual(gameController_.Player.Score, expectedScore);
        }

        [TestMethod]
        public void Ace5CardTest()
        {

            gameController_.Player.Init();

            gameController_.Deck.DealSpecificCard(gameController_.Player, "A", "H");
            gameController_.Deck.DealSpecificCard(gameController_.Player, "A", "S");
            gameController_.Deck.DealSpecificCard(gameController_.Player, "A", "C");
            gameController_.Deck.DealSpecificCard(gameController_.Player, "4", "C");
            gameController_.Deck.DealSpecificCard(gameController_.Player, "4", "H");

            int expectedScore = 21;

            Assert.AreEqual(gameController_.Player.Score, expectedScore);
        }

        [TestMethod]
        public void OneAce21Test()
        {

            gameController_.Player.Init();

            
            gameController_.Deck.DealSpecificCard(gameController_.Player, "3", "C");
            gameController_.Deck.DealSpecificCard(gameController_.Player, "3", "H");
            gameController_.Deck.DealSpecificCard(gameController_.Player, "4", "C");
            gameController_.Deck.DealSpecificCard(gameController_.Player, "A", "H");

            int expectedScore = 21;

            Assert.AreEqual(gameController_.Player.Score, expectedScore);
        }




    }
}
