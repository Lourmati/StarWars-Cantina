using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projet_GONLO;
using Projet_GONLO.Classes;
using System.ComponentModel;


namespace Projet_GONLO_Tests
{
    [TestClass]
    public class PazaakTests
    {
        private PrivateObject pazaakTest;

        /// <summary>
        /// Test that verifys if SetupAiDeck fills well all
        /// the assigned arrays
        /// </summary>
        [TestMethod]
        public void SetupAiDeckTest()
        {
            
            int[] carteIntEnvoye = { 1,2,3,4,5,6,7,8,9,10};
            List<Image> playerDeckPazaak = new List<Image>();
            for (int i = 0; i < 10; i++)
            {
                //Projet_GONLO.Properties.Resources.Carte4;
                playerDeckPazaak.Add(Projet_GONLO.Properties.Resources.Carte4);
            }
            

            //Arrange
            pazaakTest = new PrivateObject(new Pazaak(playerDeckPazaak, carteIntEnvoye));

            //Act
            pazaakTest.Invoke("SetupAiDeck");//call method
            Panel[] TabPnlAiDeck = (Panel[])pazaakTest.GetField("TabPnlAiDeck");//getObject
            int compteur = 0;
            for (int i = 0; i < TabPnlAiDeck.Length; i++)
            {
                if (TabPnlAiDeck[i].BackgroundImage != null && 
                    TabPnlAiDeck[i].BackgroundImageLayout == ImageLayout.Stretch)
                {
                    compteur++;
                }
            }

            //Assert
            Assert.AreEqual(4, compteur);


        }

        /// <summary>
        /// Test that verify if list is well transfered into tab
        /// </summary>
        [TestMethod]
        public void TabToListTest()
        {
            //Arrange
            int[] carteIntEnvoye = { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4};
            List<Image> playerDeckPazaak = new List<Image>();
            for (int i = 0; i < 10; i++)
            {
                
                playerDeckPazaak.Add(Projet_GONLO.Properties.Resources.Carte4);
            }
            pazaakTest = new PrivateObject(new Pazaak(playerDeckPazaak, carteIntEnvoye));

            //Act
            List<int> listeTest = (List<int>) pazaakTest.Invoke("TabToList", carteIntEnvoye);
            bool pareil = true;
            for (int i = 0; i < listeTest.Count; i++)
            {
                if (listeTest[i] != carteIntEnvoye[i])
                {
                    pareil = false;
                }
            }

            //Assert
           Assert.AreEqual(true, pareil);
        }

