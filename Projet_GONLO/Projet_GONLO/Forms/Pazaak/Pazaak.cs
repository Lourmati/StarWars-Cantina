using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Projet_GONLO.Classes.Pazaak;
namespace Projet_GONLO
{
    /// <summary>
    /// This enumerator has a property for each possible move the player can make
    /// </summary>
    public enum Move { Stand, End_Turn, AddCard1, AddCard2, AddCard3, AddCard4 };


    /// <summary>
    /// Class Pazaak
    /// </summary>
    public partial class Pazaak : Form
    {
        List<Image> playerDeckPazaak = new List<Image>();
        List<int> carteIntEnvoye = new List<int>();
        List<int> ListIntSelectionne = new List<int>();
        Player playerPazaak;
        Cards c = new Cards();
        Image[] playerDeck = new Image[4];
        int[] AiDeck = new int[4];

        bool RoundOver = false;

        Panel[] panelPlayerDeck;
        //Panel[] panelAiDeck;
        Panel[] TabPanelLeft;
        Panel[] TabPanelRight;
        Panel[] TabPnlAiDeck;
        CircularPictureBox[] tabCircularBtnPlayer;
        CircularPictureBox[] tabCircularBtnAi;
        int credsWaged;
        public bool gameOver = false;
        bool addedPlusMinus = false;
        Random rand = new Random();
        Player ai = new Player();

        string result;


        /// <summary>
        /// Pazaak Constructor
        /// </summary>
        /// <param name="playerDeckPazaak"></param>
        /// <param name="carteIntEnvoye"></param>
        public Pazaak(List<Image> playerDeckPazaak, int[] carteIntEnvoye)
        {
            this.playerDeckPazaak = playerDeckPazaak;
            this.carteIntEnvoye = TabToList(carteIntEnvoye);
            playerPazaak = new Player();
            InitializeComponent();
            SetupPlayerdeck();
            SetupAiDeck();
            SetupBoard();
        }

        /// <summary>
        /// This method that sets up global array with the values passed to the pazaak form
        /// to acentuate accesibility
        /// </summary>
        private void SetupAiDeck()
        {
           TabPnlAiDeck = new Panel[]
           {
             PnlAiDeck1,PnlAiDeck2,PnlAiDeck3,PnlAiDeck4
           };

            for (int i = 0; i < TabPnlAiDeck.Length; i++)
            {
                TabPnlAiDeck[i].BackgroundImage = Properties.Resources.back_card_Pazaak;
                TabPnlAiDeck[i].BackgroundImageLayout = ImageLayout.Stretch;
            }

        }
        /// <summary>
        /// This method converts an array passed in parameters into a list
        /// </summary>
        /// <param name="carteIntEnvoye"></param>
        /// <returns></returns>
        private List<int> TabToList(int[] carteIntEnvoye)
        {
            List<int> listRetourner = new List<int>();
            for (int i = 0; i < carteIntEnvoye.Length; i++)
            {
                listRetourner.Add(carteIntEnvoye[i]);
            }
            return listRetourner;
        }

        /// <summary>
        /// Internal int object which is how much the player waged
        /// </summary>
        internal int CreditsWaged { get => credsWaged; set => credsWaged = value; }

        /// <summary>
        /// Internal Player object which is the user's player
        /// </summary>
        internal Player Player1 { get => playerPazaak; set => playerPazaak = value; }

        /// <summary>
        /// Property RoundOver1
        /// </summary>
        public bool RoundOver1 { get => RoundOver; set => RoundOver = value; }

