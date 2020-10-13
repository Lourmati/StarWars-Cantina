using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_GONLO
{
    /// <summary>
    /// Class PazaakCardsSelector herite form et laisse le joueur
    /// choisir les cartes qu'il va jouer avec
    /// </summary>
    public partial class PazaakCardsSelector : Form
    {
        Player playerCBS = new Player();
        List<RoundPanel> playerDeck = new List<RoundPanel>();
        SoundPlayer sound = new SoundPlayer(Properties.Resources.Pazzak_Cantina);

        List<Image> playerDeckImage = new List<Image>();
        List<int> positionCarteEnleve = new List<int>();
        int nbCartes = 0;
        int creditsWaged = 0;

        List<Panel> listeCarteTotal = new List<Panel>();


        //List<int> carteIntEnvoye = new List<int>();
        int[] carteIntEnvoye = new int[10];


        /// <summary>
        /// Constructor PazaakCardsSelector
        /// </summary>
        public PazaakCardsSelector()
        {
            InitializeComponent();
            sound.PlayLooping();
            FillListPanels();
        }

        public Player Player1 { get => playerCBS; set => playerCBS = value; }
        //internal

        internal List<Image> Player1Deck { get => playerDeckImage; set => playerDeckImage = value; }


        /// <summary>
        /// Method that fills the panels with the appropriate panels
        /// </summary>
        public void FillListPanels()
        {
            playerDeck.Add(RPnlPlayerDC1);
            playerDeck.Add(RPnlPlayerDC2);
            playerDeck.Add(RPnlPlayerDC3);
            playerDeck.Add(RPnlPlayerDC4);
            playerDeck.Add(RPnlPlayerDC5);
            playerDeck.Add(RPnlPlayerDC6);
            playerDeck.Add(RPnlPlayerDC7);
            playerDeck.Add(RPnlPlayerDC8);
            playerDeck.Add(RPnlPlayerDC9);
            playerDeck.Add(RPnlPlayerDC10);


            listeCarteTotal.Add(RPnlPlus1);
            listeCarteTotal.Add(RPnlPlus2);
            listeCarteTotal.Add(RPnlPlus3);
            listeCarteTotal.Add(RPnlPlus4);
            listeCarteTotal.Add(RPnlPlus5);
            listeCarteTotal.Add(RPnlPlus6);

            listeCarteTotal.Add(RPnlMinus1);
            listeCarteTotal.Add(RPnlMinus2);
            listeCarteTotal.Add(RPnlMinus3);
            listeCarteTotal.Add(RPnlMinus4);
            listeCarteTotal.Add(RPnlMinus5);
            listeCarteTotal.Add(RPnlMinus6);

            listeCarteTotal.Add(RPnlPlusMinus1);
            listeCarteTotal.Add(RPnlPlusMinus2);
            listeCarteTotal.Add(RPnlPlusMinus3);
            listeCarteTotal.Add(RPnlPlusMinus4);
            listeCarteTotal.Add(RPnlPlusMinus5);
            listeCarteTotal.Add(RPnlPlusMinus6);

        }
        /// <summary>
        /// Click event when the player click on the ready button
        /// It will close the form and then pass the information
        /// to the pazaak form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEllReady_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < playerDeck.Count; i++)
            {
                playerDeckImage.Add(playerDeck[i].BackgroundImage);
            }
            MessageBox.Show("How to Play Pazzak:\n" +

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
            "+-Cards: When selected during Pazaak Duel will increase or decrease your score of the number written on the card. \n" +
            "When you will click on the “flip card” text you will see a “+” or “-” (+by default)." +
            "This symbol will decide which what the card will do.",
             "Pazzak Infomation");



            Hide();
            Pazaak newPazaakGame = new Pazaak(playerDeckImage, carteIntEnvoye);
            newPazaakGame.Player1 = playerCBS;


            newPazaakGame.CreditsWaged = int.Parse(MTxtBoxWager.Text);
            newPazaakGame.ShowDialog();   
            this.Close();
        }


        /// <summary>
        /// Method that add the image of the selected form to the appropriate Panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAvailableCards_Click(object sender, EventArgs e)
        {
            RoundPanel roundPanel = sender as RoundPanel;
            int position = FindPositionPanel(roundPanel);
            
            if (positionCarteEnleve.Count == 0)
            {
                if (nbCartes < 10)
                {
                    playerDeck.ElementAt(nbCartes).BackgroundImage = roundPanel.BackgroundImage;
                    carteIntEnvoye[nbCartes] = position;
                    nbCartes++;
                }
            }
            else
            {
                playerDeck.ElementAt(positionCarteEnleve.ElementAt(0)).BackgroundImage = roundPanel.BackgroundImage;
                carteIntEnvoye[positionCarteEnleve[0]] = position;
                positionCarteEnleve.RemoveAt(0);
                nbCartes++;
            }
            if (nbCartes > 10)
            {
                MessageBox.Show("You have the maximum cards allowed");
            }

            if (AllCardsSelected() && MTxtBoxWager.Text != "")
            {
                BtnEllReady.Enabled = true;
            }
            else
            {
                BtnEllReady.Enabled = false;
            }

        }
        /// <summary>
        /// Method that return true if all panels are filled with a card
        /// otherwise false
        /// </summary>
        /// <returns></returns>
        private bool AllCardsSelected()
        {
            for (int i = 0; i < playerDeck.Count; i++)
            {
                if (playerDeck[i].BackgroundImage == null)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Method that returns the postion of a panel passed
        /// in arguments from a panel from an array
        /// </summary>
        /// <param name="roundPanel"></param>
        /// <returns></returns>
        private int FindPositionPanel(RoundPanel roundPanel)
        {
            for (int i = 0; i < listeCarteTotal.Count; i++)
            {
                if (roundPanel.BackgroundImage == listeCarteTotal[i].BackgroundImage)
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Method that selects 4 cards randomly form the cards selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveDeckCards(object sender, EventArgs e)
        {
            RoundPanel roundPanel = sender as RoundPanel;
            if (roundPanel.BackgroundImage != null)
            {
                int idx = playerDeck.IndexOf(roundPanel);
                RemoveElementInt(roundPanel, idx);
                roundPanel.BackgroundImage = null;
                BtnEllReady.Enabled = false;  
                positionCarteEnleve.Add(idx);
                nbCartes--;
            }

        }


        /// <summary>
        /// Method that set a certain position of an array to
        /// emulate the array being empty
        /// </summary>
        /// <param name="roundPanel"></param>
        /// <param name="idx"></param>
        private void RemoveElementInt(RoundPanel roundPanel, int idx)
        {
            int position = FindPositionPanel(roundPanel);
            carteIntEnvoye[idx] = 100;
        }

        /// <summary>
        /// Method that returns the number of cards selected
        /// </summary>
        /// <returns></returns>
        public int CheckDeck()
        {
            int numberCards = 0;
            foreach (var card in playerDeck)
            {
                if (card.BackgroundImage != null)
                {
                    numberCards++;
                }
            }
            return numberCards;
        }
        /// <summary>
        /// Load event on the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PazaakCardsSelector_Load(object sender, EventArgs e)
        {
            BtnEllReady.Enabled = false;
        }
        /// <summary>
        /// Method that is activited on exit click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sound.Stop();
            this.Close();
        }
        /// <summary>
        /// Method that is called when clicked on help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuAccueil menu = new MenuAccueil();
            menu.Player1 = playerCBS;
            menu.ShowDialog();
            this.Close();
        }
        /// <summary>
        /// Method that verify's if the text entered in the text box is valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MTxtBoxWager_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            DialogResult result = MessageBox.Show("You have to write down a number", "ATTENTION");
            MTxtBoxWager.Text = "";
        }

        /// <summary>
        /// Method that enables button depending on different circonstaces
        /// and will then determine if it should activate the button or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MTxtBoxWager_TextChanged(object sender, EventArgs e)
        {
            if (MTxtBoxWager.Text != "" && AllCardsSelected())
            {
                BtnEllReady.Enabled = true;
            }
            else
            {
                BtnEllReady.Enabled = false;
            }
            
        }

    }
}