        /// <summary>
        /// Test that verifys if the SetupBord fills the correct arrays
        /// </summary>
        [TestMethod]
        public void SetupBoardTest()
        {
            //Arrange
            int[] carteIntEnvoye = { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
            List<Image> playerDeckPazaak = new List<Image>();
            for (int i = 0; i < 10; i++)
            {

                playerDeckPazaak.Add(Projet_GONLO.Properties.Resources.Carte4);
            }
            pazaakTest = new PrivateObject(new Pazaak(playerDeckPazaak, carteIntEnvoye));

            //Act
            pazaakTest.Invoke("SetupBoard");//call method
            Panel[] TabPanelLeft = (Panel[])pazaakTest.GetField("TabPanelLeft");//getObject
            Panel[] TabPanelRight = (Panel[])pazaakTest.GetField("TabPanelRight");//getObject
            int compteurLeft = 0;
            int compteurRight = 0;
            for (int i = 0; i < TabPanelLeft.Length; i++)
            {
                 if (TabPanelLeft[i] != null)
                  {
                    compteurLeft++;
                  }
                 if (TabPanelRight[i] != null)
                {
                    compteurRight++;
                }
            }

            //Assert
            Assert.AreEqual(TabPanelLeft.Length, compteurLeft);
            Assert.AreEqual(TabPanelRight.Length, compteurRight);
        }

        /// <summary>
        /// Test that verifys if SetupPlayerDeck fills well playerDeck
        /// </summary>
        [TestMethod]
        public void SetupPlayerdeckTest()
        {

            //Arrange
            int[] carteIntEnvoye = { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
            List<Image> playerDeckPazaak = new List<Image>();
            for (int i = 0; i < 10; i++)
            {

                playerDeckPazaak.Add(Projet_GONLO.Properties.Resources.Carte4);
            }
            pazaakTest = new PrivateObject(new Pazaak(playerDeckPazaak, carteIntEnvoye));

            //Act
            pazaakTest.Invoke("SetupPlayerdeck");//call method
            Panel[] panelPlayerDeck = (Panel[])pazaakTest.GetField("panelPlayerDeck");//getObject
            int[] AiDeck = (int[])pazaakTest.GetField("AiDeck");//getObject
            int compteur = 0;
            for (int i = 0; i < AiDeck.Length; i++)
            {
                if (AiDeck[i] > -7 && AiDeck[i] < 13)
                {
                    compteur++;
                }
            }

            //Assert
            Assert.AreEqual(AiDeck.Length, compteur);
        }

        /// <summary>
        /// Test that verifys if cards are well selected with valid values
        /// </summary>
        [TestMethod]
        public void SelectCardsForDeckTest()
        {
            //Arrange
            int[] carteIntEnvoye = { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
            List<Image> playerDeckPazaak = new List<Image>();
            for (int i = 0; i < 10; i++)
            {

                playerDeckPazaak.Add(Projet_GONLO.Properties.Resources.Carte4);
            }
            pazaakTest = new PrivateObject(new Pazaak(playerDeckPazaak, carteIntEnvoye));

            //Act
            pazaakTest.Invoke("SelectCardsForDeck");//call method
            List<int> ListIntSelectionne = (List<int>)pazaakTest.GetField("ListIntSelectionne");//getObject
            int compteur = 0;
            for (int i = 0; i < ListIntSelectionne.Count; i++)
            {
                if (ListIntSelectionne[i] > -7 && ListIntSelectionne[i] < 13)
                {
                    compteur++;
                }
            }

            //Assert
            Assert.AreEqual(ListIntSelectionne.Count, compteur);
        }

        /// <summary>
        /// Test that verifys if ai card from deck ai is well added to the board
        /// </summary>
        [TestMethod]
        public void AddAICardToBoardTest()
        {
            //Arrange
            int[] carteIntEnvoye = { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
            List<Image> playerDeckPazaak = new List<Image>();
            for (int i = 0; i < 10; i++)
            {

                playerDeckPazaak.Add(Projet_GONLO.Properties.Resources.Carte4);
            }
            pazaakTest = new PrivateObject(new Pazaak(playerDeckPazaak, carteIntEnvoye));

            //Act
            pazaakTest.Invoke("AddAICardToBoard",1);//call method
            Panel[] TabPanelRight = (Panel[])pazaakTest.GetField("TabPanelRight");//getObject
            Player player = (Player)pazaakTest.GetField("ai");
            bool cardAdded = false;
            if (TabPanelRight[player.NbCards-1].BackgroundImage != null)
            {
                cardAdded = true;
            }

            //Assert
            Assert.AreEqual(true, cardAdded);
        }
        /// <summary>
        /// Test that verifys if player card is well added to the boeard
        /// </summary>
        [TestMethod]
        public void AddCardTest()
        {
            //Arrange
            int[] carteIntEnvoye = { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
            List<Image> playerDeckPazaak = new List<Image>();
            for (int i = 0; i < 10; i++)
            {

                playerDeckPazaak.Add(Projet_GONLO.Properties.Resources.Carte4);
            }
            pazaakTest = new PrivateObject(new Pazaak(playerDeckPazaak, carteIntEnvoye));

            //Act
            pazaakTest.Invoke("AddCard", Move.AddCard1);//call method
            Panel[] TabPanelRight = (Panel[])pazaakTest.GetField("TabPanelRight");//getObject
            Player ai = (Player)pazaakTest.GetField("ai");
            bool cardAdded = false;
            if (TabPanelRight[ai.NbCards - 1].BackgroundImage != null)
            {
                cardAdded = true;
            }

            //Assert
            Assert.AreEqual(true, cardAdded);
        }
        /// <summary>
        /// Test that verifys if the Determine move returns the good move
        /// </summary>
        [TestMethod]
        public void DetermineMoveTest()
        {
            //Arrange
            int[] carteIntEnvoye = { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
            List<Image> playerDeckPazaak = new List<Image>();
            for (int i = 0; i < 10; i++)
            {

                playerDeckPazaak.Add(Projet_GONLO.Properties.Resources.Carte4);
            }
            pazaakTest = new PrivateObject(new Pazaak(playerDeckPazaak, carteIntEnvoye));

            //Act
            Player player = (Player)pazaakTest.GetField("ai");
            player.Points = 20;
            Move move = (Move)pazaakTest.Invoke("DetermineMove");//call method
            bool correctMove = false;
            if (move == Move.Stand)
            {
                correctMove = true;
            }

            //Assert
            Assert.AreEqual(true, correctMove);
        }

        /// <summary>
        /// Test that verifys if the Determine move returns the good move
        /// </summary>
        [TestMethod]
        public void DetermineMoveTest2()
        {
            //Arrange
            int[] carteIntEnvoye = { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
            List<Image> playerDeckPazaak = new List<Image>();
            for (int i = 0; i < 10; i++)
            {

                playerDeckPazaak.Add(Projet_GONLO.Properties.Resources.Carte4);
            }
            pazaakTest = new PrivateObject(new Pazaak(playerDeckPazaak, carteIntEnvoye));

            //Act
            Player player = (Player)pazaakTest.GetField("ai");
            player.Points = 13;
            Move move = (Move)pazaakTest.Invoke("DetermineMove");//call method
            bool correctMove = false;
            if (move == Move.End_Turn)
            {
                correctMove = true;
            }

            //Assert
            Assert.AreEqual(true, correctMove);
        }

        /// <summary>
        /// Test that verifys if the Determine move returns the good move
        /// </summary>
        [TestMethod]
        public void DetermineMoveTest3()
        {
            //Arrange
            int[] carteIntEnvoye = { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
            List<Image> playerDeckPazaak = new List<Image>();
            for (int i = 0; i < 10; i++)
            {

                playerDeckPazaak.Add(Projet_GONLO.Properties.Resources.Carte4);
            }
            pazaakTest = new PrivateObject(new Pazaak(playerDeckPazaak, carteIntEnvoye));

            //Act
            int[] AiDeck = { 8, 8, 8, 8 };
            pazaakTest.SetField("AiDeck", AiDeck);
            Player player = (Player)pazaakTest.GetField("ai");
            player.Points = 17;
            Move move = (Move)pazaakTest.Invoke("DetermineMove");//call method
            bool correctMove = false;
            if (move == Move.AddCard1 || move == Move.AddCard2 ||
                move == Move.AddCard3 || move == Move.AddCard4)
            {
                correctMove = true;
            }

            //Assert
            Assert.AreEqual(true, correctMove);
        }
        /// <summary>
        /// Test that Verifys if it gets the correct PlusMinusCard 
        /// </summary>
        [TestMethod]
        public void AddPlusMinusCardTest()
        {
            //Arrange
            int[] carteIntEnvoye = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            List<Image> playerDeckPazaak = new List<Image>();
            for (int i = 0; i < 10; i++)
            {
                playerDeckPazaak.Add(Projet_GONLO.Properties.Resources.CartePlusMinus4);
            }
            pazaakTest = new PrivateObject(new Pazaak(playerDeckPazaak, carteIntEnvoye));

            //Act
            int[] AiDeck = (int[])pazaakTest.GetField("AiDeck");
            for (int i = 0; i < AiDeck.Length; i++)
            {
                AiDeck[i] = 10;
            }
            Player player = (Player)pazaakTest.GetField("ai");
            player.Points = 16;
            Move move = (Move)pazaakTest.Invoke("AddPlusMinusCard");//call method
            bool correctMove = false;
            if (move == Move.AddCard1 || move == Move.AddCard2 ||
                move == Move.AddCard3 || move == Move.AddCard4)
            {
                correctMove = true;
            }
            //Assert
            Assert.AreEqual(true, correctMove);
        }

        /// <summary>
        /// Test that verifys if it get the correct plus card
        /// </summary>
        [TestMethod]
        public void PlusCardTest()
        {
            //Arrange
            int[] carteIntEnvoye = { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
            List<Image> playerDeckPazaak = new List<Image>();
            for (int i = 0; i < 10; i++)
            {
                playerDeckPazaak.Add(Projet_GONLO.Properties.Resources.CartePlus4);
            }
            pazaakTest = new PrivateObject(new Pazaak(playerDeckPazaak, carteIntEnvoye));

            //Act
            int[] AiDeck = (int[])pazaakTest.GetField("AiDeck");
            for (int i = 0; i < AiDeck.Length; i++)
            {
                AiDeck[i] = 10;
            }
            Player player = (Player)pazaakTest.GetField("ai");

            player.Points = 16;
            Move move = (Move)pazaakTest.Invoke("PlusCard");//call method
            bool correctMove = false;
            if (move == Move.AddCard1 || move == Move.AddCard2 ||
                move == Move.AddCard3 || move == Move.AddCard4)
            {
                correctMove = true;
            }
            //Assert
            Assert.AreEqual(true, correctMove);
        }
        /// <summary>
        /// Test that verifys if it get the correct Minus card
        /// </summary>
        [TestMethod]
        public void MinusCardTest()
        {
            //Arrange
            int[] carteIntEnvoye = { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 };
            List<Image> playerDeckPazaak = new List<Image>();
            for (int i = 0; i < 10; i++)
            {
                playerDeckPazaak.Add(Projet_GONLO.Properties.Resources.CarteMinus2);
            }
            pazaakTest = new PrivateObject(new Pazaak(playerDeckPazaak, carteIntEnvoye));

            //Act
            int[] AiDeck = (int[])pazaakTest.GetField("AiDeck");
            for (int i = 0; i < AiDeck.Length; i++)
            {
                AiDeck[i] = 10;
            }
            Player player = (Player)pazaakTest.GetField("ai");
            player.Points = 22;
            Move move = (Move)pazaakTest.Invoke("MinusCard");//call method
            bool correctMove = false;
            if (move == Move.AddCard1 || move == Move.AddCard2 ||
                move == Move.AddCard3 || move == Move.AddCard4)
            {
                correctMove = true;
            }
            //Assert
            Assert.AreEqual(true, correctMove);
        }

        /// <summary>
        /// Method that verifys if Determine card returns the good Move
        /// </summary>
        [TestMethod]
        public void DetermineCardTest()
        {
            ////Arrange
            //int[] carteIntEnvoye = { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 };
            //List<Image> playerDeckPazaak = new List<Image>();
            //for (int i = 0; i < 10; i++)
            //{
            //    playerDeckPazaak.Add(Projet_GONLO.Properties.Resources.CarteMinus2);
            //}
            //pazaakTest = new PrivateObject(new Pazaak(playerDeckPazaak, carteIntEnvoye));

            ////Act
            //Move move = (Move)pazaakTest.Invoke("DetermineCard", 0);//call method
            //bool goodMove = false;
            //MessageBox.Show(move.ToString());
            //if (move == Move.AddCard1)
            //{
            //    goodMove = true;
            //}
            ////Assert
            //Assert.AreEqual(true, goodMove);
        }



        /// <summary>
        /// Test that verifys if Method verifys weel stands of both players
        /// </summary>
        [TestMethod]
        public void VerifyStandsTest()
        {
            //Arrange
            int[] carteIntEnvoye = { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 };
            List<Image> playerDeckPazaak = new List<Image>();
            for (int i = 0; i < 10; i++)
            {
                playerDeckPazaak.Add(Projet_GONLO.Properties.Resources.CarteMinus2);
            }
            pazaakTest = new PrivateObject(new Pazaak(playerDeckPazaak, carteIntEnvoye));

            //Act
            Player ai = (Player)pazaakTest.GetField("ai");
            Player playerPazaak = (Player)pazaakTest.GetField("playerPazaak");
            ai.Stand = true;
            playerPazaak.Stand = true;
            ai.Points = 20;
            playerPazaak.Points = 15;
            pazaakTest.Invoke("VerifyStands");//call method
            bool goodResult = false;
            string result = (string)pazaakTest.GetField("result");
            if (result == "Ai gagne!!")
            {
                goodResult = true;
            }

            //Assert
            Assert.AreEqual(true, goodResult);
        }

        /// <summary>
        /// Verify Stands but with different parameters
        /// </summary>
        [TestMethod]
        public void VerifyStandsTest2()
        {
            //Arrange
            int[] carteIntEnvoye = { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 };
            List<Image> playerDeckPazaak = new List<Image>();
            for (int i = 0; i < 10; i++)
            {
                playerDeckPazaak.Add(Projet_GONLO.Properties.Resources.CarteMinus2);
            }
            pazaakTest = new PrivateObject(new Pazaak(playerDeckPazaak, carteIntEnvoye));

            //Act
            Player ai = (Player)pazaakTest.GetField("ai");
            Player playerPazaak = (Player)pazaakTest.GetField("playerPazaak");
            ai.Stand = true;
            playerPazaak.Stand = true;
            ai.Points = 20;
            playerPazaak.Points = 22;
            pazaakTest.Invoke("VerifyStands");//call method
            bool goodResult = false;
            string result = (string)pazaakTest.GetField("result");
            if (result == "Ai gagne!!")
            {
                goodResult = true;
            }

            //Assert
            Assert.AreEqual(true, goodResult);
        }
        /// <summary>
        /// Verifys stands but with different parameters
        /// </summary>
        [TestMethod]
        public void VerifyStandsTest3()
        {
            //Arrange
            int[] carteIntEnvoye = { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 };
            List<Image> playerDeckPazaak = new List<Image>();
            for (int i = 0; i < 10; i++)
            {
                playerDeckPazaak.Add(Projet_GONLO.Properties.Resources.CarteMinus2);
            }
            pazaakTest = new PrivateObject(new Pazaak(playerDeckPazaak, carteIntEnvoye));

            //Act
            Player ai = (Player)pazaakTest.GetField("ai");
            Player playerPazaak = (Player)pazaakTest.GetField("playerPazaak");
            ai.Stand = true;
            playerPazaak.Stand = true;
            ai.Points = 16;
            playerPazaak.Points = 19;
            pazaakTest.Invoke("VerifyStands");//call method
            bool goodResult = false;
            string result = (string)pazaakTest.GetField("result");
            if (result == "Player gagné!!")
            {
                goodResult = true;
            }

            //Assert
            Assert.AreEqual(true, goodResult);
        }

        /// <summary>
        /// Test that verifys if returns the good value for int parameter
        /// </summary>
        [TestMethod]
        public void differenceFrom20Test()
        {
            //Arrange
            int[] carteIntEnvoye = { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 };
            List<Image> playerDeckPazaak = new List<Image>();
            for (int i = 0; i < 10; i++)
            {
                playerDeckPazaak.Add(Projet_GONLO.Properties.Resources.CarteMinus2);
            }
            pazaakTest = new PrivateObject(new Pazaak(playerDeckPazaak, carteIntEnvoye));

            //Assert
            Assert.AreEqual(10, pazaakTest.Invoke("differenceFrom20", 10));
        }

        /// <summary>
        /// Test that verify the card added by the player is added successfuly
        /// </summary>
        [TestMethod]
        public void AddCardPlayerDeckTest()
        {
            //Arrange
            int[] carteIntEnvoye = { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 };
            List<Image> playerDeckPazaak = new List<Image>();
            for (int i = 0; i < 10; i++)
            {
                playerDeckPazaak.Add(Projet_GONLO.Properties.Resources.CarteMinus2);
            }
            pazaakTest = new PrivateObject(new Pazaak(playerDeckPazaak, carteIntEnvoye));

            //Act
            pazaakTest.Invoke("AddCardPlayerDeck", 1);//call method
            Player playerPazaak = (Player)pazaakTest.GetField("playerPazaak");
            bool carteAjoute = false;
            Panel[] TabPanelLeft = (Panel[])pazaakTest.GetField("TabPanelLeft");

            if (TabPanelLeft[playerPazaak.NbCards - 1] != null)
            {
                carteAjoute = true;
            }
            //Assert
            Assert.AreEqual(true, carteAjoute);
        }

















    }
}