        /// <summary>
        /// Method that filled global arrays for better accessibilty
        /// </summary>
        private void SetupBoard()
        {
            TabPanelLeft = new Panel[]
            {
             RPnlG1, RPnlG2, RPnlG3, RPnlG4, RPnlG5, RPnlG6, RPnlG7, RPnlG8,RPnlG9
            };
            TabPanelRight = new Panel[]
            {
             RPnlD1, RPnlD2, RPnlD3, RPnlD4, RPnlD5, RPnlD6, RPnlD7, RPnlD8,RPnlD9
            };

         tabCircularBtnPlayer = new CircularPictureBox[]
        {
            CPBoxRound1Player,
            CPBoxRound2Player,
            CPBoxRound3Player
        };
            tabCircularBtnAi = new CircularPictureBox[]
        {
            CPBoxRound1AI,
            CPBoxRound2AI,
            CPBoxRound3AI
        };



        }
        /// <summary>
        /// Method that filled global arrays for better accessibilty
        /// </summary>
        private void SetupPlayerdeck()
        {
            SelectCardsForDeck();

            panelPlayerDeck = new Panel[]
            {
             RPnlDownG1, RPnlDownG2, RPnlDownG3, RPnlDownG4
            };
            for (int i = 0; i < panelPlayerDeck.Length; i++)
            {
                panelPlayerDeck[i].BackgroundImage = playerDeck[i];
                panelPlayerDeck[i].BackgroundImageLayout = ImageLayout.Stretch;
            }
            for (int i = 0; i < AiDeck.Length; i++)
            {
                //1 2 3 4 5 6
                //-1 -2 -3 -4 -5 -6
                //7 8 9 10 11 12 == +-1 +-2 etc
                int num = rand.Next(-6, 13);
                while (num == 0)
                {
                    num = rand.Next(-6, 13);
                }
                AiDeck[i] = num;
            }
        }

        /// <summary>
        /// Method that selects 4 specific cards that can will be used for the player deck
        /// </summary>
        private void SelectCardsForDeck()
        {
            int tailleListe = playerDeckPazaak.Count;

            int nombreCarteSelectionne = 0;

            for (int i = 0; i < 4; i++)
            {
                ListIntSelectionne.Add(0);
            }
            while (nombreCarteSelectionne != 4)
            {
                int a = rand.Next(0, tailleListe);
                playerDeck[nombreCarteSelectionne] = playerDeckPazaak.ElementAt(a);
                playerDeckPazaak.RemoveAt(a);

                ListIntSelectionne[nombreCarteSelectionne] = carteIntEnvoye.ElementAt(a);
                carteIntEnvoye.RemoveAt(a);

                tailleListe--;
                nombreCarteSelectionne++;
            }
        }
        /// <summary>
        /// Click event for end turn button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void End_Turn_Click(object sender, EventArgs e)
        {
            if (playerPazaak.NbCards != 9)
            {
            int pointsAdded = rand.Next(1, 11);
            CPBoxAI.BackColor = Color.Black;
            CPBoxPlayer.BackColor = Color.Maroon;
            TabPanelLeft[playerPazaak.NbCards].BackgroundImage = c.getCarteNormal(pointsAdded);
            TabPanelLeft[playerPazaak.NbCards].BackgroundImageLayout = ImageLayout.Stretch;
            playerPazaak.NbCards++;
            playerPazaak.Points += pointsAdded;
            LblPointsPlayer.Text = playerPazaak.Points.ToString();
            AiTurn();
            }
            else
            {
                Stand();
            }
        }
        /// <summary>
        /// Method that analyses what the ai should do during its turn
        /// and executes the action
        /// </summary>
        private void AiTurn()
        {
            int pointsAdded = 0;
            CPBoxAI.BackColor = Color.Maroon;
            CPBoxPlayer.BackColor = Color.Black;
            Move moveAI = DetermineMove();

            if (moveAI == Projet_GONLO.Move.End_Turn)
            {
                pointsAdded = rand.Next(1, 11);
                TabPanelRight[ai.NbCards].BackgroundImage = c.getCarteNormal(pointsAdded);
                TabPanelRight[ai.NbCards].BackgroundImageLayout = ImageLayout.Stretch;
                ai.NbCards++;
                ai.Points += pointsAdded;
                LblPointsAi.Text = ai.Points.ToString();
            }
            else if (moveAI == Projet_GONLO.Move.Stand)
            {
                ai.Stand = true;
            }
            else
            {
                AddCard(moveAI);
            }

        }

       
        /// <summary>
        /// Method that adds a card from the player deck based an on index
        /// </summary>
        /// <param name="index"></param>
        private void AddAICardToBoard(int index)
        {
            Panel[] TabPnlAiDeck = new Panel[]
            {
             PnlAiDeck1,PnlAiDeck2,PnlAiDeck3,PnlAiDeck4
            };

            
            if (AiDeck[index] < 0)
            {
                TabPanelRight[ai.NbCards].BackgroundImage = c.getCarteMinus(AiDeck[index] - 2 * (AiDeck[index]));
                ai.Points += AiDeck[index];
            }
            else if (AiDeck[index] > 0 && AiDeck[index] < 7)
            {
                TabPanelRight[ai.NbCards].BackgroundImage = c.getCartePlus(AiDeck[index]);
                ai.Points += AiDeck[index];
            }
            else
            {
                if (ai.Points > 20)
                {
                    TabPanelRight[ai.NbCards].BackgroundImage = c.getCartePlusMinus(AiDeck[index] - 6);
                    ai.Points -= AiDeck[index] - 6;
                }
                else
                {
                    TabPanelRight[ai.NbCards].BackgroundImage = c.getCartePlusMinus(AiDeck[index] - 6);
                    ai.Points += AiDeck[index] - 6;
                }
            }
            AiDeck[index] = 100; //empty
            TabPanelRight[ai.NbCards].BackgroundImageLayout = ImageLayout.Stretch;
            LblPointsAi.Text = ai.Points.ToString();
            TabPnlAiDeck[index].BackgroundImage = null;
            ai.NbCards++;
            ai.NbCarteUtiliseAi++;

        }
        /// <summary>
        /// Methode that that detects which enum will be assciated with which card
        /// in the Ai deck
        /// </summary>
        /// <param name="moveAI"></param>
        private void AddCard(Move moveAI)
        {
            switch (moveAI)
            {
                case Projet_GONLO.Move.AddCard1:
                    AddAICardToBoard(0);
                    break;
                case Projet_GONLO.Move.AddCard2:
                    AddAICardToBoard(1);
                    break;
                case Projet_GONLO.Move.AddCard3:
                    AddAICardToBoard(2);
                    break;
                case Projet_GONLO.Move.AddCard4:
                    AddAICardToBoard(3);
                    break;

            }
        }

