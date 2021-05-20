
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackjackAppVersion3;

namespace BlackjackTests
{
    [TestClass]
    public class UnitTest1
    {
        public GameController gameController_ = new GameController();
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



    }
}
