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
    public class DejarikTest
    {
        private PrivateObject dejarikTest;
        private Player player1;
        private Player player2;

        /// <summary>
        /// Test if the list of buttons is correclty initalized
        /// </summary>
        [TestMethod]
        public void InitializeListButtonsTest()
        {
            //Arrange
            dejarikTest = new PrivateObject(new Dejarik(""));

            //Act
            dejarikTest.Invoke("initalizeListButtons");//call method
            List<Button> listButtons = (List<Button>)dejarikTest.GetField("listButtons");//getObject

            //Assert
            Assert.AreEqual(26, listButtons.Count);
        }

        /// <summary>
        /// Test if the clicked monster is the right one with the right stats
        /// </summary>
        [TestMethod]
        public void ClickedMonsterIsRightMonster()
        {
            //Arrange
            Monster myMonster = new Monster("The Mantellian Savrip", 2, 3, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Mantellian_Savrip"), typeMonster.Power, 12);
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player1.DefMonster = myMonster;
            player1.ListMonsters = new List<Monster> { player1.DefMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);

            //Act
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("turn", 0);

            //Assert
            Assert.AreEqual(myMonster, dejarikTest.Invoke("getClickMonster", 12));
        }


        /// <summary>
        /// Test if monster available moving positions are correct in normal condition
        /// </summary>
        [TestMethod]
        public void MoveAvailablePositionTest()
        {
            //Arrange
            dejarikTest = new PrivateObject(new Dejarik(""));
            List<int> accessibleButtons = new List<int>() { 1, 3, 13, 15 };

            //Act and assert
            CollectionAssert.AreEqual(accessibleButtons, (List<int>)dejarikTest.Invoke("getMovAccessibleButtons", 2));
        }


        /// <summary>
        /// Test if monster available moving positions are correct when the monster has a neighbour
        /// </summary>
        [TestMethod]
        public void MoveToAvailablePosition1NeighbourTest()
        {
            //Arrange
            dejarikTest = new PrivateObject(new Dejarik(""));
            List<Button> listButtons = (List<Button>)dejarikTest.GetField("listButtons");
            listButtons[3].BackgroundImage = (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Mantellian_Savrip");//Place a neighbour at position 3
            List<int> accessibleButtons = new List<int>() { 1, 13, 15 };

            //Act (Monster at position 3)
            dejarikTest.SetField("listButtons", listButtons);

            //Assert
            CollectionAssert.AreEqual(accessibleButtons, (List<int>)dejarikTest.Invoke("getMovAccessibleButtons", 2));
        }

        /// <summary>
        /// Test if monster available moving positions are correct when the monster has 3 neighbours
        /// </summary>
        [TestMethod]
        public void MoveToAvailablePositionNeighboursTest()
        {
            //Arrange
            dejarikTest = new PrivateObject(new Dejarik(""));
            List<Button> listButtons = (List<Button>)dejarikTest.GetField("listButtons");

            //Place monsters around the position 21 on the board (3 monsters)
            listButtons[8].BackgroundImage = (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Mantellian_Savrip");
            listButtons[20].BackgroundImage = (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Monnok");
            listButtons[22].BackgroundImage = (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk");
            List<int> accessibleButtons = new List<int>() {};

            //Act (Monster at position 8, 20 and 22)
            dejarikTest.SetField("listButtons", listButtons);

            //Assert
            CollectionAssert.AreEqual(accessibleButtons, (List<int>)dejarikTest.Invoke("getMovAccessibleButtons", 21));
        }

        /// <summary>
        /// Test if a monster moved correctly and if his position has changed
        /// </summary>
        [TestMethod]
        public void MonsterMovementTest()
        {
            //Arrange
            Monster myMonster = new Monster("The Mantellian Savrip", 2, 3, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Mantellian_Savrip"), typeMonster.Power, 12);
            dejarikTest = new PrivateObject(new Dejarik(""));
            int nextPosition = 25;

            //Act
            dejarikTest.Invoke("movement", nextPosition, myMonster);
            List<Button> listButtons = (List<Button>)dejarikTest.GetField("listButtons");

            //Assert
            Assert.AreEqual(null, listButtons[12].BackgroundImage);
            Assert.AreEqual(myMonster.Position, 25);
            Assert.AreEqual(myMonster.Picture, listButtons[25].BackgroundImage);
        }

        /// <summary>
        /// Test if the player's monsters positions are correctly set up
        /// </summary>
        [TestMethod]
        public void SetUpPlayerMonstersTest()
        {
            //Arrange
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player1.AttMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            player1.DefMonster = new Monster("The Kintan Strider", 1, 3, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Kintan_Strider"), typeMonster.Defensive, 0);
            player1.MovMonster = new Monster("The K'lor'slug", 2, 1, 3, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("klorslaug"), typeMonster.Mobile, 0);
            player1.PowMonster = new Monster("The Monnok", 3, 2, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Monnok"), typeMonster.Power, 0);

            //Act
            dejarikTest.Invoke("setUpPlayersMonster", player1, 16, 17, 18, 19);
            List<Button> listButtons = (List<Button>)dejarikTest.GetField("listButtons");

            //Assert
            Assert.AreEqual(player1.AttMonster.Position, 16);
            Assert.AreEqual(player1.DefMonster.Position, 17);
            Assert.AreEqual(player1.MovMonster.Position, 18);
            Assert.AreEqual(player1.PowMonster.Position, 19);
            Assert.AreEqual(player1.AttMonster.Picture, listButtons[16].BackgroundImage);
            Assert.AreEqual(player1.DefMonster.Picture, listButtons[17].BackgroundImage);
            Assert.AreEqual(player1.MovMonster.Picture, listButtons[18].BackgroundImage);
            Assert.AreEqual(player1.PowMonster.Picture, listButtons[19].BackgroundImage);
        }

        /// <summary>
        /// Test if the monster's image is correctly displayed on the button (on board)
        /// </summary>
        [TestMethod]
        public void SetMonsterImgTest()
        {
            //Arrange
            dejarikTest = new PrivateObject(new Dejarik(""));
            Monster myMonster = new Monster("The Mantellian Savrip", 2, 3, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Mantellian_Savrip"), typeMonster.Power, 12);

            //Act
            dejarikTest.Invoke("setMonsterImg", myMonster.Position, myMonster.Picture);
            List<Button> listButtons = (List<Button>)dejarikTest.GetField("listButtons");

            //Assert
            Assert.AreEqual(myMonster.Picture, listButtons[12].BackgroundImage);
        }

        /// <summary>
        /// Test if the monster's image and stats are correctly displayed on the right side of the board
        /// </summary>
        [TestMethod]
        public void SetInfoMonstersTest()
        {
            //Arrange
            dejarikTest = new PrivateObject(new Dejarik(""));
            Monster myMonster = new Monster("The Mantellian Savrip", 2, 3, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Mantellian_Savrip"), typeMonster.Power, 12);

            //Act
            List<Button> listButtons = (List<Button>)dejarikTest.GetField("listButtons");
            PictureBox p = (PictureBox)dejarikTest.GetField("imgP1MonsterAtk");
            Label atk = (Label)dejarikTest.GetField("LblAtkMonsterAtk1");
            Label def = (Label)dejarikTest.GetField("LblDefMonsterAtk1");
            Label mov = (Label)dejarikTest.GetField("LblMovMonsterAtk1");
            dejarikTest.Invoke("setInfoMonsters", p, atk, def, mov, myMonster);

            //Assert
            Assert.AreEqual(myMonster.Picture, p.Image);
            Assert.AreEqual(myMonster.Attack.ToString(), atk.Text.ToString());
            Assert.AreEqual(myMonster.Defense.ToString(), def.Text.ToString());
            Assert.AreEqual(myMonster.Movement.ToString(), mov.Text.ToString());
        }

        /// <summary>
        /// Test if current player monsters are enabled
        /// </summary>
        [TestMethod]
        public void ActivateCurrPlayerTest()
        {
            //Arrange
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player1.AttMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 13);
            player1.DefMonster = new Monster("The Kintan Strider", 1, 3, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Kintan_Strider"), typeMonster.Defensive, 14);
            player1.MovMonster = new Monster("The K'lor'slug", 2, 1, 3, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("klorslaug"), typeMonster.Mobile, 19);
            player1.PowMonster = new Monster("The Monnok", 3, 2, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Monnok"), typeMonster.Power, 25);
            player1.ListMonsters = new List<Monster> { player1.AttMonster, player1.DefMonster, player1.MovMonster, player1.PowMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);

            //Act
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("turn", 0);
            dejarikTest.Invoke("activateCurrPlayer");
            List<Button> listButtons = (List<Button>)dejarikTest.GetField("listButtons");

            //Assert
            Assert.IsTrue(listButtons[13].Enabled);
            Assert.IsTrue(listButtons[14].Enabled);
            Assert.IsTrue(listButtons[19].Enabled);
            Assert.IsTrue(listButtons[25].Enabled);
        }

        /// <summary>
        /// Test if the buttons are correctly disabled
        /// </summary>
        [TestMethod]
        public void ButtonsDisabledTest()
        {
            //Arrange
            dejarikTest = new PrivateObject(new Dejarik(""));
            ActivateColorsTest();

            //Act
            List<Button> listButtons = (List<Button>)dejarikTest.GetField("listButtons");
            dejarikTest.Invoke("disableAllButtons");

            //Assert
            for (int i = 0; i < listButtons.Count; i++)
            {
                Assert.IsFalse(listButtons[i].Enabled);
            }
        }

        /// <summary>
        /// Test if current player monsters are correctly colored according to turn
        /// </summary>
        [TestMethod]
        public void ActivateColorsTest()
        {
            //Arrange
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player1.AttMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 13);
            player1.DefMonster = new Monster("The Kintan Strider", 1, 3, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Kintan_Strider"), typeMonster.Defensive, 14);
            player1.MovMonster = new Monster("The K'lor'slug", 2, 1, 3, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("klorslaug"), typeMonster.Mobile, 19);
            player1.PowMonster = new Monster("The Monnok", 3, 2, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Monnok"), typeMonster.Power, 25);
            player1.ListMonsters = new List<Monster> { player1.AttMonster, player1.DefMonster, player1.MovMonster, player1.PowMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);

            //Act
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("turn", 0);
            dejarikTest.Invoke("activateColors");
            List<Button> listButtons = (List<Button>)dejarikTest.GetField("listButtons");

            //Assert
            Assert.IsTrue(listButtons[13].BackColor == Color.FromArgb(80, Color.Gold));
            Assert.IsTrue(listButtons[14].BackColor == Color.FromArgb(80, Color.Gold));
            Assert.IsTrue(listButtons[19].BackColor == Color.FromArgb(80, Color.Gold));
            Assert.IsTrue(listButtons[25].BackColor == Color.FromArgb(80, Color.Gold));
        }

        /// <summary>
        /// Test that when newAtk is greater than newDef by 4 or more, the defender is killed by the attacker
        /// </summary>
        [TestMethod]
        public void DefendAttKillP1Test()
        {
            //Arrange
            Monster attackingMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            Monster defendingMonster = new Monster("The Houjix", 3, 1, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("houjix"), typeMonster.Offensive, 0);
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player2 = new Player();
            player1.AttMonster = attackingMonster;
            player2.AttMonster = defendingMonster;
            player1.ListMonsters = new List<Monster> { player1.AttMonster };
            player2.ListMonsters = new List<Monster> { player2.AttMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            //Act
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("attackingMonster", attackingMonster);
            dejarikTest.SetField("defendingMonster", defendingMonster);
            dejarikTest.Invoke("defend", 1, 9);
            players = (List<Player>)dejarikTest.GetField("players");

            //Assert
            Assert.AreEqual(0, players[1].ListMonsters.Count);
        }

        /// <summary>
        /// Test that when newAtk is greater than newDef by 4 or more, the defender is killed by the attacker
        /// </summary>
        [TestMethod]
        public void DefendAttKillP2Test()
        {
            //Arrange
            Monster attackingMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            Monster defendingMonster = new Monster("The Houjix", 3, 1, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("houjix"), typeMonster.Offensive, 0);
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player2 = new Player();
            player1.AttMonster = defendingMonster;
            player2.AttMonster = attackingMonster;
            player1.ListMonsters = new List<Monster> { player1.AttMonster };
            player2.ListMonsters = new List<Monster> { player2.AttMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            //Act
            dejarikTest.SetField("turn", 1);
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("attackingMonster", attackingMonster);
            dejarikTest.SetField("defendingMonster", defendingMonster);
            dejarikTest.Invoke("defend", 1, 9);
            players = (List<Player>)dejarikTest.GetField("players");

            //Assert
            Assert.AreEqual(0, players[0].ListMonsters.Count);
        }

        /// <summary>
        /// Test that when newAtk is greater than newDef by 1 to 3, the defender is pushed by the attacker (Player 1's turn)
        /// </summary>
        [TestMethod]
        public void DefendAttPushP1Test()
        {
            //Arrange
            Monster attackingMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            Monster defendingMonster = new Monster("The Houjix", 3, 1, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("houjix"), typeMonster.Offensive, 0);
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player2 = new Player();
            player1.AttMonster = attackingMonster;
            player2.AttMonster = defendingMonster;
            player2.AttMonster.Position = 14;
            player1.ListMonsters = new List<Monster> { player1.AttMonster };
            player2.ListMonsters = new List<Monster> { player2.AttMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            //Act
            dejarikTest.Invoke("initalizeListButtons");
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("attackingMonster", attackingMonster);
            dejarikTest.SetField("defendingMonster", defendingMonster);
            dejarikTest.Invoke("defend", 7, 9);
            players = (List<Player>)dejarikTest.GetField("players");

            //Assert
            Assert.AreEqual(1, players[1].ListMonsters.Count); //monstre existe toujours dans la liste
            Assert.AreNotEqual(14, players[1].AttMonster.Position); //monstre a bouger
        }


        /// <summary>
        /// Test that when newAtk is greater than newDef by 1 to 3, the defender is pushed by the attacker (PLayer 2's turn)
        /// </summary>
        [TestMethod]
        public void DefendAttPushP2Test()
        {
            //Arrange
            Monster attackingMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            Monster defendingMonster = new Monster("The Houjix", 3, 1, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("houjix"), typeMonster.Offensive, 0);
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player2 = new Player();
            player1.AttMonster = defendingMonster;
            player2.AttMonster = attackingMonster;
            player1.AttMonster.Position = 14;
            player1.ListMonsters = new List<Monster> { player1.AttMonster };
            player2.ListMonsters = new List<Monster> { player2.AttMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);


            //Act           
            dejarikTest.Invoke("initalizeListButtons");
            dejarikTest.SetField("turn", 1);
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("attackingMonster", attackingMonster);
            dejarikTest.SetField("defendingMonster", defendingMonster);
            dejarikTest.Invoke("defend", 7, 9);


            players = (List<Player>)dejarikTest.GetField("players"); //monstre existe toujours dans la liste
            Assert.AreNotEqual(14, players[0].AttMonster.Position); //monstre a bouger
        }

        /// <summary>
        /// Test that when newAtk is equal to newDef, the defender is pushed by the attacker
        /// </summary>
        [TestMethod]
        public void DefendEqualsTest()
        {
            //Arrange
            Monster attackingMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            Monster defendingMonster = new Monster("The Houjix", 3, 1, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("houjix"), typeMonster.Offensive, 0);
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player2 = new Player();
            player1.AttMonster = attackingMonster;
            player2.AttMonster = defendingMonster;
            player2.AttMonster.Position = 14;
            player1.ListMonsters = new List<Monster> { player1.AttMonster };
            player2.ListMonsters = new List<Monster> { player2.AttMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            //Act
            dejarikTest.Invoke("initalizeListButtons");
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("attackingMonster", attackingMonster);
            dejarikTest.SetField("defendingMonster", defendingMonster);
            dejarikTest.Invoke("defend", 8, 9);
            players = (List<Player>)dejarikTest.GetField("players");
            object newDef = dejarikTest.GetField("newDef");
            //Assert
            Assert.AreEqual(9, newDef);
            Assert.AreEqual(1, players[1].ListMonsters.Count); //monstre existe toujours dans la liste
            Assert.AreNotEqual(14, players[1].AttMonster.Position); //monstre a bouger
        }

        /// <summary>
        /// Test that when newDef is greater than newAtk by 4 or more, the attacker is killed by the defender
        /// Test that when newAtk is equal to newDef, the defender is pushed by the attacker (Player 2's turn)
        /// </summary>
        [TestMethod]
        public void DefendEqualsP2Test()
        {
            //Arrange
            Monster attackingMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            Monster defendingMonster = new Monster("The Houjix", 3, 1, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("houjix"), typeMonster.Offensive, 0);
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player2 = new Player();
            player1.AttMonster = defendingMonster;
            player2.AttMonster = attackingMonster;
            player1.AttMonster.Position = 14;
            player1.ListMonsters = new List<Monster> { player1.AttMonster };
            player2.ListMonsters = new List<Monster> { player2.AttMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            //Act
            dejarikTest.Invoke("initalizeListButtons");
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("attackingMonster", attackingMonster);
            dejarikTest.SetField("defendingMonster", defendingMonster);
            dejarikTest.SetField("turn", 1);
            dejarikTest.Invoke("defend", 8, 9);
            players = (List<Player>)dejarikTest.GetField("players");
            object newDef = dejarikTest.GetField("newDef");


            //Assert
            Assert.AreEqual(9, newDef);
            Assert.AreEqual(1, players[0].ListMonsters.Count); //monstre existe toujours dans la liste
            Assert.AreNotEqual(14, players[0].AttMonster.Position); //monstre a bouger
        }

        /// <summary>
        /// Test that when newDef is greater than newAtk by 1 to 3, the attacker is pushed by the defender
        /// Test that when newDef is greater than newAtk by 4 or more, the attacker is killed by the defender (Player 1's turn)
        /// </summary>
        [TestMethod]
        public void DefendDefKillP1Test()
        {
            //Arrange
            Monster attackingMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            Monster defendingMonster = new Monster("The Houjix", 3, 1, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("houjix"), typeMonster.Offensive, 0);
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player2 = new Player();
            player1.AttMonster = attackingMonster;
            player2.AttMonster = defendingMonster;
            player1.ListMonsters = new List<Monster> { player1.AttMonster };
            player2.ListMonsters = new List<Monster> { player2.AttMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            //Act
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("attackingMonster", attackingMonster);
            dejarikTest.SetField("defendingMonster", defendingMonster);
            dejarikTest.Invoke("defend", 6, 2);
            players = (List<Player>)dejarikTest.GetField("players");

            //Assert
            Assert.AreEqual(0, players[0].ListMonsters.Count);
        }


        /// <summary>
        /// Test that when newDef is greater than newAtk by 4 or more, the attacker is killed by the defender (Player 2's turn)
        /// </summary>
        [TestMethod]
        public void DefendDefKillP2Test()
        {
            //Arrange
            Monster attackingMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            Monster defendingMonster = new Monster("The Houjix", 3, 1, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("houjix"), typeMonster.Offensive, 0);
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player2 = new Player();
            player1.AttMonster = defendingMonster;
            player2.AttMonster = attackingMonster;
            player1.ListMonsters = new List<Monster> { player1.AttMonster };
            player2.ListMonsters = new List<Monster> { player2.AttMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            //Act
            dejarikTest.SetField("turn", 1);
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("attackingMonster", attackingMonster);
            dejarikTest.SetField("defendingMonster", defendingMonster);
            dejarikTest.Invoke("defend", 6, 2);
            players = (List<Player>)dejarikTest.GetField("players");

            //Assert
            Assert.AreEqual(0, players[1].ListMonsters.Count);
        }

        /// <summary>
        /// Test if the monster is correctly pushed and if his position has changed
        /// Test that when the pushed monster has no space to move, he is killed (Player 1's turn)
        /// </summary>
        [TestMethod]
        public void AttackMonsterKillNoSpaceP1Test()
        {
            //Arrange
            Monster attackingMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            Monster defendingMonster = new Monster("The Houjix", 3, 1, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("houjix"), typeMonster.Offensive, 0);
            Monster monster3 = new Monster("The Monnok", 3, 2, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Monnok"), typeMonster.Power, 0);
            Monster monster4 = new Monster("The Kintan Strider", 1, 3, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Kintan_Strider"), typeMonster.Defensive, 0);
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player2 = new Player();
            player1.AttMonster = attackingMonster;
            player2.AttMonster = defendingMonster;
            player2.PowMonster = monster3;
            player2.DefMonster = monster4;
            player1.AttMonster.Position = 2;
            player2.AttMonster.Position = 15;
            player2.DefMonster.Position = 14;
            player2.PowMonster.Position = 16;
            player1.ListMonsters = new List<Monster> { player1.AttMonster };
            player2.ListMonsters = new List<Monster> { player2.AttMonster, player2.DefMonster, player2.PowMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            //Act
            dejarikTest.Invoke("initalizeListButtons");
            dejarikTest.Invoke("setMonsterImg", player1.AttMonster.Position, player1.AttMonster.Picture);
            dejarikTest.Invoke("setMonsterImg", player2.AttMonster.Position, player2.AttMonster.Picture);
            dejarikTest.Invoke("setMonsterImg", player2.PowMonster.Position, player2.PowMonster.Picture);
            dejarikTest.Invoke("setMonsterImg", player2.DefMonster.Position, player2.DefMonster.Picture);
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("attackingMonster", attackingMonster);
            dejarikTest.SetField("defendingMonster", defendingMonster);
            dejarikTest.Invoke("defend", 7, 9);
            players = (List<Player>)dejarikTest.GetField("players");

            //Assert
            Assert.AreEqual(2, players[1].ListMonsters.Count); //player 2 à un monstre de moins 
        }



        /// <summary>
        /// Test that if the monster has any place to be pushed, he is killed
        /// Test that when the pushed monster has no space to move, he is killed (Player 2's turn)
        /// </summary>
        [TestMethod]
        public void AttackMonsterKillNoSpaceP2Test()
        {
            //Arrange
            Monster attackingMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            Monster defendingMonster = new Monster("The Houjix", 3, 1, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("houjix"), typeMonster.Offensive, 0);
            Monster monster3 = new Monster("The Monnok", 3, 2, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Monnok"), typeMonster.Power, 0);
            Monster monster4 = new Monster("The Kintan Strider", 1, 3, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Kintan_Strider"), typeMonster.Defensive, 0);
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player2 = new Player();
            player1.AttMonster = defendingMonster;
            player2.AttMonster = attackingMonster;
            player1.PowMonster = monster3;
            player1.DefMonster = monster4;
            player2.AttMonster.Position = 2;
            player1.AttMonster.Position = 15;
            player1.DefMonster.Position = 14;
            player1.PowMonster.Position = 16;
            player1.ListMonsters = new List<Monster> { player1.AttMonster, player1.DefMonster, player1.PowMonster };
            player2.ListMonsters = new List<Monster> { player2.AttMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            //Act
            dejarikTest.SetField("turn", 1);
            dejarikTest.Invoke("initalizeListButtons");
            dejarikTest.Invoke("setMonsterImg", player2.AttMonster.Position, player2.AttMonster.Picture);
            dejarikTest.Invoke("setMonsterImg", player1.AttMonster.Position, player1.AttMonster.Picture);
            dejarikTest.Invoke("setMonsterImg", player1.PowMonster.Position, player1.PowMonster.Picture);
            dejarikTest.Invoke("setMonsterImg", player1.DefMonster.Position, player1.DefMonster.Picture);
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("attackingMonster", attackingMonster);
            dejarikTest.SetField("defendingMonster", defendingMonster);
            dejarikTest.Invoke("defend", 7, 9);
            players = (List<Player>)dejarikTest.GetField("players");

            //Assert
            Assert.AreEqual(2, players[0].ListMonsters.Count); //player 1 à un monstre de moins 
        }

        /// <summary>
        /// Test if the monster is correctly killed and removed from the map and listMonsters
        /// Test that when newDef is greater than newAtk by 1 to 3, the attacker is pushed by the defender (Player 1's turn)
        /// </summary>
        [TestMethod]
        public void DefendDefPushP1Test()
        {
            //Arrange
            Monster attackingMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            Monster defendingMonster = new Monster("The Houjix", 3, 1, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("houjix"), typeMonster.Offensive, 0);
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player2 = new Player();
            player1.AttMonster = attackingMonster;
            player2.AttMonster = defendingMonster;
            player1.AttMonster.Position = 14;
            player1.ListMonsters = new List<Monster> { player1.AttMonster };
            player2.ListMonsters = new List<Monster> { player2.AttMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            //Act
            dejarikTest.Invoke("initalizeListButtons");
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("attackingMonster", attackingMonster);
            dejarikTest.SetField("defendingMonster", defendingMonster);
            dejarikTest.Invoke("defend", 3, 2);
            players = (List<Player>)dejarikTest.GetField("players");

            //Assert
            Assert.AreEqual(1, players[0].ListMonsters.Count); //monstre existe toujours dans la liste
            Assert.AreNotEqual(14, players[0].AttMonster.Position); //monstre a bouger
        }


        /// <summary>
        /// Test if the variables tmpAtk and tmpDef are correctly modified according to turn
        /// Test that when newDef is greater than newAtk by 1 to 3, the attacker is pushed by the defender (Player 21's turn)
        /// </summary>
        [TestMethod]
        public void DefendDefPushP2Test()
        {
            //Arrange
            Monster attackingMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            Monster defendingMonster = new Monster("The Houjix", 3, 1, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("houjix"), typeMonster.Offensive, 0);
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player2 = new Player();
            player1.AttMonster = defendingMonster;
            player2.AttMonster = attackingMonster;
            player2.AttMonster.Position = 14;
            player1.ListMonsters = new List<Monster> { player1.AttMonster };
            player2.ListMonsters = new List<Monster> { player2.AttMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            //Act
            dejarikTest.SetField("turn", 1);
            dejarikTest.Invoke("initalizeListButtons");
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("attackingMonster", attackingMonster);
            dejarikTest.SetField("defendingMonster", defendingMonster);
            dejarikTest.Invoke("defend", 3, 2);
            players = (List<Player>)dejarikTest.GetField("players");

            //Assert
            Assert.AreEqual(1, players[1].ListMonsters.Count); //monstre existe toujours dans la liste
            Assert.AreNotEqual(14, players[1].AttMonster.Position); //monstre a bouger
        }

        /// <summary>
        /// Test if the action end when the monster has no more movement
        /// </summary>
        [TestMethod]
        public void EndActionWhenMonsterFinishMovementTest()
        {
            //Arrange
            dejarikTest = new PrivateObject(new Dejarik(""));
            Monster myMonster = new Monster("The Ghhhk", 3, 2, 4, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 21);
            int actions = 2, movement = 2, oldPosition = 20, turn = 0;
            player1 = new Player();
            player2 = new Player();
            player1.CurrMonster = myMonster;
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            List<Button> listButtons = (List<Button>)dejarikTest.GetField("listButtons");

            //Place monsters around the position 21 on the board (2 monsters)
            listButtons[8].BackgroundImage = (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Mantellian_Savrip");
            listButtons[22].BackgroundImage = (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk");

            //Act (Monster at position 3)
            dejarikTest.SetField("listButtons", listButtons);
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("actions", actions);
            dejarikTest.SetField("counterMov", movement);
            dejarikTest.SetField("oldPosition", oldPosition);
            dejarikTest.SetField("turn", turn);
            dejarikTest.SetField("lastMonster", myMonster);
            dejarikTest.Invoke("activateMovButtons", myMonster.Position);

            //Assert
            Assert.AreEqual(actions - 1, dejarikTest.GetField("actions"));
            Assert.AreEqual(0, dejarikTest.GetField("counterMov"));
        }

        /// <summary>
        /// Test if player 1 wins after 25 rounds
        /// </summary>
        [TestMethod]
        public void EndGameWinPlayer1Test()
        {
            //Arrange
            dejarikTest = new PrivateObject(new Dejarik(""));
            Monster myMonster = new Monster("The Ghhhk", 3, 2, 4, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 21);
            player1 = new Player();
            player2 = new Player();
            player1.DefMonster= myMonster;    
            player1.AttMonster = myMonster;
            player2.AttMonster = myMonster;
            player1.ListMonsters = new List<Monster> { player1.AttMonster, player1.DefMonster };
            player2.ListMonsters = new List<Monster> { player2.AttMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            List<Button> listButtons = (List<Button>)dejarikTest.GetField("listButtons");
        
            //Act (Monster at position 3)
            dejarikTest.SetField("listButtons", listButtons);
            dejarikTest.SetField("newRound", 25);
            dejarikTest.SetField("players", players);
            dejarikTest.Invoke("endGame");
            players = (List<Player>)dejarikTest.GetField("players");

            //Assert
            Assert.AreEqual(1, players[0].DejarikGamesWon);
        }

        /// <summary>
        /// Test if player 2 wins after 25 rounds
        /// </summary>
        [TestMethod]
        public void EndGameWinPlayer2Test()
        {
            //Arrange
            dejarikTest = new PrivateObject(new Dejarik(""));
            Monster myMonster = new Monster("The Ghhhk", 3, 2, 4, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 21);
            player1 = new Player();
            player2 = new Player();
            player2.DefMonster = myMonster;
            player1.AttMonster = myMonster;
            player2.AttMonster = myMonster;
            player1.ListMonsters = new List<Monster> { player1.AttMonster};
            player2.ListMonsters = new List<Monster> { player2.AttMonster , player2.DefMonster};
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            List<Button> listButtons = (List<Button>)dejarikTest.GetField("listButtons");

            //Act (Monster at position 3)
            dejarikTest.SetField("listButtons", listButtons);
            dejarikTest.SetField("newRound", 25);
            dejarikTest.SetField("players", players);
            dejarikTest.Invoke("endGame");
            players = (List<Player>)dejarikTest.GetField("players");

            //Assert
            Assert.AreEqual(1, players[0].DejarikGamesLost);
        }


        /// <summary>
        /// Test if draw after 25 rounds
        /// </summary>
        [TestMethod]
        public void EndGameDrawTest()
        {
            //Arrange
            dejarikTest = new PrivateObject(new Dejarik(""));
            Monster myMonster = new Monster("The Ghhhk", 3, 2, 4, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 21);
            player1 = new Player();
            player2 = new Player();
            player1.AttMonster = myMonster;
            player2.AttMonster = myMonster;
            player1.ListMonsters = new List<Monster> { player1.AttMonster };
            player2.ListMonsters = new List<Monster> { player2.AttMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            List<Button> listButtons = (List<Button>)dejarikTest.GetField("listButtons");

            //Act (Monster at position 3)
            dejarikTest.SetField("listButtons", listButtons);
            dejarikTest.SetField("newRound", 25);
            dejarikTest.SetField("players", players);
            dejarikTest.Invoke("endGame");
            players = (List<Player>)dejarikTest.GetField("players");

            //Assert
            Assert.AreEqual(0, players[0].DejarikGamesLost);
            Assert.AreEqual(0, players[0].DejarikGamesWon);
        }


        /// <summary>
        /// Test if the monster has the right def after rolling the dice
        /// </summary>
        [TestMethod]
        public void MonsterRollNewDef()
        {
            //Arrange
            Monster attackingMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            Monster defendingMonster = new Monster("The Houjix", 3, 1, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("houjix"), typeMonster.Offensive, 0);
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player2 = new Player();
            player1.AttMonster = defendingMonster;
            player2.AttMonster = attackingMonster;
            player1.ListMonsters = new List<Monster> { player1.AttMonster };
            player2.ListMonsters = new List<Monster> { player2.AttMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            //Act
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("attackingMonster", attackingMonster);
            dejarikTest.SetField("defendingMonster", defendingMonster);
            dejarikTest.Invoke("defend", 5, 1);

            Assert.AreEqual(6, (int)dejarikTest.GetField("newDef"));
        }

        /// <summary>
        /// Test if the attack monster is the one that the player clicked
        /// </summary>
        [TestMethod]
        public void VerifyAttackMonster()
        {
            //Arrange
            Monster attackingMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            Monster randomMonster = new Monster("The Kintan Strider", 1, 3, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Kintan_Strider"), typeMonster.Defensive, 14);
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player1.DefMonster = randomMonster;
            player1.AttMonster = attackingMonster;
            player1.AttMonster.Position = 14;
            player1.DefMonster.Position = 15;
            player1.ListMonsters = new List<Monster> { player1.AttMonster, player1.DefMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);

            //Act
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("turn", 0);
            dejarikTest.Invoke("setAtkMonster", player1.AttMonster.Position);

            Assert.AreEqual(players[(int)dejarikTest.GetField("turn")].ListMonsters[0], (Monster)dejarikTest.GetField("attackingMonster"));
        }

        /// <summary>
        /// Test if the defense monster is the one that the player attacked
        /// </summary>
        [TestMethod]
        public void VerifyDefenseMonster()
        {
            //Arrange
            Monster attackingMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            Monster defendingMonster = new Monster("The Kintan Strider", 1, 3, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Kintan_Strider"), typeMonster.Defensive, 14);
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player2 = new Player();
            player1.AttMonster = attackingMonster;
            player2.DefMonster = defendingMonster;
            player1.AttMonster.Position = 14;
            player2.DefMonster.Position = 15;
            player1.ListMonsters = new List<Monster> { player1.AttMonster };
            player2.ListMonsters = new List<Monster> { player2.DefMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            //Act
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("turn", 0);
            dejarikTest.Invoke("setDefMonster", (int)player2.DefMonster.Position);

            Assert.AreEqual(player2.DefMonster, (Monster)dejarikTest.GetField("defendingMonster"));
        }

        /// <summary>
        /// Test if the log return the correct value for the dice (attack)
        /// </summary>
        [TestMethod]
        public void RollDiceLogTest()
        {
            //Arrange
            Monster attackingMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            Monster defendingMonster = new Monster("The Kintan Strider", 1, 3, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Kintan_Strider"), typeMonster.Defensive, 14);
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player2 = new Player();
            player1.AttMonster = attackingMonster;
            player2.DefMonster = defendingMonster;
            player1.AttMonster.Position = 14;
            player2.DefMonster.Position = 15;
            player1.ListMonsters = new List<Monster> { player1.AttMonster };
            player2.ListMonsters = new List<Monster> { player2.DefMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            //Act
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("turn", 0);
            dejarikTest.SetField("roll", 0);
            dejarikTest.SetField("newRound", 1);
            dejarikTest.SetField("attackingMonster", attackingMonster);
            dejarikTest.SetField("defendingMonster", defendingMonster);
            int newAtkVal = (int)dejarikTest.Invoke("addAttackDice", attackingMonster, 3);
            dejarikTest.Invoke("addLogRollDice", 3, attackingMonster);

            int expectedAtkDiceValue = newAtkVal - player1.AttMonster.Attack; // 3
            String expectedStringAttackingPlayer = "Round " + 1 + " Player 1's Monster : " + player1.AttMonster.Name + " rolled a : " + expectedAtkDiceValue;

            ListBox lb = (ListBox)dejarikTest.GetField("ListBoxLog");
            String actualStringAtk = "";

            for (int i = 0; i < lb.Items.Count; i++)
            {
                if (lb.Items[i].Equals(expectedStringAttackingPlayer))
                {
                    actualStringAtk = lb.Items[i].ToString();
                }
            }
            Assert.AreEqual(expectedStringAttackingPlayer, actualStringAtk);
        }


        /// <summary>
        /// Test if the log return the correct string when the attacker win the push
        /// </summary>
        [TestMethod]
        public void PushAttackerWinLogTest()
        {
            //Arrange
            Monster attackingMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            Monster defendingMonster = new Monster("The Kintan Strider", 1, 3, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Kintan_Strider"), typeMonster.Defensive, 14);
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player2 = new Player();
            player1.AttMonster = attackingMonster;
            player2.DefMonster = defendingMonster;
            player1.AttMonster.Position = 14;
            player2.DefMonster.Position = 15;
            player1.ListMonsters = new List<Monster> { player1.AttMonster };
            player2.ListMonsters = new List<Monster> { player2.DefMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            //Act
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("turn", 0);
            dejarikTest.SetField("newRound", 1);
            dejarikTest.SetField("attackingMonster", attackingMonster);
            dejarikTest.SetField("defendingMonster", defendingMonster);
            dejarikTest.Invoke("defend", 1, 4);

            String expectedStringPushWinner = "Round " + 1 + " : Player 1's monster : " + attackingMonster.Name + " pushed Player 2's monster : " + defendingMonster.Name + " to " + dejarikTest.Invoke("findTagButton", defendingMonster);
            ListBox lb = (ListBox)dejarikTest.GetField("ListBoxLog");
            String actualStringPushWinner = "";
            for (int i = 0; i < lb.Items.Count; i++)
            {
                if (lb.Items[i].Equals(expectedStringPushWinner))
                {
                    actualStringPushWinner = lb.Items[i].ToString();
                }
            }
            Assert.AreEqual(expectedStringPushWinner, actualStringPushWinner);
        }


        /// <summary>
        /// Test if the log return the correct string when the defender win the push
        /// </summary>
        [TestMethod]
        public void PushDefenderWinLogTest()
        {
            //Arrange
            Monster attackingMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            Monster defendingMonster = new Monster("The Kintan Strider", 1, 3, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Kintan_Strider"), typeMonster.Defensive, 14);
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player2 = new Player();
            player1.AttMonster = attackingMonster;
            player2.DefMonster = defendingMonster;
            player1.AttMonster.Position = 14;
            player2.DefMonster.Position = 15;
            player1.ListMonsters = new List<Monster> { player1.AttMonster };
            player2.ListMonsters = new List<Monster> { player2.DefMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            //Act
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("turn", 0);
            dejarikTest.SetField("newRound", 1);
            dejarikTest.SetField("attackingMonster", attackingMonster);
            dejarikTest.SetField("defendingMonster", defendingMonster);
            dejarikTest.Invoke("defend", 2, 4);

            String expectedStringPushWinner = "Round " + 1 + " : Player 2's monster : " + defendingMonster.Name + " pushed Player 1's monster : " + attackingMonster.Name + " to " + dejarikTest.Invoke("findTagButton", attackingMonster);
            ListBox lb = (ListBox)dejarikTest.GetField("ListBoxLog");
            String actualStringPushWinner = "";
            for (int i = 0; i < lb.Items.Count; i++)
            {
                if (lb.Items[i].Equals(expectedStringPushWinner))
                {
                    actualStringPushWinner = lb.Items[i].ToString();
                }
            }
            Assert.AreEqual(expectedStringPushWinner, actualStringPushWinner);
        }


        /// <summary>
        /// Test if the log return the correct string when the attacker win the kill
        /// </summary>
        [TestMethod]
        public void killattackerWinLogTest()
        {
            //Arrange
            Monster attackingMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            Monster defendingMonster = new Monster("The Kintan Strider", 1, 3, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Kintan_Strider"), typeMonster.Defensive, 14);
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player2 = new Player();
            player1.AttMonster = attackingMonster;
            player2.DefMonster = defendingMonster;
            player1.AttMonster.Position = 14;
            player2.DefMonster.Position = 15;
            player1.ListMonsters = new List<Monster> { player1.AttMonster };
            player2.ListMonsters = new List<Monster> { player2.DefMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            //Act
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("turn", 0);
            dejarikTest.SetField("newRound", 1);
            dejarikTest.SetField("attackingMonster", attackingMonster);
            dejarikTest.SetField("defendingMonster", defendingMonster);
            dejarikTest.Invoke("defend", 1, 8);

            String expectedStringkillWinner = "Round " + 1 + " : Player 1's monster : " + attackingMonster.Name + " killed Player 2's monster : " + defendingMonster.Name;
            ListBox lb = (ListBox)dejarikTest.GetField("ListBoxLog");
            String actualStringKillWinner = "";
            for (int i = 0; i < lb.Items.Count; i++)
            {
                if (lb.Items[i].Equals(expectedStringkillWinner))
                {
                    actualStringKillWinner = lb.Items[i].ToString();
                }
            }
            Assert.AreEqual(actualStringKillWinner, actualStringKillWinner);
        }


        /// <summary>
        /// Test if the log return the correct string when the defender win the kill
        /// </summary>
        [TestMethod]
        public void killDefenderWinLogTest()
        {
            //Arrange
            Monster attackingMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            Monster defendingMonster = new Monster("The Kintan Strider", 1, 3, 2, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("Kintan_Strider"), typeMonster.Defensive, 14);
            dejarikTest = new PrivateObject(new Dejarik(""));
            player1 = new Player();
            player2 = new Player();
            player1.AttMonster = attackingMonster;
            player2.DefMonster = defendingMonster;
            player1.AttMonster.Position = 14;
            player2.DefMonster.Position = 15;
            player1.ListMonsters = new List<Monster> { player1.AttMonster };
            player2.ListMonsters = new List<Monster> { player2.DefMonster };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            //Act
            dejarikTest.SetField("players", players);
            dejarikTest.SetField("turn", 0);
            dejarikTest.SetField("newRound", 1);
            dejarikTest.SetField("attackingMonster", attackingMonster);
            dejarikTest.SetField("defendingMonster", defendingMonster);
            dejarikTest.Invoke("defend", 6, 4);

            String expectedStringkillWinner = "Round " + 1 + " : Player 2's monster : " + defendingMonster.Name + " killed Player 1's monster : " + attackingMonster.Name;
            ListBox lb = (ListBox)dejarikTest.GetField("ListBoxLog");
            String actualStringKillWinner = "";
            for (int i = 0; i < lb.Items.Count; i++)
            {
                if (lb.Items[i].Equals(expectedStringkillWinner))
                {
                    actualStringKillWinner = lb.Items[i].ToString();
                }
            }
            Assert.AreEqual(actualStringKillWinner, actualStringKillWinner);
        }

        /// <summary>
        /// Test if the method addAttackDice add correctly the dice value to the attack
        /// </summary>
        [TestMethod]
        public void AddAttackDice()
        {
            //Arrange
            Monster myMonster = new Monster("The Ghhhk", 3, 2, 1, (Image)Projet_GONLO.Properties.Resources.ResourceManager.GetObject("ghhhk"), typeMonster.Offensive, 0);
            dejarikTest = new PrivateObject(new Dejarik(""));

            //Act
            dejarikTest.SetField("attackingMonster", myMonster);
            int newValue = (int)dejarikTest.Invoke("addAttackDice", myMonster, 5);

            //Assert
            Assert.AreEqual(myMonster.Attack+5, newValue);
        }




    }
}