        /// <summary>
        /// Method that determines the best move based on the player and the ai points
        /// </summary>
        /// <returns></returns>
        private Move DetermineMove()
        {
            if (ai.NbCards != 9)
            {
                if (ai.Points <= 14)
                {
                    return Projet_GONLO.Move.End_Turn;
                }   
                else if (ai.Points == 20 || ai.Points == 19 || ai.Points == 18 || addedPlusMinus)
                {
                    return Projet_GONLO.Move.Stand;
                }
                else if (ai.Points > 20)
                {
                    return MinusCard();
                }
                else if (ai.Points > 14 && ai.Points < 20)
                {
                    return PlusCard();
                }
            }
            return Projet_GONLO.Move.Stand;
        }

        /// <summary>
        /// Method that verify's if there is a Plus minus card to add
        /// </summary>
        /// <returns></returns>
        private Move AddPlusMinusCard()
        {
            if (playerPazaak.Points < 21) { 


                for (int i = 0; i < AiDeck.Length; i++)
                {
                    if (AiDeck[i] > 6 && AiDeck[i] < 13)
                    {
                        if (ai.Points > 20 && ai.Points - (AiDeck[i] - 6) > playerPazaak.Points && ai.Points - (AiDeck[i] - 6) <= 20)
                        {
                            addedPlusMinus = true;
                            return DetermineCard(i);
                        }
                        else if (ai.Points < 20 && AiDeck[i] + (ai.Points - 6) <= 20 && AiDeck[i] + (ai.Points - 6) >= playerPazaak.Points)
                        {
                            addedPlusMinus = true;
                            return DetermineCard(i);
                        }
                        
                    }
                }


            }


            return Projet_GONLO.Move.Stand;
        }


