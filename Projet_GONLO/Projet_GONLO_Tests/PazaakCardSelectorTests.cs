using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Projet_GONLO;
using Projet_GONLO.Classes;
using System.ComponentModel;

namespace Projet_GONLO_Tests
{
    [TestClass]
    public class PazaakCardSelectorTests
    {
        private PrivateObject PazaakCardSelectorTest;
        private Player player1;

        /// <summary>
        /// Test if the list of buttons is correctly initialised and filled
        /// </summary>
        [TestMethod]
        public void FillListPanelsTest()
        {
            //Arrange
            PazaakCardSelectorTest = new PrivateObject(new PazaakCardsSelector());

            //Act
            PazaakCardSelectorTest.Invoke("FillListPanels"); //call method
            List<RoundPanel> playerDeck = (List<RoundPanel>)PazaakCardSelectorTest.GetField("playerDeck");//getObject
            List<Panel> listeCarteTotal = (List<Panel>)PazaakCardSelectorTest.GetField("listeCarteTotal");//getObject
            int compteurPlayerDeck = 0;
            for (int i = 0; i < playerDeck.Count; i++)
            {
                if (playerDeck[i] != null)
                {
                    compteurPlayerDeck++;
                }
            }
            int compteurListeCarteTotal = 0;
            for (int i = 0; i < listeCarteTotal.Count; i++)
            {
                if (listeCarteTotal[i] != null)
                {
                    compteurListeCarteTotal++;
                }
            }

            //Assert
            Assert.AreEqual(playerDeck.Count, compteurPlayerDeck);
            Assert.AreEqual(listeCarteTotal.Count, compteurListeCarteTotal);

        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void AllCardsSelectedTest()
        {
            //Arrange
            PazaakCardSelectorTest = new PrivateObject(new PazaakCardsSelector());

            //Act
            bool filled = (bool)PazaakCardSelectorTest.Invoke("AllCardsSelected");

            //Assert
            Assert.AreEqual(false, filled);
        }


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void FindPositionPanelTest()
        {
            //Arrange
            PazaakCardSelectorTest = new PrivateObject(new PazaakCardsSelector());

            //Act
            PazaakCardSelectorTest.Invoke("FillListPanels");
            Panel RPnlPlus2 = (Panel)PazaakCardSelectorTest.GetField("RPnlPlus2");//getObject
            int indice = (int)PazaakCardSelectorTest.Invoke("FindPositionPanel", RPnlPlus2);

            //Assert
            Assert.AreEqual(1, indice);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void CheckDeckTest()
        {
            //Arrange
            PazaakCardSelectorTest = new PrivateObject(new PazaakCardsSelector());

            //Act
            PazaakCardSelectorTest.Invoke("FillListPanels");
            int nbCartes = (int)PazaakCardSelectorTest.Invoke("CheckDeck");

            //Assert
            Assert.AreEqual(0, nbCartes);
        }










    }
}