        /// <summary>
        /// Method that verifys if there is a potential + card that could be used
        /// </summary>
        /// <returns></returns>
        private Move PlusCard()
        {
            if (playerPazaak.Points < 20)
            {

                for (int i = 0; i < AiDeck.Length; i++)
                {

                    if (AiDeck[i] > 0)
                    {
                        if (AiDeck[i] < 7 && AiDeck[i] + ai.Points <= 20) 
                        {
                            if (AiDeck[i] + ai.Points >= playerPazaak.Points ||  4 - ai.NbCarteUtiliseAi > 0)
                            {
                                return DetermineCard(i);
                            }

                        }
                    }
                }
            }
            return AddPlusMinusCard();
        }
        /// <summary>
        /// Method that verifys if there is a potential minus card that can be used
        /// </summary>
        /// <returns></returns>
        private Move MinusCard()
        {
            if (playerPazaak.Points <= 20)
            {

                for (int i = 0; i < AiDeck.Length; i++)
                {

                    if (AiDeck[i] < 0 && ai.Points + AiDeck[i] <= 20 && ai.Points + AiDeck[i] >= playerPazaak.Points)
                    {
                        return DetermineCard(i);

                    }
                }
            }
            return AddPlusMinusCard();
        }
        /// <summary>
        /// Method that determines which enum to return based on an index
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private Move DetermineCard(int element)
        {
            switch (element)
            {
                case 0:
                    return Projet_GONLO.Move.AddCard1;
                case 1:
                    return Projet_GONLO.Move.AddCard2;
                case 2:
                    return Projet_GONLO.Move.AddCard3;
                case 3:
                    return Projet_GONLO.Move.AddCard4;
            }
            return Projet_GONLO.Move.Stand;
        }
        /// <summary>
        /// Method that is called when the player stands
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stand_Click(object sender, EventArgs e)
        {
            Stand();
        }
        /// <summary>
        /// Method that loops if the player stands and the ai didnt
        /// otherwise it will just verify the winner
        /// </summary>
        private void Stand()
        {
            playerPazaak.Stand = true;
            VerifyStands();
            while (!gameOver)
            {
                AiTurn();
                VerifyStands();

            }
            ResetGame();
        }
        /// <summary>
        /// Method that verifiys if both player have standed
        /// </summary>
        private void VerifyStands()
        {
            if (ai.Stand && playerPazaak.Stand)
            {
                FindWinner();
            }
            
        }
        /// <summary>
        /// Methode that finds a winner and show the appropiate
        /// message box to indicate the winner
        /// </summary>
        private void FindWinner()
        {
            result = "";
            
            if (ai.Points == playerPazaak.Points)
            {
                result = "Egalite";
            }
            else if (playerPazaak.Points == 20)
            {
                result = "Player gagné!!";
                
            }
            else if (ai.Points == 20)
            {
                result = "Ai gagne!!";
            }
            else if (ai.Points < 20 && playerPazaak.Points < 20)
            {
                if (differenceFrom20(ai.Points) < differenceFrom20(playerPazaak.Points))
                {
                    result = "Ai gagne!!";
                }
                else
                {
                    result = "Player gagné!!";
                }
            }
            else if (ai.Points > 20 && playerPazaak.Points > 20)
            {
                result = "Egalite";
            }
            else if (ai.Points < 20 && playerPazaak.Points > 20)
            {
                result = "Ai gagne!!";
            }
            else
            {
                result = "Player gagné!!";
            }
            MessageBox.Show(result);
            if (result == "Player gagné!!")
            {   
                tabCircularBtnPlayer[playerPazaak.NbVictoire].BackColor = Color.Maroon;
                playerPazaak.NbVictoire++;
            }
            else if (result == "Ai gagne!!")
            {
                tabCircularBtnAi[ai.NbVictoire].BackColor = Color.Maroon;
                ai.NbVictoire++;
            }
            gameOver = true;
            
            
        }

        
        /// <summary>
        /// Method that verifys the differce of points a player may have over 20
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        private int differenceFrom20(int points)
        {
            return 20 - points;
        }


        /// <summary>
        /// Methode qui save le joueur dans un fichier text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List <Player> playersSaved = new List<Player>();
            bool found = false;
            int position = 0;
            playersSaved = readSaveFile();
            //MessageBox.Show(playersSaved.Count.ToString());
            foreach (Player p in playersSaved)
            {
                if (p.Name == playerPazaak.Name)
                {
                    found = true;
                    break;
                }
                position++;
            }
            if (found)
            {
                DialogResult dr = MessageBox.Show("Your data already exists in the save file. " +
                    "Do you wish to overwrite your saved data?", "ATTENTION", MessageBoxButtons.YesNo);

                switch (dr)
                {
                    case DialogResult.Yes:
                        playersSaved[position] = playerPazaak;
                        writePlayerData(playersSaved);
                        break;
                    case DialogResult.No:
                        writePlayerData(playersSaved);
                        break;
                }
            }
            else
            {
                playersSaved.Add(playerPazaak);
                writePlayerData(playersSaved);
            }
        }

        /// <summary>
        /// Methode qui ecrit les informations du client dans un fichier text
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <param name="player"></param>
        private void writePlayerData(List<Player> players)
        {
            StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\SavesTest.txt");
            foreach (Player player in players)
            {
                streamWriter.WriteLine(player.Name + ";" + player.Gender + ";" + player.Species + ";" + player.Credits.ToString() + ";" +
                            player.PazaakGamesWon.ToString() + ";" + player.PazaakGamesLost.ToString() + ";" + player.DejarikGamesWon.ToString() + ";"
                            + player.DejarikGamesLost.ToString());
            }
            streamWriter.Close();
        }

        /// <summary>
        /// Methode qui lit un fichier text et save les informations dans une liste de joueurs
        /// </summary>
        /// <returns></returns>
        public List<Player> readSaveFile()
        {
            List<Player> playersSaved = new List<Player>();
            string line = "";

            if (!File.Exists(Application.StartupPath + "\\SavesTest.txt"))
            {
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\SavesTest.txt");
                sw.Close();
            }
            StreamReader sr = new StreamReader(Application.StartupPath + "\\SavesTest.txt");
            while ((line = sr.ReadLine()) != null)
            {
                string[] new_player = line.Split(';');
                Player player = new Player();
                player.Name = new_player[0];
                player.Gender = new_player[1];
                player.Species = new_player[2];
                player.Credits = Int32.Parse(new_player[3]);
                player.PazaakGamesWon = Int32.Parse(new_player[4]);
                player.PazaakGamesLost = Int32.Parse(new_player[5]);
                player.DejarikGamesWon = Int32.Parse(new_player[6]);
                player.DejarikGamesLost = Int32.Parse(new_player[7]);
                playersSaved.Add(player);
            }
            sr.Close();
            return playersSaved;
        }

        /// <summary>
        /// Methode qui restart la partie de pazzak lorsque l'on clique sur l'onglet restart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void RestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PazaakCardsSelector newPazaakCardSelector = new PazaakCardsSelector();
            newPazaakCardSelector.Player1 = playerPazaak;
            newPazaakCardSelector.ShowDialog();
            this.Close();
        }


        /// <summary>
        /// Method that leaves the game and removes credits from the player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to forfeit and quit the game ? You will  automaticaly lose the amount of credits taht you waged", "Attention", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                playerPazaak.Credits -= credsWaged;
                playerPazaak.PazaakGamesLost++;
                this.Hide();
                MenuAccueil newMenuAccueil = new MenuAccueil();
                newMenuAccueil.Player1 = playerPazaak;
                newMenuAccueil.ShowDialog();
                this.Close();
            }
        }


        /// <summary>
        /// Method de declenche lorsque l'on clique sur help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("How to Play Pazaak:\n" +

            "The goal of the game is to win the best of 5.Each player has their own deck of 4 cards.\n" +
            "Your 4 cards are randomly selected from the 10 cards you selected in the last window.\n" +
            "To win you must the closest to 20 but not go over 20 \n\n\n " +
            "During your turn you have for options:\n" +
            "1.End turn:  this will add a random card form 1 to 10\n\n" +
            "2.Stand: you stop adding cards\n\n" +
            "3.Add Card: it will add one of our cards form your deck to the bord\n\n\n" +
            "For more information:\n\n" +
            "+ Cards: When selected during Pazaak Duel will increase your score of the number written on the card.\n\n" +
            "- Cards: When selected during Pazaak Duel will decrease your score of the number written on the card.\n\n" +
            "+/- Cards: When selected during Pazaak Duel will increase or decrease your score of the number written on the card. \n" +
            "When you will click on the “flip card” text you will see a “+” or “-” (+by default)." +
            "This symbol will decide which what the card will do.",
             "Pazzak Infomation");
        }


        /// <summary>
        /// Methode that is accessed when clicked on forfeit game button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RPnlForfeitGame_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to forfeit and quit the game ?", "Attention", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                playerPazaak.Credits -= credsWaged;
                playerPazaak.PazaakGamesLost++;
                this.Hide();
                MenuAccueil newMenuAccueil = new MenuAccueil();
                newMenuAccueil.Player1 = playerPazaak;
                newMenuAccueil.ShowDialog();
                this.Close();
            }
        }


        /// <summary>
        /// Method that permits to load pazzak form and sets up all the labels to
        /// be by default false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pazaak_Load(object sender, EventArgs e)
        {
            LblNumeric1.Hide();
            LblNumeric2.Hide();
            LblNumeric3.Hide();
            LblNumeric4.Hide();
            LblMinusValue1.Hide();
            LblMinusValue2.Hide();
            LblMinusValue3.Hide();
            LblMinusValue4.Hide();
            LblPlusValue1.Hide();
            LblPlusValue2.Hide();
            LblPlusValue3.Hide();
            LblPlusValue4.Hide();
            LblFlipCard1.Hide();
            LblFlipCard2.Hide();
            LblFlipCard3.Hide();
            LblFlipCard4.Hide();
            LblCreditsWagedNumeric.Text = credsWaged.ToString();
            LblPlayerName.Text = playerPazaak.Name;
            LblCreditsNumeric.Text = playerPazaak.Credits.ToString();
            ShowFlipCard();
        }
        /// <summary>
        /// Method that shows the appropirate labels for a plus minus card
        /// </summary>
        private void ShowFlipCard()
        {
            Label[] Numeric = { LblNumeric1, LblNumeric2, LblNumeric3, LblNumeric4 };
            Label[] PlusValue = { LblPlusValue1, LblPlusValue2, LblPlusValue3, LblPlusValue4 };
            Label[] FlipCard = { LblFlipCard1, LblFlipCard2, LblFlipCard3, LblFlipCard4 };

            for (int i = 0; i < ListIntSelectionne.Count; i++)
            {
                if (ListIntSelectionne[i] > 11)
                {
                    PlusValue[i].Show();
                    FlipCard[i].Show();
                    Numeric[i].Text = (ListIntSelectionne[i] - 11).ToString();
                    Numeric[i].Show();
                }
            }
        }
        /// <summary>
        /// Method for when card1 of player deck is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RPnlDownG1_Click(object sender, EventArgs e)
        {
            AddCardPlayerDeck(0);
        }
        /// <summary>
        /// Method for when card2 of player deck is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RPnlDownG2_Click(object sender, EventArgs e)
        {
            AddCardPlayerDeck(1);
        }
        /// <summary>
        /// Method for when card3 of player deck is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RPnlDownG3_Click(object sender, EventArgs e)
        {
            AddCardPlayerDeck(2);
        }
        /// <summary>
        /// Method for when card4 of player deck is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RPnlDownG4_Click(object sender, EventArgs e)
        {
            AddCardPlayerDeck(3);
        }
        /// <summary>
        /// Method that adds the corret card from the player deck to the board
        /// </summary>
        /// <param name="indexPanel"></param>
        private void AddCardPlayerDeck(int indexPanel)
        {
            Label[] MinusValue = { LblMinusValue1, LblMinusValue2, LblMinusValue3, LblMinusValue4 };
            Label[] Numeric = { LblNumeric1, LblNumeric2, LblNumeric3, LblNumeric4 };
            Label[] PlusValue = { LblPlusValue1, LblPlusValue2, LblPlusValue3, LblPlusValue4 };
            Label[] FlipCard = { LblFlipCard1, LblFlipCard2, LblFlipCard3, LblFlipCard4 };
            CPBoxAI.BackColor = Color.Black;
            CPBoxPlayer.BackColor = Color.Maroon;
            TabPanelLeft[playerPazaak.NbCards].BackgroundImage = playerDeck[indexPanel];
            panelPlayerDeck[indexPanel].BackgroundImage = null;

            TabPanelLeft[playerPazaak.NbCards].BackgroundImageLayout = ImageLayout.Stretch;
            playerPazaak.NbCards++;
            if (ListIntSelectionne[indexPanel] >= 0 && ListIntSelectionne[indexPanel] < 6)
            {
                playerPazaak.Points += ListIntSelectionne[indexPanel] + 1;
            }
            else if (ListIntSelectionne[indexPanel] >= 6 && ListIntSelectionne[indexPanel] < 12)
            {
                // -6 pcq index commence apres les cartes + et + 1 puisque l'index commence a zero
                int pointsEnlever = ListIntSelectionne[indexPanel] - 5;
                playerPazaak.Points -= pointsEnlever;
            }
            else
            {
                int pointsEnlever = ListIntSelectionne[indexPanel] - 11;
                if (MinusValue[indexPanel].Visible)
                {
                    playerPazaak.Points -= pointsEnlever;
                }
                else
                {
                    playerPazaak.Points += pointsEnlever;
                }
                MinusValue[indexPanel].Hide();
                PlusValue[indexPanel].Hide();
                Numeric[indexPanel].Hide();
                FlipCard[indexPanel].Hide();

            }
            panelPlayerDeck[indexPanel].Enabled = false;
            LblPointsPlayer.Text = playerPazaak.Points.ToString();
            AiTurn();
        }

        /// <summary>
        /// Method that shows the + and - sign when clicked on "filp card"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlipCard_Click(object sender, EventArgs e)
        {
            Label[] MinusValue = { LblMinusValue1, LblMinusValue2, LblMinusValue3, LblMinusValue4 };
            Label[] PlusValue = { LblPlusValue1, LblPlusValue2, LblPlusValue3, LblPlusValue4 };

            string lablelName = ((Label)sender).Name;
            for (int i = 0; i < playerDeck.Length; i++)
            {
                if (lablelName.IndexOf((i+1).ToString()) != -1)
                {
                   if (PlusValue[i].Visible)
                   {
                        PlusValue[i].Hide();
                        MinusValue[i].Show();
                    }
                    else
                    {
                        PlusValue[i].Show();
                        MinusValue[i].Hide();
                    }
                }
            }
        }

        /// <summary>
        /// This method that resets all components of the pazaak round
        /// </summary>
        private void ResetGame()
        {
            for (int i = 0; i < TabPanelLeft.Length; i++)
            {
                TabPanelLeft[i].BackgroundImage = null;
                TabPanelRight[i].BackgroundImage = null;
            }
            gameOver = false;
            addedPlusMinus = false;
            
            playerPazaak.Points = 0;
            ai.Points = 0;
            playerPazaak.NbCards = 0;
            ai.NbCards = 0;

            ai.Stand = false;
            playerPazaak.Stand = false;

            LblPointsAi.Text = "0";
            LblPointsPlayer.Text = "0";
            ai.NbCarteUtiliseAi = 0;

            if (playerPazaak.NbVictoire == 3)
            {
                MessageBox.Show("Vous avez gagne!!!!!!!!!");
                playerPazaak.Credits += credsWaged;
                playerPazaak.PazaakGamesWon++;
                this.Hide();
                playerPazaak.NbVictoire = 0;
                ai.NbVictoire = 0;
                MenuAccueil newMenuAccueil = new MenuAccueil();
                newMenuAccueil.Player1 = playerPazaak;
                newMenuAccueil.ShowDialog();
                this.Close();
            }
            if (ai.NbVictoire == 3)
            {
                MessageBox.Show("Vous avez perdu :( :(");
                playerPazaak.Credits -= credsWaged;
                playerPazaak.PazaakGamesLost++;
                this.Hide();
                playerPazaak.NbVictoire = 0;
                ai.NbVictoire = 0;
                MenuAccueil newMenuAccueil = new MenuAccueil();
                newMenuAccueil.Player1 = playerPazaak;
                newMenuAccueil.ShowDialog();
                this.Close();
            }
        }
    }
}